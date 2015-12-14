Public Class frmAbsent

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click       
        Try
            Dim userId As String = DirectCast(cmbUser.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim objDb = New InterNICEntities()
            objDb.sp_saveUserLeave(userId, dtpFrom.Value, dtpTp.Value)
            cmbUser.SelectedIndex = 0
            fillGrid()
            btnCancel.Hide()
            MessageBox.Show("Details Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Could not saved")
        End Try
        
    End Sub

    Private Sub frmAbsent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnCancel.Hide()
        Try
            Dim objDb = New InterNICEntities()
            Dim lstUsers = objDb.sp_GetUserForDisplay(0)
            Dim userSource As New Dictionary(Of String, String)()
            userSource.Add("0", "-All-")
            For Each lstuser In lstUsers
                userSource.Add(lstuser.userID.ToString(), lstuser.fullName)
            Next
            cmbUser.DataSource = New BindingSource(userSource, Nothing)
            cmbUser.DisplayMember = "Value"
            cmbUser.ValueMember = "Key"
        Catch ex As Exception
            MessageBox.Show("could not connect to server")
        End Try
        fillGrid()
    End Sub
    Private Sub fillGrid()
        Dim objDb = New InterNICEntities()
        Dim lstUsers = objDb.sp_getLeaves(0, 0).ToList()
        If IsNothing(lstUsers) = False Then
            DataGridView1.DataSource = lstUsers
        End If

    End Sub
    Private Sub DataGridView1_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        Try
            If e.RowIndex >= 0 Then
                Dim recID = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("leaveId").Value.ToString())
                Dim objData As New InterNICEntities()
                Dim lstUsers = objData.sp_getLeaves(0, recID).FirstOrDefault()
                If Not IsNothing(lstUsers) Then
                    lblUserId.Text = lstUsers.leaveId.ToString()
                End If
                btnCancel.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MessageBox.Show("Are you sure? you want to cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim objData As New InterNICEntities()
            Dim leaveId As Integer
            leaveId = Convert.ToInt32(lblUserId.Text)
            objData.sp_CancelLeave(leaveId)
            fillGrid()
            btnCancel.Hide()
            MessageBox.Show("Leave cancelled successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class