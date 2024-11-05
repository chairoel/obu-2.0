<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblDistance = New System.Windows.Forms.Label
        Me.lblCOG = New System.Windows.Forms.Label
        Me.lblBearing = New System.Windows.Forms.Label
        Me.BtnIsiBBM = New System.Windows.Forms.Button
        Me.btnPergiPulang = New System.Windows.Forms.Button
        Me.btnSytemTest = New System.Windows.Forms.Button
        Me.ButtonWelcome = New System.Windows.Forms.Button
        Me.btnPanic = New System.Windows.Forms.Button
        Me.btnOperasi = New System.Windows.Forms.Button
        Me.lblRouteCode = New System.Windows.Forms.Label
        Me.lblRoute = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblTime = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblFrontBus = New System.Windows.Forms.Label
        Me.lblSpeed = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblSOG = New System.Windows.Forms.Label
        Me.lblLat = New System.Windows.Forms.Label
        Me.lblLong = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblAltitude = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblGPSStatus = New System.Windows.Forms.Label
        Me.lblDateTime = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblDeviceId = New System.Windows.Forms.Label
        Me.Timer = New System.Windows.Forms.Timer
        Me.txtMqtt = New System.Windows.Forms.TextBox
        Me.LabelError = New System.Windows.Forms.Label
        Me.lblRute = New System.Windows.Forms.Label
        Me.btnPilihRute = New System.Windows.Forms.Button
        Me.TextBoxOutput = New System.Windows.Forms.TextBox
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.lblMQTTStatus = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer_Mqtt = New System.Windows.Forms.Timer
        Me.lblMqttMsg = New System.Windows.Forms.Label
        Me.txtLayer = New System.Windows.Forms.TextBox
        Me.txtId = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(361, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.Text = "Jarak Total"
        Me.Label3.Visible = False
        '
        'lblDistance
        '
        Me.lblDistance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDistance.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDistance.ForeColor = System.Drawing.Color.White
        Me.lblDistance.Location = New System.Drawing.Point(448, 58)
        Me.lblDistance.Name = "lblDistance"
        Me.lblDistance.Size = New System.Drawing.Size(130, 20)
        Me.lblDistance.Text = "000.0 m"
        Me.lblDistance.Visible = False
        '
        'lblCOG
        '
        Me.lblCOG.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblCOG.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCOG.ForeColor = System.Drawing.Color.Yellow
        Me.lblCOG.Location = New System.Drawing.Point(632, 32)
        Me.lblCOG.Name = "lblCOG"
        Me.lblCOG.Size = New System.Drawing.Size(42, 20)
        Me.lblCOG.Text = "COG"
        '
        'lblBearing
        '
        Me.lblBearing.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblBearing.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblBearing.ForeColor = System.Drawing.Color.White
        Me.lblBearing.Location = New System.Drawing.Point(665, 32)
        Me.lblBearing.Name = "lblBearing"
        Me.lblBearing.Size = New System.Drawing.Size(77, 20)
        Me.lblBearing.Text = "-"
        '
        'BtnIsiBBM
        '
        Me.BtnIsiBBM.BackColor = System.Drawing.Color.Black
        Me.BtnIsiBBM.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BtnIsiBBM.ForeColor = System.Drawing.Color.White
        Me.BtnIsiBBM.Location = New System.Drawing.Point(7, 336)
        Me.BtnIsiBBM.Name = "BtnIsiBBM"
        Me.BtnIsiBBM.Size = New System.Drawing.Size(118, 29)
        Me.BtnIsiBBM.TabIndex = 55
        Me.BtnIsiBBM.Text = "ISI BBM/BBG"
        '
        'btnPergiPulang
        '
        Me.btnPergiPulang.BackColor = System.Drawing.Color.Black
        Me.btnPergiPulang.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnPergiPulang.ForeColor = System.Drawing.Color.White
        Me.btnPergiPulang.Location = New System.Drawing.Point(132, 336)
        Me.btnPergiPulang.Name = "btnPergiPulang"
        Me.btnPergiPulang.Size = New System.Drawing.Size(128, 29)
        Me.btnPergiPulang.TabIndex = 56
        Me.btnPergiPulang.Text = "PERGI/PULANG"
        '
        'btnSytemTest
        '
        Me.btnSytemTest.BackColor = System.Drawing.Color.Black
        Me.btnSytemTest.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnSytemTest.ForeColor = System.Drawing.Color.White
        Me.btnSytemTest.Location = New System.Drawing.Point(8, 371)
        Me.btnSytemTest.Name = "btnSytemTest"
        Me.btnSytemTest.Size = New System.Drawing.Size(118, 29)
        Me.btnSytemTest.TabIndex = 57
        Me.btnSytemTest.Text = "SYSTEM TEST"
        '
        'ButtonWelcome
        '
        Me.ButtonWelcome.BackColor = System.Drawing.Color.Black
        Me.ButtonWelcome.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonWelcome.ForeColor = System.Drawing.Color.White
        Me.ButtonWelcome.Location = New System.Drawing.Point(132, 371)
        Me.ButtonWelcome.Name = "ButtonWelcome"
        Me.ButtonWelcome.Size = New System.Drawing.Size(128, 29)
        Me.ButtonWelcome.TabIndex = 58
        Me.ButtonWelcome.Text = "SLMT DATANG"
        '
        'btnPanic
        '
        Me.btnPanic.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPanic.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnPanic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnPanic.Location = New System.Drawing.Point(7, 291)
        Me.btnPanic.Name = "btnPanic"
        Me.btnPanic.Size = New System.Drawing.Size(253, 39)
        Me.btnPanic.TabIndex = 54
        Me.btnPanic.Text = "PANIC BUTTON"
        '
        'btnOperasi
        '
        Me.btnOperasi.BackColor = System.Drawing.Color.Black
        Me.btnOperasi.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnOperasi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnOperasi.Location = New System.Drawing.Point(7, 246)
        Me.btnOperasi.Name = "btnOperasi"
        Me.btnOperasi.Size = New System.Drawing.Size(253, 39)
        Me.btnOperasi.TabIndex = 53
        Me.btnOperasi.Text = "OPERASI"
        '
        'lblRouteCode
        '
        Me.lblRouteCode.BackColor = System.Drawing.Color.Black
        Me.lblRouteCode.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRouteCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRouteCode.Location = New System.Drawing.Point(7, 164)
        Me.lblRouteCode.Name = "lblRouteCode"
        Me.lblRouteCode.Size = New System.Drawing.Size(191, 20)
        Me.lblRouteCode.Text = "N/A"
        '
        'lblRoute
        '
        Me.lblRoute.BackColor = System.Drawing.Color.Black
        Me.lblRoute.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblRoute.ForeColor = System.Drawing.Color.Yellow
        Me.lblRoute.Location = New System.Drawing.Point(8, 110)
        Me.lblRoute.Name = "lblRoute"
        Me.lblRoute.Size = New System.Drawing.Size(262, 46)
        Me.lblRoute.Text = "N/A"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Yellow
        Me.Label7.Location = New System.Drawing.Point(7, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 20)
        Me.Label7.Text = "ROUTE :"
        '
        'lblTime
        '
        Me.lblTime.BackColor = System.Drawing.Color.Black
        Me.lblTime.Font = New System.Drawing.Font("Tahoma", 26.0!, System.Drawing.FontStyle.Bold)
        Me.lblTime.ForeColor = System.Drawing.Color.Red
        Me.lblTime.Location = New System.Drawing.Point(488, 417)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(210, 37)
        Me.lblTime.Text = "10:00:00"
        Me.lblTime.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Lime
        Me.Label14.Location = New System.Drawing.Point(276, 198)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(543, 39)
        '
        'lblFrontBus
        '
        Me.lblFrontBus.BackColor = System.Drawing.Color.Black
        Me.lblFrontBus.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblFrontBus.ForeColor = System.Drawing.Color.Lime
        Me.lblFrontBus.Location = New System.Drawing.Point(514, 136)
        Me.lblFrontBus.Name = "lblFrontBus"
        Me.lblFrontBus.Size = New System.Drawing.Size(184, 36)
        Me.lblFrontBus.Text = "-"
        Me.lblFrontBus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSpeed
        '
        Me.lblSpeed.BackColor = System.Drawing.Color.Black
        Me.lblSpeed.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.lblSpeed.ForeColor = System.Drawing.Color.Lime
        Me.lblSpeed.Location = New System.Drawing.Point(276, 133)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(184, 36)
        Me.lblSpeed.Text = "0 kmh"
        Me.lblSpeed.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Black
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(506, 85)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(209, 36)
        Me.Label22.Text = "BIS DI DEPAN"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Black
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(276, 85)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(184, 36)
        Me.Label21.Text = "KECEPATAN"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Blue
        Me.Label20.Location = New System.Drawing.Point(748, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 26)
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Lime
        Me.Label19.Location = New System.Drawing.Point(748, 52)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 26)
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.ForeColor = System.Drawing.Color.Yellow
        Me.Label18.Location = New System.Drawing.Point(508, 32)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 20)
        Me.Label18.Text = "SOG"
        '
        'lblSOG
        '
        Me.lblSOG.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSOG.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblSOG.ForeColor = System.Drawing.Color.White
        Me.lblSOG.Location = New System.Drawing.Point(541, 32)
        Me.lblSOG.Name = "lblSOG"
        Me.lblSOG.Size = New System.Drawing.Size(77, 20)
        Me.lblSOG.Text = "0 km/h"
        '
        'lblLat
        '
        Me.lblLat.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblLat.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblLat.ForeColor = System.Drawing.Color.White
        Me.lblLat.Location = New System.Drawing.Point(429, 32)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(82, 20)
        Me.lblLat.Text = "-"
        '
        'lblLong
        '
        Me.lblLong.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblLong.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblLong.ForeColor = System.Drawing.Color.White
        Me.lblLong.Location = New System.Drawing.Point(317, 32)
        Me.lblLong.Name = "lblLong"
        Me.lblLong.Size = New System.Drawing.Size(82, 20)
        Me.lblLong.Text = "-"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.Yellow
        Me.Label17.Location = New System.Drawing.Point(403, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(42, 20)
        Me.Label17.Text = "Lat"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.ForeColor = System.Drawing.Color.Yellow
        Me.Label16.Location = New System.Drawing.Point(288, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(42, 20)
        Me.Label16.Text = "Lon"
        '
        'lblAltitude
        '
        Me.lblAltitude.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAltitude.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblAltitude.ForeColor = System.Drawing.Color.White
        Me.lblAltitude.Location = New System.Drawing.Point(267, 56)
        Me.lblAltitude.Name = "lblAltitude"
        Me.lblAltitude.Size = New System.Drawing.Size(130, 20)
        Me.lblAltitude.Text = "000.0 m"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Yellow
        Me.Label15.Location = New System.Drawing.Point(197, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 20)
        Me.Label15.Text = "Ketinggian"
        '
        'lblGPSStatus
        '
        Me.lblGPSStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGPSStatus.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblGPSStatus.ForeColor = System.Drawing.Color.White
        Me.lblGPSStatus.Location = New System.Drawing.Point(142, 56)
        Me.lblGPSStatus.Name = "lblGPSStatus"
        Me.lblGPSStatus.Size = New System.Drawing.Size(130, 20)
        Me.lblGPSStatus.Text = "Invalid"
        '
        'lblDateTime
        '
        Me.lblDateTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDateTime.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(156, 32)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(130, 20)
        Me.lblDateTime.Text = "2024-08-15 00:00:00"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Yellow
        Me.Label13.Location = New System.Drawing.Point(91, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(100, 20)
        Me.Label13.Text = "GPS Fix"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.Yellow
        Me.Label12.Location = New System.Drawing.Point(91, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 20)
        Me.Label12.Text = "Tgl Waktu"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(64, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(687, 26)
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(64, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(687, 26)
        '
        'lblDeviceId
        '
        Me.lblDeviceId.BackColor = System.Drawing.Color.Red
        Me.lblDeviceId.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.lblDeviceId.ForeColor = System.Drawing.Color.White
        Me.lblDeviceId.Location = New System.Drawing.Point(0, 26)
        Me.lblDeviceId.Name = "lblDeviceId"
        Me.lblDeviceId.Size = New System.Drawing.Size(85, 52)
        Me.lblDeviceId.Text = "B001"
        Me.lblDeviceId.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer
        '
        '
        'txtMqtt
        '
        Me.txtMqtt.Location = New System.Drawing.Point(3, 482)
        Me.txtMqtt.Multiline = True
        Me.txtMqtt.Name = "txtMqtt"
        Me.txtMqtt.Size = New System.Drawing.Size(199, 37)
        Me.txtMqtt.TabIndex = 30
        '
        'LabelError
        '
        Me.LabelError.BackColor = System.Drawing.Color.White
        Me.LabelError.Location = New System.Drawing.Point(208, 482)
        Me.LabelError.Name = "LabelError"
        Me.LabelError.Size = New System.Drawing.Size(36, 37)
        Me.LabelError.Text = "Label8"
        '
        'lblRute
        '
        Me.lblRute.Location = New System.Drawing.Point(67, 420)
        Me.lblRute.Name = "lblRute"
        Me.lblRute.Size = New System.Drawing.Size(135, 34)
        Me.lblRute.Text = "Rute"
        '
        'btnPilihRute
        '
        Me.btnPilihRute.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPilihRute.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btnPilihRute.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnPilihRute.Location = New System.Drawing.Point(7, 198)
        Me.btnPilihRute.Name = "btnPilihRute"
        Me.btnPilihRute.Size = New System.Drawing.Size(253, 39)
        Me.btnPilihRute.TabIndex = 7
        Me.btnPilihRute.Text = "PILIH RUTE"
        '
        'TextBoxOutput
        '
        Me.TextBoxOutput.BackColor = System.Drawing.SystemColors.Highlight
        Me.TextBoxOutput.ForeColor = System.Drawing.SystemColors.Window
        Me.TextBoxOutput.Location = New System.Drawing.Point(276, 240)
        Me.TextBoxOutput.Multiline = True
        Me.TextBoxOutput.Name = "TextBoxOutput"
        Me.TextBoxOutput.Size = New System.Drawing.Size(522, 160)
        Me.TextBoxOutput.TabIndex = 0
        '
        'lblMQTTStatus
        '
        Me.lblMQTTStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblMQTTStatus.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblMQTTStatus.ForeColor = System.Drawing.Color.White
        Me.lblMQTTStatus.Location = New System.Drawing.Point(632, 58)
        Me.lblMQTTStatus.Name = "lblMQTTStatus"
        Me.lblMQTTStatus.Size = New System.Drawing.Size(110, 20)
        Me.lblMQTTStatus.Text = "disconnect"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(578, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.Text = "MQTT"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(707, 396)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 103)
        '
        'Timer_Mqtt
        '
        '
        'lblMqttMsg
        '
        Me.lblMqttMsg.BackColor = System.Drawing.Color.Lime
        Me.lblMqttMsg.ForeColor = System.Drawing.Color.Black
        Me.lblMqttMsg.Location = New System.Drawing.Point(281, 211)
        Me.lblMqttMsg.Name = "lblMqttMsg"
        Me.lblMqttMsg.Size = New System.Drawing.Size(206, 20)
        Me.lblMqttMsg.Text = "Send MQTT data ..."
        '
        'txtLayer
        '
        Me.txtLayer.BackColor = System.Drawing.SystemColors.Highlight
        Me.txtLayer.ForeColor = System.Drawing.SystemColors.Window
        Me.txtLayer.Location = New System.Drawing.Point(276, 239)
        Me.txtLayer.Multiline = True
        Me.txtLayer.Name = "txtLayer"
        Me.txtLayer.Size = New System.Drawing.Size(522, 160)
        Me.txtLayer.TabIndex = 88
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(382, 431)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(17, 23)
        Me.txtId.TabIndex = 125
        Me.txtId.Text = "0"
        Me.txtId.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(289, 262)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(172, 23)
        Me.TextBox1.TabIndex = 162
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(488, 262)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(172, 23)
        Me.TextBox2.TabIndex = 163
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(665, 262)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 20)
        Me.Button1.TabIndex = 164
        Me.Button1.Text = "Button1"
        '
        'Form2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(640, 480)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.txtLayer)
        Me.Controls.Add(Me.lblMqttMsg)
        Me.Controls.Add(Me.lblMQTTStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblDistance)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblBearing)
        Me.Controls.Add(Me.lblCOG)
        Me.Controls.Add(Me.ButtonWelcome)
        Me.Controls.Add(Me.btnSytemTest)
        Me.Controls.Add(Me.btnPergiPulang)
        Me.Controls.Add(Me.BtnIsiBBM)
        Me.Controls.Add(Me.btnPanic)
        Me.Controls.Add(Me.btnOperasi)
        Me.Controls.Add(Me.lblRouteCode)
        Me.Controls.Add(Me.lblRoute)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblFrontBus)
        Me.Controls.Add(Me.lblSpeed)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.lblSOG)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblLat)
        Me.Controls.Add(Me.lblLong)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lblAltitude)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblGPSStatus)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblDeviceId)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtMqtt)
        Me.Controls.Add(Me.LabelError)
        Me.Controls.Add(Me.lblRute)
        Me.Controls.Add(Me.btnPilihRute)
        Me.Controls.Add(Me.TextBoxOutput)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Menu = Me.mainMenu1
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.Text = "OBU 4G"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDistance As System.Windows.Forms.Label
    Friend WithEvents lblCOG As System.Windows.Forms.Label
    Friend WithEvents lblBearing As System.Windows.Forms.Label
    Friend WithEvents BtnIsiBBM As System.Windows.Forms.Button
    Friend WithEvents btnPergiPulang As System.Windows.Forms.Button
    Friend WithEvents btnSytemTest As System.Windows.Forms.Button
    Friend WithEvents ButtonWelcome As System.Windows.Forms.Button
    Friend WithEvents btnPanic As System.Windows.Forms.Button
    Friend WithEvents btnOperasi As System.Windows.Forms.Button
    Friend WithEvents lblRouteCode As System.Windows.Forms.Label
    Friend WithEvents lblRoute As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblFrontBus As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblSOG As System.Windows.Forms.Label
    Friend WithEvents lblLat As System.Windows.Forms.Label
    Friend WithEvents lblLong As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblGPSStatus As System.Windows.Forms.Label
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDeviceId As System.Windows.Forms.Label
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents txtMqtt As System.Windows.Forms.TextBox
    Friend WithEvents LabelError As System.Windows.Forms.Label
    Friend WithEvents lblRute As System.Windows.Forms.Label
    Friend WithEvents btnPilihRute As System.Windows.Forms.Button
    Friend WithEvents TextBoxOutput As System.Windows.Forms.TextBox
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents lblMQTTStatus As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer_Mqtt As System.Windows.Forms.Timer
    Friend WithEvents lblMqttMsg As System.Windows.Forms.Label
    Friend WithEvents txtLayer As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
