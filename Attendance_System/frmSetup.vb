Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Reflection
Imports System.IO
Imports AMSSetting

Public Class frmSetup

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim myConn As SqlConnection
        Dim myCmd As SqlCommand
        Dim myReader As SqlDataReader
        Try
            myConn = New SqlConnection("Data Source=" & txtHost.Text.Trim() & ";Initial Catalog=" & txtDatabase.Text.Trim() & ";Persist Security Info=True;user id=" & txtUserName.Text.Trim() & ";password=" & txtPassword.Text.Trim() & ";")
            myCmd = myConn.CreateCommand
            myCmd.CommandText = "Select top 1 * from UserFP"
            myConn.Open()
            myReader = myCmd.ExecuteReader()
            If myReader.HasRows = False Then
                If SaveConfiguration() = True Then                                                            
                    MessageBox.Show("Initial Setup has completed. Please restart the application.", "Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
            myReader.Close()
            myConn.Close()
        Catch ex As Exception
            myConn.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function SaveConfiguration() As Boolean
        Try
            Dim value As String = "Data Source=" & txtHost.Text.Trim() & ";Initial Catalog=" & txtDatabase.Text.Trim() & ";Persist Security Info=True;user id=" & txtUserName.Text.Trim() & ";password=" & txtPassword.Text.Trim() & ";"
            Dim valueEntiry As String = "metadata=res://*/DataModel.csdl|res://*/DataModel.ssdl|res://*/DataModel.msl;provider=System.Data.SqlClient;provider connection string='" & value & "MultipleActiveResultSets=True;App=EntityFramework;'"

            Dim configPath As String = Path.Combine(System.Environment.CurrentDirectory, "Attendance_System.exe")
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(configPath)

            ''connection string for InterNICDb        
            Dim connStringSetting As ConnectionStringSettings = New ConnectionStringSettings()
            connStringSetting.ConnectionString = value

            ''connection string for Entity model        
            Dim connStringSettingEntity As ConnectionStringSettings = New ConnectionStringSettings()
            connStringSettingEntity.ConnectionString = valueEntiry

            ''connection string for Initial Setup      
            Dim connInitialSetup As ConnectionStringSettings = New ConnectionStringSettings()
            connInitialSetup.ConnectionString = "1"


            If IsNothing(ConfigurationManager.ConnectionStrings) Then
                config.ConnectionStrings.ConnectionStrings.Add(connStringSetting)
                config.ConnectionStrings.ConnectionStrings.Add(connStringSettingEntity)
                config.ConnectionStrings.ConnectionStrings.Add(connInitialSetup)
            Else
                config.ConnectionStrings.ConnectionStrings("InterNICDb").ConnectionString = value
                config.ConnectionStrings.ConnectionStrings("InterNICEntities").ConnectionString = valueEntiry
                config.ConnectionStrings.ConnectionStrings("isInitialSetup").ConnectionString = "1"
            End If
            config.Save()
            ConfigurationManager.RefreshSection("connectionStrings")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
        
    End Function

    Private Sub frmSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtHost.Focus()
        
    End Sub
End Class