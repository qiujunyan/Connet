<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_learn
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tv_learn = New System.Windows.Forms.TreeView()
        Me.btn_open_source = New System.Windows.Forms.Button()
        Me.btn_add_note = New System.Windows.Forms.Button()
        Me.ofd_select_resources = New System.Windows.Forms.OpenFileDialog()
        Me.btn_add_resources = New System.Windows.Forms.Button()
        Me.btn_del_node = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tv_learn
        '
        Me.tv_learn.Location = New System.Drawing.Point(12, 6)
        Me.tv_learn.Name = "tv_learn"
        Me.tv_learn.Size = New System.Drawing.Size(477, 432)
        Me.tv_learn.TabIndex = 0
        '
        'btn_open_source
        '
        Me.btn_open_source.Location = New System.Drawing.Point(533, 229)
        Me.btn_open_source.Name = "btn_open_source"
        Me.btn_open_source.Size = New System.Drawing.Size(124, 45)
        Me.btn_open_source.TabIndex = 1
        Me.btn_open_source.Text = "打开资源"
        Me.btn_open_source.UseVisualStyleBackColor = True
        '
        'btn_add_note
        '
        Me.btn_add_note.Location = New System.Drawing.Point(533, 32)
        Me.btn_add_note.Name = "btn_add_note"
        Me.btn_add_note.Size = New System.Drawing.Size(124, 45)
        Me.btn_add_note.TabIndex = 2
        Me.btn_add_note.Text = "增加节点"
        Me.btn_add_note.UseVisualStyleBackColor = True
        '
        'ofd_select_resources
        '
        Me.ofd_select_resources.FileName = "OpenFileDialog1"
        '
        'btn_add_resources
        '
        Me.btn_add_resources.Location = New System.Drawing.Point(533, 322)
        Me.btn_add_resources.Name = "btn_add_resources"
        Me.btn_add_resources.Size = New System.Drawing.Size(124, 45)
        Me.btn_add_resources.TabIndex = 3
        Me.btn_add_resources.Text = "添加资源"
        Me.btn_add_resources.UseVisualStyleBackColor = True
        '
        'btn_del_node
        '
        Me.btn_del_node.Location = New System.Drawing.Point(533, 125)
        Me.btn_del_node.Name = "btn_del_node"
        Me.btn_del_node.Size = New System.Drawing.Size(124, 45)
        Me.btn_del_node.TabIndex = 4
        Me.btn_del_node.Text = "删除节点"
        Me.btn_del_node.UseVisualStyleBackColor = True
        '
        'frm_learn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 450)
        Me.Controls.Add(Me.btn_del_node)
        Me.Controls.Add(Me.btn_add_resources)
        Me.Controls.Add(Me.btn_add_note)
        Me.Controls.Add(Me.btn_open_source)
        Me.Controls.Add(Me.tv_learn)
        Me.Name = "frm_learn"
        Me.Text = "课堂学习"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tv_learn As TreeView
    Friend WithEvents btn_open_source As Button
    Friend WithEvents btn_add_note As Button
    Friend WithEvents ofd_select_resources As OpenFileDialog
    Friend WithEvents btn_add_resources As Button
    Friend WithEvents btn_del_node As Button
End Class
