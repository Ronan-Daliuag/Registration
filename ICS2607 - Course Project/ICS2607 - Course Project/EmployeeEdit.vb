Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class EmployeeEdit
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter

    Dim query As String

    Dim Server As String = "server=localhost;user=root;password=admin;port=3310;database=registration"

    Public myformnum As String
    Private Sub EmployeeEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        myformnum = EmployeeHome.formnum

        sqlConn.ConnectionString = Server
        sqlConn.Open()
        query = "SELECT  FORM_NUM, concat(LAST_NAME,', ',FIRST_NAME) As Name, CERT_EMM_COMPLIANCE AS Q1, OG_SALES_INV AS Q2, CERT_COVER AS Q3, POLICE_CLEARANCE AS Q4, 
                CERT_STOCK AS Q5, PAYMENT_REF_NUM AS Q6, VEH_COLOR, PLATE_NUM from applicant inner join emission
                inner join form inner join vehicle_info where form.FORM_NUM=" & myformnum & " and form.EMM_CODE=emission.EMM_CODE AND emission.EMM_CODE=vehicle_info.EMM_CODE;"

        sqlCmd = New MySqlCommand(query, sqlConn)

        sqlRd = sqlCmd.ExecuteReader()

        sqlRd.Read()

        TB1.Text = myformnum
        TB2.Text = sqlRd("Name")
        If sqlRd("Q1") Then
            RD11.Checked = True
        Else
            RD12.Checked = True
        End If

        If sqlRd("Q2") Then
            RD21.Checked = True
        Else
            RD22.Checked = True
        End If

        If sqlRd("Q3") Then
            RD31.Checked = True
        Else
            RD32.Checked = True
        End If

        If sqlRd("Q4") Then
            RD41.Checked = True
        Else
            RD42.Checked = True
        End If

        If sqlRd("Q5") Then
            RD51.Checked = True
        Else
            RD52.Checked = True
        End If

        If sqlRd("Q6") Then
            RD61.Checked = True
        Else
            RD62.Checked = True
        End If

        TB3.Text = sqlRd("VEH_COLOR")
        TB4.Text = sqlRd("PLATE_NUM")

        sqlConn.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        sqlCmd.Connection = sqlConn
        If String.IsNullOrEmpty(TB3.Text) = False Then
            With sqlCmd
                .CommandText = "UPDATE form, emission, applicant, vehicle_info
                SET CERT_EMM_COMPLIANCE=@Q1, OG_SALES_INV=@Q2, CERT_COVER=@Q3, POLICE_CLEARANCE=@Q4, CERT_STOCK=@Q5, PAYMENT_REF_NUM=@Q6, VEH_COLOR=@VEH_COLOR
                WHERE form.FORM_NUM=" & myformnum & " and form.EMM_CODE=emission.EMM_CODE AND emission.EMM_CODE=vehicle_info.EMM_CODE;
                UPDATE form, emission Set Qualification = CASE WHEN CERT_COVER=1 and POLICE_CLEARANCE=1 and CERT_STOCK=1 and PAYMENT_REF_NUM = 1 
                and emission.CERT_EMM_COMPLIANCE = 1 and emission.OG_SALES_INV = 1 
                then '1' else '0' end where emission.EMM_CODE=form.EMM_CODE and form.FORM_NUM=" & myformnum & ";"
                .CommandType = CommandType.Text
                If RD11.Checked Then
                    .Parameters.AddWithValue("@Q1", 1)
                Else
                    .Parameters.AddWithValue("@Q1", 0)
                End If

                If RD21.Checked Then
                    .Parameters.AddWithValue("@Q2", 1)
                Else
                    .Parameters.AddWithValue("@Q2", 0)
                End If

                If RD31.Checked Then
                    .Parameters.AddWithValue("@Q3", 1)
                Else
                    .Parameters.AddWithValue("@Q3", 0)
                End If

                If RD41.Checked Then
                    .Parameters.AddWithValue("@Q4", 1)
                Else
                    .Parameters.AddWithValue("@Q4", 0)
                End If

                If RD51.Checked Then
                    .Parameters.AddWithValue("@Q5", 1)
                Else
                    .Parameters.AddWithValue("@Q5", 0)
                End If

                If RD61.Checked Then
                    .Parameters.AddWithValue("@Q6", 1)
                Else
                    .Parameters.AddWithValue("@Q6", 0)
                End If

                .Parameters.AddWithValue("@VEH_COLOR", TB3.Text)

            End With

            sqlCmd.ExecuteNonQuery()
            sqlCmd.Parameters.Clear()
            sqlConn.Close()
            EmployeeHome.Show()
        Else
            MsgBox("There is Field/s Left Empty")
        End If

        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EmployeeHome.Show()
        Me.Close()
    End Sub
End Class