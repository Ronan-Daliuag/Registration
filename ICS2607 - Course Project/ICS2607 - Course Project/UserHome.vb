Public Class UserHome

    Dim str = Form1.nameplaceholder

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UserCarHome.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UserCarAdd.Show()
        Me.Close()
    End Sub

    Private Sub UserHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LB1.Text = "Welcome, " + str
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()
    End Sub
End Class