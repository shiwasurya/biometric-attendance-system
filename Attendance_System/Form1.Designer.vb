<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.AxFpLibXCapture1 = New AxSGFPLIBXLib.AxFpLibXCapture()
        Me.AxFpLibXVerify1 = New AxSGFPLIBXLib.AxFpLibXVerify()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.btnVerify = New System.Windows.Forms.Button()
        Me.picBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.AxFpLibXCapture1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxFpLibXVerify1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxFpLibXCapture1
        '
        Me.AxFpLibXCapture1.Location = New System.Drawing.Point(98, 126)
        Me.AxFpLibXCapture1.Name = "AxFpLibXCapture1"
        Me.AxFpLibXCapture1.OcxState = CType(resources.GetObject("AxFpLibXCapture1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFpLibXCapture1.Size = New System.Drawing.Size(100, 113)
        Me.AxFpLibXCapture1.TabIndex = 0
        '
        'AxFpLibXVerify1
        '
        Me.AxFpLibXVerify1.Enabled = True
        Me.AxFpLibXVerify1.Location = New System.Drawing.Point(98, 364)
        Me.AxFpLibXVerify1.Name = "AxFpLibXVerify1"
        Me.AxFpLibXVerify1.OcxState = CType(resources.GetObject("AxFpLibXVerify1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxFpLibXVerify1.Size = New System.Drawing.Size(41, 41)
        Me.AxFpLibXVerify1.TabIndex = 1
        '
        'btnCapture
        '
        Me.btnCapture.Location = New System.Drawing.Point(34, 53)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(86, 26)
        Me.btnCapture.TabIndex = 2
        Me.btnCapture.Text = "Capture"
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'btnVerify
        '
        Me.btnVerify.Location = New System.Drawing.Point(174, 49)
        Me.btnVerify.Name = "btnVerify"
        Me.btnVerify.Size = New System.Drawing.Size(96, 29)
        Me.btnVerify.TabIndex = 3
        Me.btnVerify.Text = "Verify"
        Me.btnVerify.UseVisualStyleBackColor = True
        '
        'picBox
        '
        Me.picBox.Location = New System.Drawing.Point(229, 126)
        Me.picBox.Name = "picBox"
        Me.picBox.Size = New System.Drawing.Size(98, 113)
        Me.picBox.TabIndex = 4
        Me.picBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(229, 306)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Detect"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(252, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 417)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picBox)
        Me.Controls.Add(Me.btnVerify)
        Me.Controls.Add(Me.btnCapture)
        Me.Controls.Add(Me.AxFpLibXVerify1)
        Me.Controls.Add(Me.AxFpLibXCapture1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.AxFpLibXCapture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxFpLibXVerify1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AxFpLibXCapture1 As AxSGFPLIBXLib.AxFpLibXCapture
    Friend WithEvents AxFpLibXVerify1 As AxSGFPLIBXLib.AxFpLibXVerify
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents btnVerify As System.Windows.Forms.Button
    Friend WithEvents picBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
