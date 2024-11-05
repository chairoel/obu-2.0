<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRute
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SendData = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnPilih = New System.Windows.Forms.Button
        Me.lblRute = New System.Windows.Forms.Label
        Me.txtArr = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'SendData
        '
        Me.SendData.Location = New System.Drawing.Point(336, 289)
        Me.SendData.Name = "SendData"
        Me.SendData.Size = New System.Drawing.Size(72, 20)
        Me.SendData.TabIndex = 0
        Me.SendData.Text = "Button1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(128, 286)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(202, 23)
        Me.TextBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(411, 313)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 38)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "PLAY"
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.SystemColors.ControlText
        Me.btnNext.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnNext.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNext.Location = New System.Drawing.Point(358, 127)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(83, 50)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = ">>"
        '
        'btnPrev
        '
        Me.btnPrev.BackColor = System.Drawing.SystemColors.ControlText
        Me.btnPrev.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnPrev.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnPrev.Location = New System.Drawing.Point(101, 127)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(89, 50)
        Me.btnPrev.TabIndex = 4
        Me.btnPrev.Text = "<<"
        '
        'btnPilih
        '
        Me.btnPilih.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnPilih.Location = New System.Drawing.Point(204, 127)
        Me.btnPilih.Name = "btnPilih"
        Me.btnPilih.Size = New System.Drawing.Size(145, 50)
        Me.btnPilih.TabIndex = 5
        Me.btnPilih.Text = "PILIH"
        '
        'lblRute
        '
        Me.lblRute.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblRute.ForeColor = System.Drawing.Color.Yellow
        Me.lblRute.Location = New System.Drawing.Point(39, 61)
        Me.lblRute.Name = "lblRute"
        Me.lblRute.Size = New System.Drawing.Size(490, 32)
        Me.lblRute.Text = "Rute"
        Me.lblRute.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtArr
        '
        Me.txtArr.Location = New System.Drawing.Point(118, 328)
        Me.txtArr.Multiline = True
        Me.txtArr.Name = "txtArr"
        Me.txtArr.Size = New System.Drawing.Size(264, 43)
        Me.txtArr.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(39, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(490, 32)
        Me.Label1.Text = "ROUTE NAME"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmRute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(576, 223)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtArr)
        Me.Controls.Add(Me.lblRute)
        Me.Controls.Add(Me.btnPilih)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.SendData)
        Me.MaximizeBox = False
        Me.Name = "frmRute"
        Me.Text = "PILIH RUTE"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SendData As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnPilih As System.Windows.Forms.Button
    Friend WithEvents lblRute As System.Windows.Forms.Label
    Friend WithEvents txtArr As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
