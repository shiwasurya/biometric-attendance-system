Public Class frmUserMaster

    Private Sub frmUserMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        Me.WindowState = FormWindowState.Maximized
        lblUserId.Text = "0"
        lblUserId.Hide()
        btnDelete.Hide()
        btnFP.Hide()
        fillGrid()
        fillDesig()
    End Sub
    Private Sub fillGrid()
        Dim objData As New InterNICEntities()
        Dim lstUsers = objData.sp_GetUserForDisplay(0).ToList()
        If IsNothing(lstUsers) = False Then
            DataGridView1.DataSource = lstUsers
        End If
        
    End Sub
    Private Sub fillDesig()
        Dim objDb = New InterNICEntities()
        Dim lstUsers = objDb.sp_getDesignation(0)
        Dim userSource As New Dictionary(Of String, String)()
        userSource.Add("0", "-Select-")
        For Each lstuser In lstUsers
            userSource.Add(lstuser.desigID.ToString(), lstuser.desigName)
        Next
        cmbDesig.Items.Clear()
        cmbDesig.DataSource = New BindingSource(userSource, Nothing)
        cmbDesig.DisplayMember = "Value"
        cmbDesig.ValueMember = "Key"
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtFullName.Text) Then
            MessageBox.Show("Full name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(cmbDesig.SelectedItem.ToString()) Then
            MessageBox.Show("Designation is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(dtJoining.Value.ToString()) Then
            MessageBox.Show("Joining date is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(dtBirth.Value.ToString().Length = 0) Then
            MessageBox.Show("Birth date is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not IsNumeric(txtMobile.Text) Then
            MessageBox.Show("Mobile No should be numeric!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim birthdate As Date = dtBirth.Value

        Dim objData As New InterNICEntities()
        Dim userid As Integer
        userid = Convert.ToInt32(lblUserId.Text)
        Dim isAdmin As Integer = 0
        If rdoAdmin.Checked = True Then
            isAdmin = 1
        End If
        Dim designation As String = DirectCast(cmbDesig.SelectedItem, KeyValuePair(Of String, String)).Value
        objData.sp_SaveUserDetails(userid, txtFullName.Text, designation, dtJoining.Value, birthdate, isAdmin, txtMobile.Text)
        fillGrid()
        btnDelete.Hide()
        btnFP.Hide()
        MessageBox.Show("Record Saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtFullName.Text = ""
        dtJoining.Value = DateTime.Now.Date
        lblUserId.Text = "0"
        cmbDesig.SelectedIndex = 0
    End Sub

   
    Private Sub DataGridView1_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        Try
            If e.RowIndex >= 0 Then
                Dim userId = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("userId").Value.ToString())
                Dim objData As New InterNICEntities()
                Dim lstUsers = objData.sp_GetUserForDisplay(userId).FirstOrDefault()
                If Not IsNothing(lstUsers) Then
                    txtFullName.Text = lstUsers.fullName
                    If Not lstUsers.JoiningDate Is Nothing Then
                        dtJoining.Value = lstUsers.JoiningDate
                    End If

                    If Not lstUsers.birthdate Is Nothing Then
                        dtBirth.Value = lstUsers.birthdate
                    End If

                    If lstUsers.Role = "--" Then
                        rdoUser.Checked = True
                        rdoAdmin.Checked = False
                    Else
                        rdoUser.Checked = False
                        rdoAdmin.Checked = True
                    End If

                    Dim i As Integer = 0
                    For Each designation As KeyValuePair(Of String, String) In cmbDesig.Items
                        If designation.Value = lstUsers.designation Then
                            Exit For
                        End If
                        i = i + 1
                    Next
                    If i < cmbDesig.Items.Count Then
                        cmbDesig.SelectedIndex = i
                    Else
                        cmbDesig.SelectedIndex = 0
                    End If

                    lblUserId.Text = lstUsers.userID
                    txtMobile.Text = lstUsers.mobileNo
                End If
                btnDelete.Show()
                btnFP.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtFullName.Text = ""
        dtJoining.Value = DateTime.Now.Date
        dtBirth.Value = DateTime.Now.Date
        lblUserId.Text = "0"
        cmbDesig.SelectedIndex = 0
        rdoAdmin.Checked = False
        rdoUser.Checked = True
        btnDelete.Hide()
        btnFP.Hide()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim userId As Integer = 0
        Try
            userId = Convert.ToInt32(lblUserId.Text)
            If (userId > 0) Then
                If MessageBox.Show("Are you Sure, you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim objData As New InterNICEntities()
                    objData.sp_DeleteUser(userId)
                    fillGrid()
                    MessageBox.Show("User successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Please select a record first", "Error", MessageBoxButtons.OK)
        End Try        
    End Sub

    Private Sub btnFP_Click(sender As Object, e As EventArgs) Handles btnFP.Click
        Dim userId As Integer = 0
        Try
            userId = Convert.ToInt32(lblUserId.Text)
            If (userId > 0) Then
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

                If Not AxFpLibXCapture1.GetMinutiaeData(RowData_Left) Then
                    MessageBox.Show(AxFpLibXCapture1.ErrorString, "Error", MessageBoxButtons.OK)
                    Exit Sub
                End If
                StrData_Left = AxFpLibXCapture1.MinTextData

                Dim objData As New InterNICEntities()
                objData.sp_UpdateUserFP(userId, m_ImageData_Left, RowData_Left)
               
                MessageBox.Show("Finger print data captured successfully.")
                AxFpLibXCapture1.Clear()
                AxFpLibXCapture1.Refresh()
                btnReset_Click(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show("Please select a record first", "Error", MessageBoxButtons.OK)
        End Try
    End Sub

End Class