<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_add_nodes
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
        Me.tb = New System.Windows.Forms.TextBox()
        Me.bnt_affirm = New System.Windows.Forms.Button()
        Me.dgv = New System.Windows.Forms.DataGridView()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tb
        '
        Me.tb.Location = New System.Drawing.Point(12, 11)
        Me.tb.Multiline = True
        Me.tb.Name = "tb"
        Me.tb.Size = New System.Drawing.Size(497, 119)
        Me.tb.TabIndex = 0
        Me.tb.Text = "1.2.3 按机器人性能指标分类"
        '
        'bnt_affirm
        '
        Me.bnt_affirm.Location = New System.Drawing.Point(515, 46)
        Me.bnt_affirm.Name = "bnt_affirm"
        Me.bnt_affirm.Size = New System.Drawing.Size(121, 35)
        Me.bnt_affirm.TabIndex = 1
        Me.bnt_affirm.Text = "确认"
        Me.bnt_affirm.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 136)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 27
        Me.dgv.Size = New System.Drawing.Size(624, 233)
        Me.dgv.TabIndex = 2
        '
        'frm_add_nodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 381)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.bnt_affirm)
        Me.Controls.Add(Me.tb)
        Me.KeyPreview = True
        Me.Name = "frm_add_nodes"
        Me.Text = "添加节点"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tb As TextBox
    Friend WithEvents bnt_affirm As Button
    Friend WithEvents dgv As DataGridView
End Class
