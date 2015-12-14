Public Class frmHolidayMaster

    Private Sub frmHolidayMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = MainForm
        Me.WindowState = FormWindowState.Maximized
        fillGrid()
        btnRemove.Hide()
        lblRecId.Hide()
    End Sub
    Private Sub fillGrid()
        Dim objData As New InterNICEntities()
        Dim lstUsers = objData.sp_getHolidays(0).ToList()
        If IsNothing(lstUsers) = False Then
            grdHoliday.DataSource = lstUsers
        End If

    End Sub

    Private Sub grdHoliday_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdHoliday.RowHeaderMouseDoubleClick
        Try
            If e.RowIndex >= 0 Then
                Dim recID = Convert.ToInt32(grdHoliday.Rows(e.RowIndex).Cells("recId").Value.ToString())
                Dim objData As New InterNICEntities()
                Dim lstUsers = objData.sp_getHolidays(recID).FirstOrDefault()
                If Not IsNothing(lstUsers) Then
                    txtTitle.Text = lstUsers.title.Trim()
                    dtFrom.Value = lstUsers.dtfrom
                    dtTo.Value = lstUsers.dtTo
                    lblRecId.Text = lstUsers.recId.ToString()
                End If
                btnRemove.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim userId As Integer = 0
        Try
            userId = Convert.ToInt32(lblRecId.Text)
            If (userId > 0) Then
                If MessageBox.Show("Are you Sure, you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim objData As New InterNICEntities()
                    objData.sp_RemoveHoliday(userId)
                    fillGrid()
                    MessageBox.Show("Record successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Please select a record first", "Error", MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtTitle.Text = ""
        dtFrom.Value = DateTime.Now.Date
        dtTo.Value = DateTime.Now.Date
        lblRecId.Text = "0"
        btnRemove.Hide()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtTitle.Text) Then
            MessageBox.Show("Title is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(dtFrom.Value.ToString()) Then
            MessageBox.Show("From date is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(dtTo.Value.ToString()) Then
            MessageBox.Show("To date is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim objData As New InterNICEntities()
        Dim recId As Integer = 0
        If (lblRecId.Text.Trim() <> "" And Convert.ToInt32(lblRecId.Text.Trim())) > 0 Then
            recId = Convert.ToInt32(lblRecId.Text.Trim())
        End If
        Dim fromdate As Date = dtFrom.Value
        Dim todate As Date = dtTo.Value        

        objData.sp_SaveHolidays(recId, txtTitle.Text.Trim(), fromdate, todate)
        fillGrid()
        btnReset_Click(sender, e)
        MessageBox.Show("Record Saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class