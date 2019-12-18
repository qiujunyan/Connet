Imports Connet

Public Class start
    Private Sub start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Server.LoadAllServer() Then
            MsgBox("没有找到相关知识，系统退出！")
            End
        End If

        Left = GetSetting("ConceptualNetwork", "WindowState", "Left", 0)
        If Left < 0 Then Left = 0
        Top = GetSetting("ConceptualNetwork", "WindowState", "Top", 0)
        If Top < 0 Then Top = 0
        Width = GetSetting("ConceptualNetwork", "WindowState", "Width", 1024)
        Height = GetSetting("ConceptualNetwork", "WindowState", "Height", 768)

    End Sub

    Private Sub start_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting("ConceptualNetwork", "WindowState", "Left", Left.ToString())
        SaveSetting("ConceptualNetwork", "WindowState", "Top", Top.ToString())
        SaveSetting("ConceptualNetwork", "WindowState", "Width", Width.ToString())
        SaveSetting("ConceptualNetwork", "WindowState", "Height", Height.ToString())
    End Sub

    Private Sub ts_edit_Click(sender As Object, e As EventArgs) Handles ts_edit.Click
        Dim frm As New frm_edit
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ts_learn_Click(sender As Object, e As EventArgs) Handles ts_learn.Click
        Dim frm As New frm_learn
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class
