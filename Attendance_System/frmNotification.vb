Imports System.IO
Imports System.Configuration

Public Class frmNotification
    Public Sub ShowNotification()
        Try
            Dim objData As New InterNICEntities()
            Dim lstNotifications = objData.sp_GetNotification().ToList()
            If Not IsNothing(lstNotifications) And lstNotifications.Count > 0 Then
                txtNotify.Text = ""
                Dim i As Integer = 1
                For Each notify As sp_GetNotification_Result In lstNotifications
                    If notify.timeElapse > 120 Then
                        Dim hr As Integer = 0
                        Dim min As Integer = 0
                        hr = Math.Floor(CDbl(notify.timeElapse) / 60)
                        min = notify.timeElapse - (hr * 60)
                        txtNotify.Text = txtNotify.Text & i.ToString() & ". " & notify.fullName & " since last " & hr.ToString().PadLeft(2, "0") & ":" & min.ToString().PadLeft(2, "0") & " Hrs" & Environment.NewLine
                        i = i + 1
                        If i > 5 Then
                            txtNotify.ScrollBars = ScrollBars.Vertical
                        Else
                            txtNotify.ScrollBars = ScrollBars.None
                        End If
                    End If
                Next
            Else
                txtNotify.ScrollBars = ScrollBars.None
            End If
            Dim lstBirthday = objData.sp_GetBirthdayList().ToList()
            If Not IsNothing(lstBirthday) Then
                lblBirthday.Text = ""
                Dim i As Integer = 1
                For Each notify As sp_GetBirthdayList_Result In lstBirthday
                    lblBirthday.Text = lblBirthday.Text & i.ToString() & ". Happy Birthday " & notify.fullName & " (" & notify.designation & ")"
                    i = i + 1
                Next
            End If
        Catch ex As Exception
            If ex.Source = "EntityFramework" Then
                txtNotify.Text = "Could not connect to server"
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub btnPresence_Click(sender As Object, e As EventArgs) Handles btnPresence.Click
        fpDialog.Show()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        ShowNotification()
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub frmNotification_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If (FormWindowState.Minimized = Me.WindowState) Then
            NotifyIcon1.Visible = True
            NotifyIcon1.ShowBalloonTip(500)
            Me.Hide()
        ElseIf FormWindowState.Normal = Me.WindowState Then
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Try
            Dim objData As New InterNICEntities()
            Dim lstUsers = objData.sp_GetUserFP().ToList()
            If IsNothing(lstUsers) Or lstUsers.Count <= 0 Then
                Me.Hide()
                MainForm.Show()
            Else
                dlgLogin.Show()
            End If
        Catch ex As Exception
            CheckForSetup()
        End Try
    End Sub
    Private Sub Checkvalidity()
        Dim licence As AMSSetting.Settings
        Dim licManager As AMSSetting.Manager = New AMSSetting.Manager()
        licence = licManager.GetLicence()
        If licence.isSuccess = False Then
            MessageBox.Show(licence.StatusMsg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Application.Exit()
        ElseIf (DateTime.Now > licence.LicenceUpTo) Then
            MessageBox.Show("Application licance expired", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Application.Exit()
        End If
    End Sub
    Private Sub frmNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Checkvalidity()
        Try
            If Not Application.ExecutablePath.ToString().Contains("shiwanshu") Then
                Dim rkApp = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", True)
                If rkApp.GetValue("AttendanceManager") Is Nothing Then
                    rkApp.SetValue("AttendanceManager", Application.ExecutablePath.ToString())
                End If
            End If
        Catch
        End Try
        ShowNotification()

    End Sub
    Private Sub CheckForSetup()
        Try
            Dim configPath As String = Path.Combine(System.Environment.CurrentDirectory, "Attendance_System.exe")
            Dim config As Configuration = ConfigurationManager.OpenExeConfiguration(configPath)
            If IsNothing(ConfigurationManager.ConnectionStrings) = False Then
                Dim isInitialSetup As String = config.ConnectionStrings.ConnectionStrings("isInitialSetup").ConnectionString
                If isInitialSetup = "0" Then
                    Me.Hide()
                    frmSetup.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(500)
        Me.WindowState = FormWindowState.Minimized
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ShowNotification()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If txtNotify.Text.Trim.Contains("1.") Then
            ShowNotification()
            Me.Show()
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub
End Class