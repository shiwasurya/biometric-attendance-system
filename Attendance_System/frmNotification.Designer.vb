<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotification
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotification))
        Me.lblNotify = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lblBirthday = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnPresence = New System.Windows.Forms.Button()
        Me.txtNotify = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNotify
        '
        Me.lblNotify.AutoSize = True
        Me.lblNotify.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotify.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblNotify.Location = New System.Drawing.Point(4, 4)
        Me.lblNotify.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblNotify.Name = "lblNotify"
        Me.lblNotify.Size = New System.Drawing.Size(10, 15)
        Me.lblNotify.TabIndex = 1
        Me.lblNotify.Text = "."
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Click here"
        Me.NotifyIcon1.BalloonTipTitle = "Important Notification"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "AMS"
        Me.NotifyIcon1.Visible = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 30000
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 3600000
        '
        'lblBirthday
        '
        Me.lblBirthday.AutoSize = True
        Me.lblBirthday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBirthday.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBirthday.Location = New System.Drawing.Point(13, 79)
        Me.lblBirthday.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.lblBirthday.Name = "lblBirthday"
        Me.lblBirthday.Size = New System.Drawing.Size(11, 15)
        Me.lblBirthday.TabIndex = 6
        Me.lblBirthday.Text = "."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.PictureBox1.Image = Global.Attendance_System.My.Resources.Resources.attendance1
        Me.PictureBox1.Location = New System.Drawing.Point(49, 137)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(209, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = Global.Attendance_System.My.Resources.Resources._1421856037_icon_arrow_down_b_24
        Me.Button1.Location = New System.Drawing.Point(289, -3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.ForeColor = System.Drawing.Color.Transparent
        Me.btnLogin.Image = Global.Attendance_System.My.Resources.Resources._1421856089_login
        Me.btnLogin.Location = New System.Drawing.Point(261, 135)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(46, 40)
        Me.btnLogin.TabIndex = 12
        '
        'btnPresence
        '
        Me.btnPresence.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPresence.ForeColor = System.Drawing.Color.Transparent
        Me.btnPresence.Image = Global.Attendance_System.My.Resources.Resources._1421856259_Touch_ID_32
        Me.btnPresence.Location = New System.Drawing.Point(1, 133)
        Me.btnPresence.Name = "btnPresence"
        Me.btnPresence.Size = New System.Drawing.Size(47, 43)
        Me.btnPresence.TabIndex = 13
        '
        'txtNotify
        '
        Me.txtNotify.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtNotify.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtNotify.Enabled = False
        Me.txtNotify.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNotify.Location = New System.Drawing.Point(12, 15)
        Me.txtNotify.Multiline = True
        Me.txtNotify.Name = "txtNotify"
        Me.txtNotify.ReadOnly = True
        Me.txtNotify.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotify.Size = New System.Drawing.Size(282, 64)
        Me.txtNotify.TabIndex = 9
        '
        'frmNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(306, 177)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtNotify)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblBirthday)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.lblNotify)
        Me.Controls.Add(Me.btnPresence)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNotification"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notifications"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPresence As System.Windows.Forms.Button
    Friend WithEvents lblNotify As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblBirthday As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtNotify As System.Windows.Forms.TextBox
End Class
