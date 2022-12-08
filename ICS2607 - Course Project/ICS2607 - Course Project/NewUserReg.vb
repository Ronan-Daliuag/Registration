Imports MySql.Data.MySqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.Win32
Imports System.Data.SqlClient
Public Class NewUserReg
    Dim sqlConn As New MySqlConnection
    Dim sqlCmd As New MySqlCommand
    Dim sqlRd As MySqlDataReader
    Dim sqlDt As New DataTable
    Dim dtA As New MySqlDataAdapter
    Dim str = EmployeeHome.appnum
    Dim query As String
    Dim f1, f2, f3, f4, f5, f6, f7 As String

    Dim Server As String = "server=localhost;user=root;password=admin;port=3310;database=registration"
    Private Sub NewUserReg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RD12.Checked = True
        RD22.Checked = True
        RD32.Checked = True
        RD42.Checked = True
        RD52.Checked = True
        RD62.Checked = True
        RD72.Checked = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sqlConn.ConnectionString = Server
        sqlConn.Open()
        sqlCmd.Connection = sqlConn

        'if some field is blank
        If String.IsNullOrEmpty(USERNAME.Text) Or
           String.IsNullOrEmpty(PASSWORD.Text) Or
           String.IsNullOrEmpty(FIRST_NAME.Text) Or
           String.IsNullOrEmpty(LAST_NAME.Text) Or
           String.IsNullOrEmpty(BDAY.Text) Or
           String.IsNullOrEmpty(SEX.Text) Or
           String.IsNullOrEmpty(ADDRESS.Text) Or
           String.IsNullOrEmpty(CONT_NUM.Text) Or
           String.IsNullOrEmpty(BRANCH_CODE.Text) Or
           String.IsNullOrEmpty(TIN.Text) Or
           String.IsNullOrEmpty(DL_NUM.Text) Or
           String.IsNullOrEmpty(DL_DESC.Text) Or
           String.IsNullOrEmpty(DL_CODE.Text) Or
           String.IsNullOrEmpty(EXP_DATE.Text) Or
           String.IsNullOrEmpty(CM_CODE.Text) Or
           String.IsNullOrEmpty(VIN.Text) Or
           String.IsNullOrEmpty(VEH_CLASS.Text) Or
           String.IsNullOrEmpty(VEH_COLOR.Text) Then
            MsgBox("There is Field/s Left Empty")
        Else

            query = "SELECT COUNT(1) as YN FROM account WHERE USERNAME = '" & USERNAME.Text & "';"
            sqlCmd = New MySqlCommand(query, sqlConn)
            sqlRd = sqlCmd.ExecuteReader
            sqlRd.Read()

            Dim exist As Int16
            exist = sqlRd("YN")
            sqlRd.Close()
            sqlConn.Close()
            If exist = 0 Then
                sqlConn.ConnectionString = Server
                sqlConn.Open()

                query = "SELECT COUNT(1) as YN FROM vehicle_info WHERE VIN = '" & VIN.Text & "';"
                sqlCmd = New MySqlCommand(query, sqlConn)
                sqlRd = sqlCmd.ExecuteReader
                sqlRd.Read()

                Dim exist1 As Int16
                exist1 = sqlRd("YN")
                sqlRd.Close()
                sqlConn.Close()

                If exist1 = 0 Then
                    sqlConn.ConnectionString = Server
                    sqlConn.Open()
                    sqlCmd.Connection = sqlConn
                    Try
                        With sqlCmd
                            .CommandText = "
            SET FOREIGN_KEY_CHECKS=0; 
            INSERT INTO driver_license(DL_NUM, DL_DESC, DL_CODES, EXP_DATE)
	            VALUES(@DL_NUM, @DL_DESC, @DL_CODE, @EXP_DATE);
    
            INSERT INTO account(USERNAME,USERPASS, acct_type)
	            VALUES(@USERNAME,@PASSWORD,'user');

            INSERT INTO applicant(LAST_NAME, FIRST_NAME, MID_NAME, BIRTHDAY, AGE, SEX ,ADDRESS , GARAGE , CONT_NUM, BRANCH_CODE, REGION_CODE, USERNAME,DL_NUM)
	            VALUES(@LAST_NAME, @FIRST_NAME, @MID_NAME, @BIRTHDAY, (DATE_FORMAT(FROM_DAYS(DATEDIFF(NOW(),BIRTHDAY)), '%Y') + 0), 
                @SEX ,@ADDRESS , @G1 ,@CONT_NUM, @BRANCH_CODE, (SELECT region.REGION_CODE FROM registrar inner join region where BRANCH_CODE=@BRANCH_CODE and region.REGION_CODE=registrar.REGION_CODE), @USERNAME, @DL_NUM);
                            
            INSERT INTO emission(CERT_EMM_COMPLIANCE, OG_SALES_INV)
	            VALUES(@Q1,@Q2);
    
            INSERT INTO vehicle_info(VIN, VEH_CLASS, VEH_COLOR,  APP_CODE, CM_CODE, EMM_CODE)
	            VALUES(@VIN, @VEH_CLASS, @VEH_COLOR,  (SELECT APP_CODE FROM applicant ORDER BY APP_CODE DESC LIMIT 1)  , @CM_CODE, (SELECT EMM_CODE FROM emission ORDER BY EMM_CODE DESC LIMIT 1)) ;
    
            INSERT INTO form(CERT_COVER, POLICE_CLEARANCE, CERT_STOCK, PAYMENT_REF_NUM, TIN_NUM, DATE_REG, EMM_CODE, BRANCH_CODE,APP_CODE)
	            VALUES(@Q3,@Q4,@Q5,@Q6,@TIN,CURRENT_DATE(),(SELECT EMM_CODE FROM emission ORDER BY EMM_CODE DESC LIMIT 1  ),@BRANCH_CODE, (SELECT APP_CODE FROM applicant ORDER BY APP_CODE DESC LIMIT 1));

            UPDATE form, emission Set Qualification = CASE WHEN CERT_COVER=1 and POLICE_CLEARANCE=1 and CERT_STOCK=1 and PAYMENT_REF_NUM = 1 
                and emission.CERT_EMM_COMPLIANCE = 1 and emission.OG_SALES_INV = 1 
                then '1' else '0' end where emission.EMM_CODE=form.EMM_CODE;

            UPDATE vehicle_info, applicant, registrar, emission, form
                set PLATE_NUM = 
	                CASE registrar.REGION_CODE
		                WHEN 'Region 1' THEN  concat('AAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 2' THEN  concat('BAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 3' THEN  concat('CAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'CALABARZON' THEN  concat('DAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'MIMAROPA' THEN  concat('EAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 5' THEN  concat('FAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 6' THEN  concat('GAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 7' THEN  concat('HAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 8' THEN  concat('IAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 9' THEN  concat('JAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 10' THEN  concat('KAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 11' THEN  concat('LAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 12' THEN  concat('MAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'Region 13' THEN  concat('NAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'NCR' THEN  concat('OAA ','0',vehicle_info.EMM_CODE)
                        WHEN 'CAR' THEN  concat('PAA ','0',vehicle_info.EMM_CODE)
	                END
                WHERE vehicle_info.APP_CODE=applicant.APP_CODE and vehicle_info.EMM_CODE=emission.EMM_CODE 
                and form.EMM_CODE=emission.EMM_CODE and form.BRANCH_CODE=registrar.BRANCH_CODE;   "


                            .CommandType = CommandType.Text

                            .Parameters.AddWithValue("@USERNAME", USERNAME.Text)
                            .Parameters.AddWithValue("@PASSWORD", PASSWORD.Text)
                            .Parameters.AddWithValue("@FIRST_NAME", FIRST_NAME.Text)
                            .Parameters.AddWithValue("@MID_NAME", MID_NAME.Text)
                            .Parameters.AddWithValue("@LAST_NAME", LAST_NAME.Text)
                            .Parameters.AddWithValue("@BIRTHDAY", BDAY.Text)
                            .Parameters.AddWithValue("@SEX", SEX.Text)
                            .Parameters.AddWithValue("@ADDRESS", ADDRESS.Text)

                            If RD11.Checked Then
                                .Parameters.AddWithValue("@G1", 1)
                            Else
                                .Parameters.AddWithValue("@G1", 0)
                            End If

                            .Parameters.AddWithValue("@CONT_NUM", CONT_NUM.Text)
                            .Parameters.AddWithValue("@BRANCH_CODE", BRANCH_CODE.Text)
                            .Parameters.AddWithValue("@TIN", TIN.Text)

                            .Parameters.AddWithValue("@DL_NUM", DL_NUM.Text)
                            .Parameters.AddWithValue("@DL_DESC", DL_DESC.Text)
                            .Parameters.AddWithValue("@DL_CODE", DL_CODE.Text)
                            .Parameters.AddWithValue("@EXP_DATE", EXP_DATE.Text)

                            .Parameters.AddWithValue("@CM_CODE", CM_CODE.Text)
                            .Parameters.AddWithValue("@VIN", VIN.Text)
                            .Parameters.AddWithValue("@VEH_CLASS", VEH_CLASS.Text)
                            .Parameters.AddWithValue("@VEH_COLOR", VEH_COLOR.Text)


                            If RD21.Checked Then
                                .Parameters.AddWithValue("@Q1", 1)
                            Else
                                .Parameters.AddWithValue("@Q1", 0)
                            End If

                            If RD31.Checked Then
                                .Parameters.AddWithValue("@Q2", 1)
                            Else
                                .Parameters.AddWithValue("@Q2", 0)
                            End If

                            If RD41.Checked Then
                                .Parameters.AddWithValue("@Q3", 1)
                            Else
                                .Parameters.AddWithValue("@Q3", 0)
                            End If

                            If RD51.Checked Then
                                .Parameters.AddWithValue("@Q4", 1)
                            Else
                                .Parameters.AddWithValue("@Q4", 0)
                            End If

                            If RD61.Checked Then
                                .Parameters.AddWithValue("@Q5", 1)
                            Else
                                .Parameters.AddWithValue("@Q5", 0)
                            End If

                            If RD71.Checked Then
                                .Parameters.AddWithValue("@Q6", 1)
                            Else
                                .Parameters.AddWithValue("@Q6", 0)
                            End If
                        End With
                        sqlCmd.ExecuteNonQuery()
                        sqlCmd.Parameters.Clear()
                        MsgBox("User Registered")

                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "MySQL Connector", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        MsgBox("Vehicle Not Added")
                        UserCarHome.Show()
                        Me.Close()
                    Finally
                        Form1.Show()
                        Me.Close()
                    End Try
                Else
                    MsgBox("The car is already Registered")
                End If
            Else
                MsgBox("Username already exist")
            End If
        End If
        sqlConn.Close()
    End Sub
End Class