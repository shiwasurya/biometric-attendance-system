Imports System.Object
Imports System.Management
Imports System.Net.Mail

Public Class Form1
    Dim m_ImageWidth As Integer
    Dim m_ImageHeight As Integer
   

    Private Sub btnCapture_Click(sender As Object, e As EventArgs) Handles btnCapture.Click
        Dim RowData_Left() As Byte
        Dim m_ImageData_Left() As Byte
        Dim StrData_Left As String

        AxFpLibXCapture1.MinutiaeMode = 512
        AxFpLibXCapture1.CodeName = 1

        AxFpLibXCapture1.Clear()
        AxFpLibXCapture1.Refresh()

        AxFpLibXCapture1.BeginInit()
        Dim result As Boolean
        result = AxFpLibXCapture1.Capture

        ReDim RowData_Left(AxFpLibXCapture1.MinutiaeSize)
        ReDim m_ImageData_Left(AxFpLibXCapture1.ImageSize)

        If Not AxFpLibXCapture1.GetImageData(m_ImageData_Left) Then
            MessageBox.Show(AxFpLibXCapture1.ErrorString, "Error", MessageBoxButtons.OK)
            Exit Sub
        End If
        DrawImage(m_ImageData_Left, picBox)

        If Not AxFpLibXCapture1.GetMinutiaeData(RowData_Left) Then
            MessageBox.Show(AxFpLibXCapture1.ErrorString, "Error", MessageBoxButtons.OK)
            Exit Sub
        End If
        StrData_Left = AxFpLibXCapture1.MinTextData

        Dim fstream1 As New System.IO.MemoryStream
        picBox.Image.Save(fstream1, System.Drawing.Imaging.ImageFormat.Jpeg)
        ' publicVar.thumbImagedata = CType(fstream1.ToArray(), Byte())
        Dim objData As New InterNICEntities()
        objData.sp_UpdateUserFP(5, m_ImageData_Left, RowData_Left)
        MessageBox.Show("Data captured")
    End Sub
    Private Sub DrawImage(ByVal imgData() As Byte, ByVal picBox As PictureBox)

        Dim colorval As Int32
        Dim bmp As Bitmap
        Dim i, j As Int32

        bmp = New Bitmap(m_ImageWidth, m_ImageHeight)
        picBox.Image = bmp

        For i = 0 To bmp.Width - 1
            For j = 0 To bmp.Height - 1
                If (j * m_ImageWidth) + i < imgData.Length Then
                    colorval = imgData((j * m_ImageWidth) + i)
                    bmp.SetPixel(i, j, Color.FromArgb(colorval, colorval, colorval))
                End If
            Next j
        Next i

        picBox.Refresh()

    End Sub
    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click

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
        Label1.Text = "Total Record: " & lstUsers.Count


        Dim isMatched As Boolean = False

        For Each user As sp_GetUserFP_Result In lstUsers
            isMatched = AxFpLibXVerify1.Verify(user.thumb_raw, capturesecugendata)
            If isMatched = True Then
                MessageBox.Show("Welcome : " & user.fullName)
                Exit For
                Label1.Text = Label1.Text & user.fullName & Environment.NewLine
            End If
        Next
        If isMatched = False Then
            MessageBox.Show("Not found")
        End If

        AxFpLibXCapture1.Clear()
        AxFpLibXCapture1.Refresh()
        AxFpLibXCapture1.EndInit()
        AxFpLibXVerify1.Refresh()
        Label1.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_ImageWidth = 258
        m_ImageHeight = 336

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim moReturn As Management.ManagementObjectCollection

        Dim moSearch As Management.ManagementObjectSearcher

        Dim mo As Management.ManagementObject

        moSearch = New Management.ManagementObjectSearcher("Select * from Win32_USBControllerDevice")

        moReturn = moSearch.Get

        For Each mo In moReturn

            Dim moReturnDevice As Management.ManagementObjectCollection

            Dim moSearchDevice As Management.ManagementObjectSearcher

            Dim moDevice As Management.ManagementObject

            Dim strDeviceName As String = mo("Dependent").ToString.Replace(""""c, "")

            Dim strDevice As String = strDeviceName.Substring(strDeviceName.IndexOf("=") + 1)

            moSearchDevice = New Management.ManagementObjectSearcher("Select * From Win32_PnPEntity Where DeviceID = '" & strDevice & "'")

            moReturnDevice = moSearchDevice.Get

            For Each moDevice In moReturnDevice

                Dim strDeviceID As String

                strDeviceID = moDevice("DeviceID")

                strDeviceID.ToUpper()

                MessageBox.Show("DeviceID is " + strDeviceID)

                MessageBox.Show(String.Format("{0} - {1} ", moDevice("Description").ToString, moDevice("Status").ToString))

            Next

        Next
    End Sub

   
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim mail As New MailMessage()
            Dim smtp As New SmtpClient("mail.nic.in", 465)
            mail.From = New MailAddress("gujban@nic.in")
            mail.To.Add("shiwanshu.ram@nic.in")
            mail.Subject = "Test mail"
            mail.Body = "This is test mail"            
            smtp.Credentials = New System.Net.NetworkCredential("gujban@nic.in", "gujnic@))(")
            smtp.EnableSsl = True
            smtp.Send(mail)
            MessageBox.Show("Send")
        Catch ex As Exception

        End Try
    End Sub
End Class
