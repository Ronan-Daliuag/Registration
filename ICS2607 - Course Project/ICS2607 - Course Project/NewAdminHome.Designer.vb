<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewAdminHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TB1 = New System.Windows.Forms.TextBox()
        Me.RD1 = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.B1 = New System.Windows.Forms.Button()
        Me.B2 = New System.Windows.Forms.Button()
        Me.B3 = New System.Windows.Forms.Button()
        Me.Dashboard = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TB1
        '
        Me.TB1.Location = New System.Drawing.Point(417, 477)
        Me.TB1.Name = "TB1"
        Me.TB1.Size = New System.Drawing.Size(162, 27)
        Me.TB1.TabIndex = 73
        '
        'RD1
        '
        Me.RD1.AutoSize = True
        Me.RD1.Location = New System.Drawing.Point(260, 477)
        Me.RD1.Name = "RD1"
        Me.RD1.Size = New System.Drawing.Size(101, 24)
        Me.RD1.TabIndex = 72
        Me.RD1.TabStop = True
        Me.RD1.Text = "APP_CODE"
        Me.RD1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(47, 125)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(828, 297)
        Me.DataGridView1.TabIndex = 71
        '
        'B1
        '
        Me.B1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.B1.Location = New System.Drawing.Point(125, 547)
        Me.B1.Name = "B1"
        Me.B1.Size = New System.Drawing.Size(140, 58)
        Me.B1.TabIndex = 70
        Me.B1.Text = "Add New User"
        Me.B1.UseVisualStyleBackColor = True
        '
        'B2
        '
        Me.B2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.B2.Location = New System.Drawing.Point(391, 547)
        Me.B2.Name = "B2"
        Me.B2.Size = New System.Drawing.Size(140, 58)
        Me.B2.TabIndex = 69
        Me.B2.Text = "Update User Information"
        Me.B2.UseVisualStyleBackColor = True
        '
        'B3
        '
        Me.B3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.B3.Location = New System.Drawing.Point(657, 547)
        Me.B3.Name = "B3"
        Me.B3.Size = New System.Drawing.Size(140, 58)
        Me.B3.TabIndex = 68
        Me.B3.Text = "Delete"
        Me.B3.UseVisualStyleBackColor = True
        '
        'Dashboard
        '
        Me.Dashboard.AutoSize = True
        Me.Dashboard.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Dashboard.Location = New System.Drawing.Point(39, 75)
        Me.Dashboard.Name = "Dashboard"
        Me.Dashboard.Size = New System.Drawing.Size(148, 35)
        Me.Dashboard.TabIndex = 67
        Me.Dashboard.Text = "Dashboard:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(293, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(337, 50)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Admin Dashboard"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(830, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 33)
        Me.Button1.TabIndex = 74
        Me.Button1.Text = "Logout"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NewAdminHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 649)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TB1)
        Me.Controls.Add(Me.RD1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B1)
        Me.Controls.Add(Me.B2)
        Me.Controls.Add(Me.B3)
        Me.Controls.Add(Me.Dashboard)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NewAdminHome"
        Me.Text = "NewAdminHome"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RD3 As RadioButton
    Friend WithEvents TB1 As TextBox
    Friend WithEvents RD1 As RadioButton
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents B1 As Button
    Friend WithEvents B2 As Button
    Friend WithEvents B3 As Button
    Friend WithEvents Dashboard As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
End Class
