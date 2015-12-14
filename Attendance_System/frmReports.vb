Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Diagnostics

Public Class frmReports

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try            
            Dim imonth As Integer
            Dim iyear As Integer
            imonth = Convert.ToInt32(DirectCast(cmbMonth.SelectedItem, KeyValuePair(Of String, String)).Key) ' Convert.ToInt32(cmbMonth.SelectedItem)
            iyear = Convert.ToInt32(DirectCast(cmbYear.SelectedItem, KeyValuePair(Of String, String)).Key) 'Convert.ToInt32(cmbYear.SelectedItem)
            Dim reportType As String = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim userId As String = DirectCast(cmbUser.SelectedItem, KeyValuePair(Of String, String)).Key

            If reportType = "0" Then
                MessageBox.Show("Select a report to generate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf imonth = 0 And (reportType = "1" Or reportType = "2" Or reportType = "3" Or reportType = "5") Then
                MessageBox.Show("Select a month to get the report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf iyear = 0 And (reportType = "1" Or reportType = "2" Or reportType = "3" Or reportType = "5") Then
                MessageBox.Show("Select a year to get the report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf userId = "0" And (reportType = "5") Then
                MessageBox.Show("Select a user to get the report", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub            
            End If

            Dim objDb = New InterNICEntities()

            If reportType = "1" Then    ''Summary Report
                Dim lstUsers = objDb.sp_GetMonthlyReport(imonth, iyear, 0)
                If IsNothing(lstUsers) = False Then
                    DataGridView1.DataSource = lstUsers
                End If
            ElseIf reportType = "2" Then    ''Detailed Report            
                Dim objDbModel As New DataBaseModel()
                Dim lstUsers = objDbModel.ExecuteDataTable("exec sp_getDetailedReport " & imonth.ToString & ", " & iyear & ", " & userId.ToString())

                If IsNothing(lstUsers) = False Then
                    DataGridView1.DataSource = lstUsers
                End If
            ElseIf reportType = "3" Then    ''Hourly Report                
                Dim objDbModel As New DataBaseModel()
                Dim lstUsers = objDbModel.ExecuteDataTable("exec sp_getHourlyReport " & imonth.ToString & ", " & iyear & ", " & userId.ToString())

                If IsNothing(lstUsers) = False Then
                    DataGridView1.DataSource = lstUsers
                End If
            ElseIf reportType = "4" Then    ''Daywise movement Report
                Dim lstUsers = objDb.sp_getDateInOutDetails(dtpFpDate.Value)
                If IsNothing(lstUsers) = False Then
                    DataGridView1.DataSource = lstUsers
                End If
            ElseIf reportType = "5" Then    ''Userwise movement Report                
                Dim lstUsers = objDb.sp_getUserInOutDetails(userId, imonth, iyear)
                If IsNothing(lstUsers) = False Then
                    DataGridView1.DataSource = lstUsers
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim monthSource As New Dictionary(Of String, String)()
        monthSource.Add("0", "-Select-")
        monthSource.Add("1", "Jan")
        monthSource.Add("2", "Feb")
        monthSource.Add("3", "Mar")
        monthSource.Add("4", "Apr")
        monthSource.Add("5", "May")
        monthSource.Add("6", "Jun")
        monthSource.Add("7", "Jul")
        monthSource.Add("8", "Aug")
        monthSource.Add("9", "Sep")
        monthSource.Add("10", "Oct")
        monthSource.Add("11", "Nov")
        monthSource.Add("12", "Dec")

        cmbMonth.DataSource = New BindingSource(monthSource, Nothing)
        cmbMonth.DisplayMember = "Value"
        cmbMonth.ValueMember = "Key"

        Dim yearSource As New Dictionary(Of String, String)()
        yearSource.Add("0", "-Select-")
        For i As Integer = 2015 To DateTime.Now.Year
            yearSource.Add(i.ToString(), i.ToString())            
        Next
        cmbYear.DataSource = New BindingSource(yearSource, Nothing)
        cmbYear.DisplayMember = "Value"
        cmbYear.ValueMember = "Key"

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

        Dim reportSource As New Dictionary(Of String, String)()
        reportSource.Add("0", "-Select-")
        reportSource.Add("1", "Summary Report")
        reportSource.Add("2", "Detailed Report")
        reportSource.Add("3", "Hourly Report")
        reportSource.Add("4", "Daywise Movement Report")
        reportSource.Add("5", "Userwise Movement Report")

        ComboBox1.DataSource = New BindingSource(reportSource, Nothing)
        ComboBox1.DisplayMember = "Value"
        ComboBox1.ValueMember = "Key"

        cmbMonth.SelectedIndex = 0
        cmbYear.SelectedIndex = 0
        cmbUser.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0
        lblDate.Hide()
        dtpFpDate.Hide()
    End Sub

    Private Sub btnExportPDF_Click(sender As Object, e As EventArgs) Handles btnExportPDF.Click
        Try

            'Creating iTextSharp Table from the DataTable data
            Dim pdfTable As New PdfPTable(DataGridView1.ColumnCount)
            Dim fontTinyItalic As iTextSharp.text.Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL)
            pdfTable.DefaultCell.Padding = 3
            pdfTable.WidthPercentage = 100
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER
            pdfTable.DefaultCell.BorderWidth = 1

            'Adding Header row
            For Each column As DataGridViewColumn In DataGridView1.Columns
                Dim cell As New PdfPCell(New Phrase(column.HeaderText, fontTinyItalic))
                cell.BackgroundColor = New iTextSharp.text.Color(240, 240, 240)
                pdfTable.AddCell(cell)
            Next

            'Adding DataRow
            For Each row As DataGridViewRow In DataGridView1.Rows
                For Each cell As DataGridViewCell In row.Cells
                    Dim rowcell As New PdfPCell(New Phrase(cell.Value.ToString().Replace("12:00:00 AM", ""), fontTinyItalic))
                    If cell.Value.ToString() = "0.0" Then
                        rowcell.BackgroundColor = New iTextSharp.text.Color(253, 203, 193)
                    End If
                    pdfTable.AddCell(rowcell)
                Next
            Next

            'Exporting to PDF
            Dim folderPath As String = "C:\PDFs\"
            If Not Directory.Exists(folderPath) Then
                Directory.CreateDirectory(folderPath)
            End If
            Using stream As New FileStream(folderPath & "DataGridViewExport.pdf", FileMode.Create)
                Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)

                PdfWriter.GetInstance(pdfDoc, stream)
                pdfDoc.Open()
                pdfDoc.Add(pdfTable)
                pdfDoc.Close()
                stream.Close()
            End Using
            Process.Start("C:\PDFs\DataGridViewExport.pdf")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.RowIndex >= 0 Then
            If e.RowIndex < DataGridView1.RowCount - 1 Then
                Dim dgvRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                If (dgvRow.Cells(0).Value.ToString) = "SUNDAY" Then
                    dgvRow.DefaultCellStyle.BackColor = Drawing.Color.MistyRose
                End If
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim reportType As String = DirectCast(ComboBox1.SelectedItem, KeyValuePair(Of String, String)).Key       
        If reportType = "1" Then
            lblUserName.Hide()
            cmbUser.Hide()
            lblDate.Hide()
            dtpFpDate.Hide()
            cmbMonth.Show()
            lblYear.Show()
            cmbYear.Show()            
        ElseIf reportType = "2" Then
            lblDate.Hide()
            dtpFpDate.Hide()
            cmbMonth.Show()
            lblYear.Show()
            cmbYear.Show()
            lblUserName.Show()
            cmbUser.Show()
        ElseIf reportType = "3" Then
            lblDate.Hide()
            dtpFpDate.Hide()
            cmbMonth.Show()
            lblYear.Show()
            cmbYear.Show()
            lblUserName.Show()
            cmbUser.Show()
        ElseIf reportType = "4" Then
            lblDate.Show()
            dtpFpDate.Show()
            lblDate.Left = lblMonth.Left
            lblDate.Top = lblMonth.Top
            lblMonth.Hide()            
            dtpFpDate.Top = cmbMonth.Top
            dtpFpDate.Left = cmbMonth.Left
            cmbMonth.Hide()
            lblYear.Hide()
            cmbYear.Hide()
            lblUserName.Hide()
            cmbUser.Hide()
        ElseIf reportType = "5" Then
            lblDate.Hide()
            dtpFpDate.Hide()
            cmbMonth.Show()
            lblYear.Show()
            cmbYear.Show()
            lblUserName.Show()
            cmbUser.Show()
        End If
    End Sub
End Class