Imports System.Windows.Forms

Public Class MainForm

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
        ' Create a new instance of the child form.
        closeAllChild()

        Dim ChildForm As New frmUserMaster

        ChildForm.MdiParent = Me
        ChildForm.Text = "Manage Users"
        ChildForm.Show()
        ChildForm.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        closeAllChild()
        Dim childForm As New frmAbsent
        childForm.MdiParent = Me
        childForm.Text = "Manage Leave"
        childForm.Show()
        childForm.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub ReportsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        closeAllChild()
        Dim childForm As New frmReports
        childForm.MdiParent = Me
        childForm.Text = "Reports"
        childForm.Show()
        childForm.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub closeAllChild()
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub ManageHolidayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageHolidayToolStripMenuItem.Click
        closeAllChild()
        Dim childForm As New frmHolidayMaster
        childForm.MdiParent = Me
        childForm.Text = "Manage Holiday"
        childForm.Show()
        childForm.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ManageDesignationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageDesignationToolStripMenuItem.Click
        closeAllChild()
        Dim childForm As New frmDesignation
        childForm.MdiParent = Me
        childForm.Text = "Manage Designation"
        childForm.Show()
        childForm.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MisliniousToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MisliniousToolStripMenuItem.Click
        closeAllChild()
        Dim childForm As New frmReports
        childForm.MdiParent = Me
        childForm.Text = "Reports"
        childForm.Show()
        childForm.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetupToolStripMenuItem.Click
        closeAllChild()
        Dim childForm As New frmSetup
        childForm.MdiParent = Me
        childForm.Text = "Database Configuration"
        childForm.Show()
        childForm.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CloseManagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseManagerToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ReportsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReportsToolStripMenuItem1.Click

    End Sub
End Class
