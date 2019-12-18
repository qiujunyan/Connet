Imports System.Data.SqlClient
Module public_module
    Public g_cnn As New SqlConnection("Data Source=localhost;Integrated Security= SSPI;Initial Catalog=Course;")
    Public g_cmd As SqlCommand
    Public g_reader As SqlDataReader
    Public g_apt As SqlDataAdapter
    Public g_course_str As String = "机器人技术基础"


    ' public变量
    Public g_node_fullpath As String
    Public g_split_notation As Char = ","
    Public g_node As TreeNode
    Function G_build_treeview(ByRef tv As TreeView)
        Try
            'cnn.Open()
            'cmd = cnn.CreateCommand
            'cmd.CommandText = "SELECT Chapter, Section, Subsection FROM Robot"
            Sql_cmd("SELECT Chapter, Section, Subsection FROM Robot")

            g_reader = g_cmd.ExecuteReader()
            Dim root As TreeNode = tv.Nodes.Add(g_course_str)

            Dim strs(2) As String
            Do While g_reader.Read()
                strs(0) = g_reader.GetString(0)
                strs(1) = g_reader.GetString(1)
                strs(2) = g_reader.GetString(2)

                Add_node(root, strs)
                'Exit Do
            Loop
            g_reader.Close()
            g_cnn.Close()

            tv.ExpandAll()
            tv.Show()

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
        Return 0
    End Function

    Function Sql_cmd(ByVal cmd_str As String)
        g_cnn.Open()
        g_cmd = g_cnn.CreateCommand
        g_cmd.CommandText = cmd_str
        Return 0
    End Function

    Function Is_dir(ByVal dir As String, ByVal strs() As String) As Boolean
        Dim path As String = g_course_str + "\"
        For i As Integer = 0 To 2
            path += strs(i)
            path += "\"
        Next

        dir = dir + "\"
        Return dir = path
    End Function
    Function Add_node(ByRef tn As TreeNode, ByVal str_list() As String)
        If str_list(0) Is Nothing Then
            Return 0
        End If

        If tn.Nodes.Count = 0 Then
            Add_n(tn, str_list)
            Return 0
        End If

        Dim cnt As Integer = 0
        For Each node As TreeNode In tn.Nodes
            If str_list(0) = node.Text Then
                Dim len As Integer = UBound(str_list)
                Dim newarray(len - 1) As String
                Array.Copy(str_list, 1, newarray, 0, len)
                Add_node(node, newarray)
            Else
                cnt += 1
            End If
        Next
        If cnt = tn.Nodes.Count() Then
            Add_n(tn, str_list)
        End If

        Return 0
    End Function

    Function Add_n(ByRef tn As TreeNode, ByVal strs() As String)
        Dim node As TreeNode = New TreeNode With {
            .Text = strs(0)
        }
        tn.Nodes.Add(node)

        Dim len As Integer = UBound(strs)
        If len = 0 Then
            Return 0
        End If

        Dim strs1(len - 1) As String
        Array.Copy(strs, 1, strs1, 0, len)

        Add_n(node, strs1)
        Return 0
    End Function
End Module
