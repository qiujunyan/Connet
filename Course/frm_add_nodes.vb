Imports System.Data.SqlClient

Public Class frm_add_nodes

    Private Sub bnt_affirm_Click(sender As Object, e As EventArgs) Handles bnt_affirm.Click
        If tb.Text = "" Then
            MsgBox("请输入节点名！")
            Exit Sub
        End If

        Dim cmd_str As String = "select chapter, section, subsection from robot"
        Dim apt As New SqlDataAdapter(cmd_str, g_cnn)
        Dim ds As New DataSet
        apt.Fill(ds, "robot")
        Dim dt As DataTable = ds.Tables("robot")

        Dim path As String = g_node_fullpath
        path = g_node_fullpath + g_split_notation + tb.Text
        Dim strs(3) As String
        Split_modified(path, g_split_notation, strs)
        dt.Rows.Add(strs(1), strs(2), strs(3))

        'dgv.DataSource = ds.Tables("robot")
        Dim scb As New SqlCommandBuilder(apt)
        apt.Update(ds, "robot")

        g_node.Nodes.Add(tb.Text)

        g_cnn.Close()
        Me.Close()
    End Sub

    Function Split_modified(ByVal path As String, ByVal s As Char, ByRef strs() As String)
        Dim temp() As String = Split(path, s)
        For i = 0 To 3
            If i <= UBound(temp) Then
                strs(i) = temp(i)
            Else
                strs(i) = Nothing
            End If
        Next
        Return 0
    End Function

    Function Split_path(ByVal path As String, ByVal s As Char) As String
        Dim strs() As String = Split(path, s)
        Dim temp As String = "values("
        For i = 1 To 3
            If i <= UBound(strs) Then
                temp += strs(i)
            Else
                temp += "null"
            End If
            temp += ","
        Next
        temp = Microsoft.VisualBasic.Left(temp, temp.Length - 1) + ")"
        Return temp
    End Function

End Class