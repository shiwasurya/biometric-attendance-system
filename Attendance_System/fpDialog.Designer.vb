<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fpDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fpDialog))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.AxFpLibXCapture1 = New AxSGFPLIBXLib.AxFpLibXCapture()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AxFpLibXVerify1 = New AxSGFPLIBXLib.AxFpLibXVerify()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.AxFpLibXCapture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxFpLibXVerify1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(53, 195)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'AxFpLibXCapture1
        '
        Me.AxFpLibXCapture1.Location = New System.Drawing.Point(35, 39)
        Me.AxFpLibXCapture1.Name = "AxFpLibXCapture1"
        Me.AxFpLibXCapture1.OcxState = CType(resources.GetObject("AxFpLibXCapture1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFpLibXCapture1.Size = New System.Drawing.Size(100, 122)
        Me.AxFpLibXCapture1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(167, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Please mark your finger print-"
        '
        'AxFpLibXVerify1
        '
        Me.AxFpLibXVerify1.Enabled = True
        Me.AxFpLibXVerify1.Location = New System.Drawing.Point(2, 83)
        Me.AxFpLibXVerify1.Name = "AxFpLibXVerify1"
        Me.AxFpLibXVerify1.OcxState = CType(resources.GetObject("AxFpLibXVerify1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFpLibXVerify1.Size = New System.Drawing.Size(41, 41)
        Me.AxFpLibXVerify1.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(35, 167)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(104, 13)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'fpDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(184, 230)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.AxFpLibXVerify1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AxFpLibXCapture1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fpDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "fpDialog"
        Me.TopMost = True
        CType(Me.AxFpLibXCapture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxFpLibXVerify1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents AxFpLibXCapture1 As AxSGFPLIBXLib.AxFpLibXCapture
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AxFpLibXVerify1 As AxSGFPLIBXLib.AxFpLibXVerify
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
