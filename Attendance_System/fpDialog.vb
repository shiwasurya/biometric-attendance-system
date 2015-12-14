Imports System.Windows.Forms

Public Class fpDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                objData.sp_SubmitPresence(user.userID)
                MessageBox.Show("Thank you, " & user.fullName & ".")
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
        frmNotification.ShowNotification()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim status As Boolean = False
        Try
            status = verifyFP(1)    ' for secugen device 
            If status = False Then
                status = verifyFP(2)    'for mantra device
            End If
            If status = False Then
                status = verifyFP(3)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function verifyFP(deviceCode As Integer) As Boolean
        Dim flag As Boolean = False
        Try
            AxFpLibXCapture1.MinutiaeMode = 512
            AxFpLibXCapture1.CodeName = deviceCode

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
                    objData.sp_SubmitPresence(user.userID)
                    Timer1.Enabled = False
                    flag = True
                    MessageBox.Show("Thank you, " & user.fullName & ".")
                    Exit For
                End If
            Next
            If isMatched = False Then
                MessageBox.Show("Details not found. Please try again")
                flag = False
                Me.Close()                
            End If

            AxFpLibXCapture1.Clear()
            AxFpLibXCapture1.Refresh()
            AxFpLibXCapture1.EndInit()
            AxFpLibXVerify1.Refresh()
            frmNotification.ShowNotification()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Private Sub fpDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True        
    End Sub
End Class
