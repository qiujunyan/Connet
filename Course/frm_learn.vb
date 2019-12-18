Imports System.Data.SqlClient
Imports System.IO.Path

Public Class frm_learn
    Inherits System.Windows.Forms.Form
    Private Sub Frm_learn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'cnn.Open()
            'cmd = cnn.CreateCommand
            'cmd.CommandText = "SELECT Chapter, Section, Subsection FROM Robot"
            Sql_cmd("SELECT Chapter, Section, Subsection FROM Robot")

            g_reader = g_cmd.ExecuteReader()
            Dim root As TreeNode = tv_learn.Nodes.Add(g_course_str)

            Dim strs(2) As String
            Do While g_reader.Read()
                For i As Integer = 0 To 2
                    Try
                        strs(i) = g_reader.GetString(i)
                    Catch ex As Exception
                        ReDim Preserve strs(i - 1)
                        Exit For
                    End Try
                Next
                Add_node(root, strs)
            Loop
            g_reader.Close()
            g_cnn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        tv_learn.ExpandAll()
        tv_learn.Show()
    End Sub

    Private Sub Btn_open_source_Click(sender As Object, e As EventArgs) Handles btn_open_source.Click
        Dim cur_node As TreeNode = tv_learn.SelectedNode()
        If cur_node.Level <= 2 Then
            MsgBox("请重新选择")
            Exit Sub
        End If
        Dim path As String = cur_node.FullPath()

        Sql_cmd("SELECT Chapter, Section, Subsection, Dir FROM Robot")
        g_reader = g_cmd.ExecuteReader()
        Dim strs(3) As String
        Do While g_reader.Read()
            strs(0) = g_reader.GetString(0)
            strs(1) = g_reader.GetString(1)
            strs(2) = g_reader.GetString(2)
            strs(3) = g_reader.GetString(3)

            If Is_dir(path, strs) Then
                Shell("explorer " + strs(3), 1)
            End If
        Loop
        g_cnn.Close()
    End Sub

    Private Sub Btn_add_note_Click(sender As Object, e As EventArgs) Handles btn_add_note.Click
        g_node = tv_learn.SelectedNode()
        If g_node.Level = 3 Then
            MsgBox("无法增加节点， 请选择上层节点！")
            Exit Sub
        End If
        tv_learn.PathSeparator = g_split_notation
        g_node_fullpath = g_node.FullPath()

        frm_add_nodes.Show()
    End Sub

    Private Sub Btn_add_resources_Click(sender As Object, e As EventArgs) Handles btn_add_resources.Click
        ofd_select_resources.Title = "打开文件"
        ofd_select_resources.ShowHelp = True
        ofd_select_resources.Filter = "文本文件（*txt）|*.txt|所有文件(*.*)|*.*"
        ofd_select_resources.FilterIndex = 1
        ofd_select_resources.RestoreDirectory = True
        ofd_select_resources.InitialDirectory = "F:\01_UCAS\05_task\Course\resource"
        ofd_select_resources.Multiselect = True
        ofd_select_resources.ShowDialog()

        Dim path As String = GetFullPath(ofd_select_resources.FileName)

    End Sub

    Private Sub Btn_del_node_Click(sender As Object, e As EventArgs) Handles btn_del_node.Click
        g_node = tv_learn.SelectedNode()
        g_node.Remove()

    End Sub
End Class