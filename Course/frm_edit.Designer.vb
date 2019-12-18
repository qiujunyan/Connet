<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_edit
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
        Me.tv_knowTree = New System.Windows.Forms.TreeView()
        Me.bnt_genKnowTree = New System.Windows.Forms.Button()
        Me.bnt_delKnowTree = New System.Windows.Forms.Button()
        Me.bnt_newKnowNode = New System.Windows.Forms.Button()
        Me.bnt_delKnowNode = New System.Windows.Forms.Button()
        Me.bnt_editKnowNode = New System.Windows.Forms.Button()
        Me.bnt_genConcept = New System.Windows.Forms.Button()
        Me.bnt_delConcept = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tv_knowTree
        '
        Me.tv_knowTree.Location = New System.Drawing.Point(2, 2)
        Me.tv_knowTree.Name = "tv_knowTree"
        Me.tv_knowTree.Size = New System.Drawing.Size(423, 535)
        Me.tv_knowTree.TabIndex = 0
        '
        'bnt_genKnowTree
        '
        Me.bnt_genKnowTree.Location = New System.Drawing.Point(516, 133)
        Me.bnt_genKnowTree.Name = "bnt_genKnowTree"
        Me.bnt_genKnowTree.Size = New System.Drawing.Size(225, 47)
        Me.bnt_genKnowTree.TabIndex = 1
        Me.bnt_genKnowTree.Text = "创建知识树"
        Me.bnt_genKnowTree.UseVisualStyleBackColor = True
        '
        'bnt_delKnowTree
        '
        Me.bnt_delKnowTree.Location = New System.Drawing.Point(516, 206)
        Me.bnt_delKnowTree.Name = "bnt_delKnowTree"
        Me.bnt_delKnowTree.Size = New System.Drawing.Size(225, 47)
        Me.bnt_delKnowTree.TabIndex = 2
        Me.bnt_delKnowTree.Text = "删除知识树"
        Me.bnt_delKnowTree.UseVisualStyleBackColor = True
        '
        'bnt_newKnowNode
        '
        Me.bnt_newKnowNode.Location = New System.Drawing.Point(516, 279)
        Me.bnt_newKnowNode.Name = "bnt_newKnowNode"
        Me.bnt_newKnowNode.Size = New System.Drawing.Size(225, 47)
        Me.bnt_newKnowNode.TabIndex = 3
        Me.bnt_newKnowNode.Text = "构建新知识点"
        Me.bnt_newKnowNode.UseVisualStyleBackColor = True
        '
        'bnt_delKnowNode
        '
        Me.bnt_delKnowNode.Location = New System.Drawing.Point(516, 428)
        Me.bnt_delKnowNode.Name = "bnt_delKnowNode"
        Me.bnt_delKnowNode.Size = New System.Drawing.Size(225, 47)
        Me.bnt_delKnowNode.TabIndex = 4
        Me.bnt_delKnowNode.Text = "删除知识点"
        Me.bnt_delKnowNode.UseVisualStyleBackColor = True
        '
        'bnt_editKnowNode
        '
        Me.bnt_editKnowNode.Location = New System.Drawing.Point(516, 351)
        Me.bnt_editKnowNode.Name = "bnt_editKnowNode"
        Me.bnt_editKnowNode.Size = New System.Drawing.Size(225, 47)
        Me.bnt_editKnowNode.TabIndex = 5
        Me.bnt_editKnowNode.Text = "编辑知识点"
        Me.bnt_editKnowNode.UseVisualStyleBackColor = True
        '
        'bnt_genConcept
        '
        Me.bnt_genConcept.Location = New System.Drawing.Point(446, 51)
        Me.bnt_genConcept.Name = "bnt_genConcept"
        Me.bnt_genConcept.Size = New System.Drawing.Size(155, 55)
        Me.bnt_genConcept.TabIndex = 6
        Me.bnt_genConcept.Text = "新建概念"
        Me.bnt_genConcept.UseVisualStyleBackColor = True
        '
        'bnt_delConcept
        '
        Me.bnt_delConcept.Location = New System.Drawing.Point(624, 51)
        Me.bnt_delConcept.Name = "bnt_delConcept"
        Me.bnt_delConcept.Size = New System.Drawing.Size(155, 55)
        Me.bnt_delConcept.TabIndex = 7
        Me.bnt_delConcept.Text = "删除概念"
        Me.bnt_delConcept.UseVisualStyleBackColor = True
        '
        'frm_edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 539)
        Me.Controls.Add(Me.bnt_delConcept)
        Me.Controls.Add(Me.bnt_genConcept)
        Me.Controls.Add(Me.bnt_editKnowNode)
        Me.Controls.Add(Me.bnt_delKnowNode)
        Me.Controls.Add(Me.bnt_newKnowNode)
        Me.Controls.Add(Me.bnt_delKnowTree)
        Me.Controls.Add(Me.bnt_genKnowTree)
        Me.Controls.Add(Me.tv_knowTree)
        Me.Name = "frm_edit"
        Me.Text = "frm_edit"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tv_knowTree As TreeView
    Friend WithEvents bnt_genKnowTree As Button
    Friend WithEvents bnt_delKnowTree As Button
    Friend WithEvents bnt_newKnowNode As Button
    Friend WithEvents bnt_delKnowNode As Button
    Friend WithEvents bnt_editKnowNode As Button
    Friend WithEvents bnt_genConcept As Button
    Friend WithEvents bnt_delConcept As Button
End Class
