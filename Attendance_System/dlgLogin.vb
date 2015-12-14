Imports System.Windows.Forms

Public Class dlgLogin

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        AxFpLibXCapture1.MinutiaeMode = 512
        AxFpLibXCapture1.CodeName = 1

        AxFpLibXCapture1.Clear()
        AxFpLibXCapture1.Refresh()

        AxFpLibXCapture1.BeginInit()
        Dim result As Boolean
        result = AxFpLibXCapture1.Capture

        Dim capturesecugendata() As Byte
        ReDim capturesecugendata(AxFpLibXCapture1.MinutiaeSize)

        AxFpLibXCapture1.GetMinutiaeData(capturesecugendata)


        Dim objData As New InterNICEntities()
        Dim lstUsers = objData.sp_GetUserFP().ToList()

        Dim isMatched As Boolean = False

        For Each user As sp_GetUserFP_Result In lstUsers
            isMatched = AxFpLibXVerify1.Verify(user.thumb_raw, capturesecugendata)
            If isMatched = True Then
                If user.designation = "DIO" Or user.designation = "DIA" Then
                    'MessageBox.Show("Welcome " & user.fullName & " !!")
                    AxFpLibXCapture1.Clear()
                    AxFpLibXCapture1.Refresh()
                    AxFpLibXCapture1.EndInit()
                    AxFpLibXVerify1.Refresh()
                    frmNotification.NotifyIcon1.Visible = True
                    frmNotification.NotifyIcon1.ShowBalloonTip(500)
                    frmNotification.Hide()
                    MainForm.Show()
                    Me.Close()
                    Exit Sub
                Else
                    MessageBox.Show("Sorry " & user.fullName & "!! Its restricted area.")
                End If
                Exit For
            End If
        Next
        If isMatched = False Then
            MessageBox.Show("Details not found. Please try again")
        End If

        AxFpLibXCapture1.Clear()
        AxFpLibXCapture1.Refresh()
        AxFpLibXCapture1.EndInit()
        AxFpLibXVerify1.Refresh()

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
