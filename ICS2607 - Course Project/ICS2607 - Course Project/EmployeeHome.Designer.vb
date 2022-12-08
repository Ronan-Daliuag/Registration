<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EmployeeHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dashboard = New System.Windows.Forms.Label()
        Me.B3 = New System.Windows.Forms.Button()
        Me.B2 = New System.Windows.Forms.Button()
        Me.B1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RD1 = New System.Windows.Forms.RadioButton()
        Me.TB1 = New System.Windows.Forms.TextBox()
        Me.TB2 = New System.Windows.Forms.TextBox()
        Me.RD2 = New System.Windows.Forms.RadioButton()
        Me.RD3 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 22.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(242, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(501, 50)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Car Registration Dashboard"
        '
        'Dashboard
        '
        Me.Dashboard.AutoSize = True
        Me.Dashboard.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Dashboard.Location = New System.Drawing.Point(43, 75)
        Me.Dashboard.Name = "Dashboard"
        Me.Dashboard.Size = New System.Drawing.Size(148, 35)
        Me.Dashboard.TabIndex = 3
        Me.Dashboard.Text = "Dashboard:"
        '
        'B3
        '
        Me.B3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.B3.Location = New System.Drawing.Point(670, 554)
        Me.B3.Name = "B3"
        Me.B3.Size = New System.Drawing.Size(140, 58)
        Me.B3.TabIndex = 57
        Me.B3.Text = "Delete"
        Me.B3.UseVisualStyleBackColor = True
        '
        'B2
        '
        Me.B2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.B2.Location = New System.Drawing.Point(404, 554)
        Me.B2.Name = "B2"
        Me.B2.Size = New System.Drawing.Size(140, 58)
        Me.B2.TabIndex = 58
        Me.B2.Text = "Update Car Information"
        Me.B2.UseVisualStyleBackColor = True
        '
        'B1
        '
        Me.B1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.B1.Location = New System.Drawing.Point(138, 554)
        Me.B1.Name = "B1"
        Me.B1.Size = New System.Drawing.Size(140, 58)
        Me.B1.TabIndex = 59
        Me.B1.Text = "Add New Car Information"
        Me.B1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(51, 125)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.RowTemplate.Height = 29
        Me.DataGridView1.Size = New System.Drawing.Size(828, 297)
        Me.DataGridView1.TabIndex = 60
        '
        'RD1
        '
        Me.RD1.AutoSize = True
        Me.RD1.Location = New System.Drawing.Point(54, 471)
        Me.RD1.Name = "RD1"
        Me.RD1.Size = New System.Drawing.Size(101, 24)
        Me.RD1.TabIndex = 61
        Me.RD1.TabStop = True
        Me.RD1.Text = "APP_CODE"
        Me.RD1.UseVisualStyleBackColor = True
        '
        'TB1
        '
        Me.TB1.Location = New System.Drawing.Point(161, 470)
        Me.TB1.Name = "TB1"
        Me.TB1.Size = New System.Drawing.Size(162, 27)
        Me.TB1.TabIndex = 62
        '
        'TB2
        '
        Me.TB2.Location = New System.Drawing.Point(612, 471)
        Me.TB2.Name = "TB2"
        Me.TB2.Size = New System.Drawing.Size(162, 27)
        Me.TB2.TabIndex = 64
        '
        'RD2
        '
        Me.RD2.AutoSize = True
        Me.RD2.Location = New System.Drawing.Point(488, 471)
        Me.RD2.Name = "RD2"
        Me.RD2.Size = New System.Drawing.Size(110, 24)
        Me.RD2.TabIndex = 63
        Me.RD2.TabStop = True
        Me.RD2.Text = "FORM_NUM"
        Me.RD2.UseVisualStyleBackColor = True
        '
        'RD3
        '
        Me.RD3.AutoSize = True
        Me.RD3.Location = New System.Drawing.Point(488, 501)
        Me.RD3.Name = "RD3"
        Me.RD3.Size = New System.Drawing.Size(74, 24)
        Me.RD3.TabIndex = 65
        Me.RD3.TabStop = True
        Me.RD3.Text = "Delete"
        Me.RD3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(829, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 33)
        Me.Button1.TabIndex = 66
        Me.Button1.Text = "Logout"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EmployeeHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 648)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RD3)
        Me.Controls.Add(Me.TB2)
        Me.Controls.Add(Me.RD2)
        Me.Controls.Add(Me.TB1)
        Me.Controls.Add(Me.RD1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.B1)
        Me.Controls.Add(Me.B2)
        Me.Controls.Add(Me.B3)
        Me.Controls.Add(Me.Dashboard)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "EmployeeHome"
        Me.Text = "EmployeeHome"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Dashboard As Label
    Friend WithEvents B3 As Button
    Friend WithEvents B2 As Button
    Friend WithEvents B1 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents RD1 As RadioButton
    Friend WithEvents TB1 As TextBox
    Friend WithEvents TB2 As TextBox
    Friend WithEvents RD2 As RadioButton
    Friend WithEvents RD3 As RadioButton
    Friend WithEvents Button1 As Button
End Class
