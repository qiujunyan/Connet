Imports System.Data.SqlClient
Imports Connet

Public Class frm_edit
    'Private dm As Domain = Server.GetCurDomain()
    Private Sub frm_edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DefDomain As String = GetSetting("ConceptualNetwork", "Start", "Default")
        If (DefDomain Is Nothing) Or (DefDomain.Length = 0) Then
            Dim dft As New frmDefault
            If Not dft.ShowDialog() = Windows.Forms.DialogResult.OK Then
                End
            End If
        End If
        Dim strArr() As String = DefDomain.Split(New Char() {" "c})
        Dim dm As Domain = Server.CurServer.LoadDomain(strArr(0))
        Server.CurServer.CurDomain = dm

        If dm Is Nothing Then
            Return
        End If

        For Each kt As KnowTree In dm.KnowTreeList
            If kt.TreeName = g_course_str Then
                kt.ShowOnTreeView(tv_knowTree)
            End If
            'kt.ShowOnTreeView(tv_knowTree)
        Next
        tv_knowTree.ExpandAll()
    End Sub
    Private Sub bnt_genKnowTree_Click(sender As Object, e As EventArgs) Handles bnt_genKnowTree.Click
        Dim dm As Domain = Server.GetCurDomain()
        Dim frm As New frmKnowTree
        frm.Domain = dm
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim tr As KnowTree = frm.EditTree
            dm.CurrentKnowTree = tr
            Dim nd As Windows.Forms.TreeNode = tr.ShowOnTreeView(tv_knowTree)
            If Not nd Is Nothing Then nd.EnsureVisible()
        End If
    End Sub

    Private Sub bnt_delKnowTree_Click(sender As Object, e As EventArgs) Handles bnt_delKnowTree.Click
        'Dim nd As Windows.Forms.TreeNode = tv_knowTree.SelectedNode
        'If nd Is Nothing Then Return
        'Dim kt As KnowTree
        'If TypeOf nd.Tag Is KnowTree Then
        '    kt = nd.Tag
        'Else
        '    kt = CType(nd.Tag, KnowNode).KnowTree
        'End If
        'Server.CurServer.CurDomain.CurrentKnowTree = kt
        'If MsgBox("真的要删除知识树：" & kt.TreeName & "？", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
        '    Dim Trans As SqlTransaction = kt.Domain.WhichServer.Database.BeginTransaction()
        '    If kt.DBDelete(Trans) Then
        '        Trans.Commit()
        '        Dim dm As Domain = kt.Domain
        '        dm.KnowTreeList.Remove(kt)
        '        dm.CurrentKnowTree = Nothing
        '        tv_knowTree.Nodes.Remove(nd)
        '        MsgBox("删除成功!")
        '    Else
        '        Trans.Rollback()
        '        MsgBox("删除失败，详情见日志!")
        '    End If
        'End If
    End Sub

    Private Sub bnt_newKnowNode_Click(sender As Object, e As EventArgs) Handles bnt_newKnowNode.Click
        Dim nd As TreeNode = tv_knowTree.SelectedNode
        If nd Is Nothing Then Return
        Dim Tree As KnowTree
        Dim pn As TreeNode
        Dim frm As New frmKnowNode

        If TypeOf nd.Tag Is KnowTree Then
            Try
                Tree = nd.Tag
                pn = nd
                Server.CurServer.CurDomain.CurrentKnowTree = Tree
                frm.KnowTree = Tree
            Catch ex As Exception
                frm.KnowTree = nd.Tag
                Server.CurServer.CurDomain.CurrentKnowTree = nd.Tag
            End Try
        Else
            Try
                Tree = CType(nd.Tag, KnowNode).KnowTree
                pn.Nodes.Add(nd)
                Server.CurServer.CurDomain.CurrentKnowTree = Tree
                frm.KnowTree = Tree
            Catch ex As Exception
                frm.SetParent = nd.Tag
                Server.CurServer.CurDomain.CurrentKnowTree = CType(nd.Tag, KnowNode).KnowTree
            End Try
        End If

        Try
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Try
                    Dim kn As KnowNode = frm.EditNode
                    Dim sn As TreeNode = kn.ShowOnNode(pn)
                    If Not sn Is Nothing Then sn.EnsureVisible()
                Catch ex As Exception
                    Dim nnd As TreeNode = frm.EditNode.ShowOnNode(nd)
                    If Not nnd Is Nothing Then nd.EnsureVisible()
                End Try
            End If
        Catch ex As Exception
            MsgBox("出现异常，请重试！")
            Exit Sub
        End Try

    End Sub

    Private Sub bnt_delKnowNode_Click(sender As Object, e As EventArgs) Handles bnt_delKnowNode.Click
        If tv_knowTree.SelectedNode Is Nothing Then Return
        If tv_knowTree.SelectedNode.Tag Is Nothing Then Return
        If TypeOf tv_knowTree.SelectedNode.Tag Is KnowNode Then
            Server.CurServer.CurDomain.CurrentKnowTree = CType(tv_knowTree.SelectedNode.Tag, KnowNode).KnowTree
            Dim EditNode As TreeNode = tv_knowTree.SelectedNode
            Dim nd As KnowNode = EditNode.Tag
            Dim DelType As ProcessKnowNodeType
            If nd.HaveOffspring() Then
                DelType = ProcAllNodes()
            Else
                If MsgBox("真的要删除" & nd.Name & "？", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                    DelType = ProcessKnowNodeType.LocalProcess
                Else
                    Return
                End If
            End If
            If DelType = ProcessKnowNodeType.AllProcess Then
                Dim Trans As SqlTransaction = nd.KnowTree.Domain.WhichServer.Database.BeginTransaction()
                If nd.DeleteAll(Trans) Then
                    Trans.Commit()
                    EditNode.Parent.Nodes.Remove(EditNode)
                Else
                    Trans.Rollback()
                    MsgBox("删除失败，详情见日志！")
                End If
                tv_knowTree.SelectedNode.Remove()
            ElseIf DelType = ProcessKnowNodeType.LocalProcess Then
                Dim ppn As TreeNode = EditNode.Parent.Parent
                Dim pn As TreeNode = EditNode.Parent
                Dim Trans As SqlTransaction = nd.KnowTree.Domain.WhichServer.Database.BeginTransaction()
                If nd.DeleteMeOnly(Trans) Then
                    Trans.Commit()
                    EditNode.Remove()
                    RedrawNode(pn)
                Else
                    Trans.Rollback()
                    If MsgBox("删除失败，系统需要退出以避免出现知识混乱！", MsgBoxStyle.OkCancel Or MsgBoxStyle.DefaultButton1) = MsgBoxResult.Ok Then
                        Me.MdiParent.Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RedrawNode(ByVal nd As TreeNode)
        Dim ndList As New Collections.ArrayList
        For Each snd As TreeNode In nd.Nodes
            ndList.Add(snd.Tag)
        Next
        If TypeOf nd.Tag Is KnowTree Then
            Dim kt As KnowTree = nd.Tag
            For Each k As KnowNode In kt.Root
                If Not ndList.Contains(k) Then
                    k.ShowOnNode(nd)
                End If
            Next
        Else
            Dim kn As KnowNode = nd.Tag
            For Each k As KnowNode In kn.Children
                If Not ndList.Contains(k) Then
                    k.ShowOnNode(nd)
                End If
            Next
            For Each k As KnowNode In kn.Member
                If Not ndList.Contains(k) Then
                    k.ShowOnNode(nd)
                End If
            Next
        End If
    End Sub

    Public Function ProcAllNodes() As ProcessKnowNodeType
        Dim frm As New frmDelOpt
        If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Return frm.ProcType
        Else
            Return ProcessKnowNodeType.NoneProcess
        End If
    End Function

    Private Sub bnt_editKnowNode_Click(sender As Object, e As EventArgs) Handles bnt_editKnowNode.Click
        If tv_knowTree.SelectedNode Is Nothing Then Return
        If tv_knowTree.SelectedNode.Tag Is Nothing Then Return
        If Not tv_knowTree.SelectedNode.IsExpanded Then
            If TypeOf tv_knowTree.SelectedNode.Tag Is KnowTree Then
                Server.CurServer.CurDomain.CurrentKnowTree = tv_knowTree.SelectedNode.Tag
                Dim EditNode As TreeNode = tv_knowTree.SelectedNode
                Dim frm As New frmKnowTree
                frm.EditTree = EditNode.Tag
                frm.IsEdit = True
                frm.ShowDialog(Me)
            Else
                Dim EditNode As TreeNode = tv_knowTree.SelectedNode
                Server.CurServer.CurDomain.CurrentKnowTree = CType(tv_knowTree.SelectedNode.Tag, KnowNode).KnowTree
                Dim frm As New frmKnowNode
                frm.EditNode = EditNode.Tag
                frm.ShowDialog(Me)
            End If
        End If

    End Sub

    Private Sub bnt_genConcept_Click(sender As Object, e As EventArgs) Handles bnt_genConcept.Click
        Dim dm As Domain = Server.GetCurDomain()
        Dim frm As New frmConcept()
        frm.ConcDomain = dm
        frm.ShowDialog()
    End Sub

    Private Sub bnt_delConcept_Click(sender As Object, e As EventArgs) Handles bnt_delConcept.Click
        Dim tr As TreeNode = tv_knowTree.SelectedNode
        If tr Is Nothing Then Exit Sub
        If TypeOf tr.Tag Is Concept Then
            Dim Conc As Concept = tr.Tag
            If Conc Is Nothing Then Exit Sub
            If MsgBox("真的要删除概念：" & Conc.ToString() & "？", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton2) <> MsgBoxResult.Yes Then Exit Sub
            For Each kt As KnowTree In Conc.ConcDomain.KnowTreeList
                If kt.GetAssoc(Conc) IsNot Nothing Then
                    MsgBox("知识树：" & kt.TreeName & "用到概念：" & Conc.ConcName & "，无法删除！请到知识树中删除相关知识节点和规则等。")
                    Exit Sub
                End If
            Next
            Dim Trans As SqlTransaction = Server.CurServer.Database.BeginTransaction()
            If Conc.DBDelete(Trans) Then
                Trans.Commit()
                Conc.ConcDomain.RemoveConcept(Conc)
                'RedrawConc()
            Else
                Trans.Rollback()
                MsgBox("删除概念：" & Conc.ToString() & "失败！详情见日志。")
            End If
        ElseIf TypeOf tr.Tag Is Phrase Then
            Dim ph As Phrase = tr.Tag
            If ph Is Nothing Then Exit Sub
            If MsgBox("真的要删除词汇：" & ph.ToString() & "？", MsgBoxStyle.YesNoCancel Or MsgBoxStyle.DefaultButton2) <> MsgBoxResult.Yes Then Exit Sub
            Dim Trans As SqlTransaction = Server.CurServer.Database.BeginTransaction()
            If ph.DBDelete(Trans) Then
                Trans.Commit()
                Server.CurServer.CurDomain.PhraseList.Remove(ph)
                MsgBox("词汇：" & ph.ToString() & "删除成功！")
                'RedrawConc()
            Else
                Trans.Rollback()
                MsgBox("词汇：" & ph.ToString() & "删除失败！详情见日志。")
            End If
        End If
    End Sub
End Class

