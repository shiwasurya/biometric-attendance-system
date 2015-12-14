Public Class frmDesignation

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrEmpty(txtDesig.Text) Then
            MessageBox.Show("Designation name is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        
        
        Dim objData As New InterNICEntities()
        Dim userid As Integer
        userid = Convert.ToInt32(lblUserId.Text)
        
        objData.sp_SaveDesignation(userid, txtDesig.Text.Trim())
        fillGrid()        
        MessageBox.Show("Record Saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtDesig.Text = ""
        lblUserId.Text = "0"        
    End Sub

    Private Sub frmDesignation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUserId.Text = "0"
        lblUserId.Hide()
        btnDelete.Hide()
        fillGrid()
    End Sub

    Private Sub fillGrid()
        Dim objData As New InterNICEntities()
        Dim lstUsers = objData.sp_getDesignation(0).ToList()
        If IsNothing(lstUsers) = False Then
            DataGridView1.DataSource = lstUsers
        End If

    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        Try
            If e.RowIndex >= 0 Then
                Dim userId = Convert.ToInt32(DataGridView1.Rows(e.RowIndex).Cells("desigID").Value.ToString())
                Dim objData As New InterNICEntities()
                Dim lstUsers = objData.sp_getDesignation(userId).FirstOrDefault()
                If Not IsNothing(lstUsers) Then
                    txtDesig.Text = lstUsers.desigName
                    lblUserId.Text = lstUsers.desigID
                End If                
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtDesig.Text = ""
        lblUserId.Text = "0"
        btnDelete.Hide()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnReset.Click, btnDelete.Click
        Dim userId As Integer = 0
        Try
            userId = Convert.ToInt32(lblUserId.Text)
            If (userId > 0) Then
                If MessageBox.Show("Are you Sure, you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim objData As New InterNICEntities()
                    objData.sp_RemoveDesignation(userId)
                    fillGrid()
                    MessageBox.Show("Record successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Please select a record first", "Error", MessageBoxButtons.OK)
        End Try
    End Sub
End Class