Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class NewAdminUpdate
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter

    Dim query As String

    Dim Server As String = "server=localhost;user=root;password=admin;port=3310;database=registration"

    Public myappnum As String
    Private Sub NewAdminUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myappnum = NewAdminHome.appnum
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        query = "Select FIRST_NAME, MID_NAME, LAST_NAME, SEX, ADDRESS, GARAGE, CONT_NUM As 'Phone #', BRANCH_CODE
	from applicant where APP_CODE=" & myappnum & ";"

        sqlCmd = New MySqlCommand(query, sqlConn)

        sqlRd = sqlCmd.ExecuteReader()

        sqlRd.Read()

        LB1.Text = myappnum
        TB1.Text = sqlRd("FIRST_NAME")
        TB2.Text = sqlRd("MID_NAME")
        TB3.Text = sqlRd("LAST_NAME")
        TB4.Text = sqlRd("SEX")
        TB5.Text = sqlRd("ADDRESS")
        If sqlRd("GARAGE") Then
            RD1.Checked = True
        Else
            RD2.Checked = True
        End If

        TB6.Text = sqlRd("Phone #")
        TB7.Text = sqlRd("BRANCH_CODE")

        sqlConn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        sqlCmd.Connection = sqlConn

        If String.IsNullOrEmpty(TB1.Text) Or
           String.IsNullOrEmpty(TB2.Text) Or
           String.IsNullOrEmpty(TB3.Text) Or
           String.IsNullOrEmpty(TB4.Text) Or
           String.IsNullOrEmpty(TB5.Text) Or
           String.IsNullOrEmpty(TB6.Text) Or
           String.IsNullOrEmpty(TB7.Text) Then
            MsgBox("There is Field/s Left Empty")
        Else

            With sqlCmd
            .CommandText = "UPDATE applicant set FIRST_NAME=@FIRST_NAME, MID_NAME=@MID_NAME, LAST_NAME=@LAST_NAME, SEX=@SEX, ADDRESS=@ADDRESS, GARAGE=@G1, 
                    CONT_NUM=@CONT_NUM , BRANCH_CODE=@BRANCH_CODE where APP_CODE= " & LB1.Text & ";"
            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@FIRST_NAME", TB1.Text)
            .Parameters.AddWithValue("@MID_NAME", TB2.Text)
            .Parameters.AddWithValue("@LAST_NAME", TB3.Text)
            .Parameters.AddWithValue("@SEX", TB4.Text)
            .Parameters.AddWithValue("@ADDRESS", TB5.Text)

            If RD1.Checked Then
            .Parameters.AddWithValue("@G1", 1)
            Else
            .Parameters.AddWithValue("@G1", 0)
            End If

            .Parameters.AddWithValue("@CONT_NUM", TB6.Text)
            .Parameters.AddWithValue("@BRANCH_CODE", TB7.Text)
            End With
            sqlCmd.ExecuteNonQuery()
            sqlCmd.Parameters.Clear()
            NewAdminHome.Show()
            Me.Close()
        End IF
        sqlConn.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Applicant Information not Updated")
        NewAdminHome.Show()
        Me.Close()
    End Sub
End Class