Imports MySql.Data.MySqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter
    Dim query As String
    Dim Server As String = "server=localhost;user=root;password=admin;port=3310;database=registration"
    Public nameuser As String
    Public nameplaceholder

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        query = "SELECT Count(*) AS YN, APP_CODE, FIRST_NAME from account inner join applicant where applicant.USERNAME=account.USERNAME 
                    and account.USERNAME='" & TB1.Text & "' and account.USERPASS = '" & TB2.Text & "';"
        sqlCmd = New MySqlCommand(query, sqlConn)
        sqlRd = sqlCmd.ExecuteReader
        sqlRd.Read()
        If Me.TB1.Text = "employee" And Me.TB2.Text = "employee" Then
            EmployeeHome.Show()
            Me.Hide()
        ElseIf Me.TB1.Text = "admin" And Me.TB2.Text = "admin" Then
            NewAdminHome.Show()
            Me.Hide()
        Else
            If sqlRd("YN") = 1 Then
                nameuser = sqlRd("APP_CODE")
                nameplaceholder = sqlRd("FIRST_NAME")
                UserHome.Show()
                Me.Hide()
            Else
                MessageBox.Show("Incorrect Username/Password")
            End If
        End If
        TB1.Text = ""
        TB2.Text = ""

        sqlRd.Close()
        sqlConn.Close()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NewUserReg.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TB1.Text = ""
        TB2.Text = ""
    End Sub
End Class
