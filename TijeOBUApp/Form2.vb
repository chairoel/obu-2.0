Imports System.IO.Ports
Imports System.Threading
Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports System.IO.File
Imports System.Math
Imports System.Text
Imports uPLibrary.Networking.M2Mqtt
Imports uPLibrary.Networking.M2Mqtt.Messages
Imports System.Diagnostics
Imports System.Media
Imports WMPLib

'Imports NAudio.Wave




Public Class Form2
    Private lines As String()
    Private isPlaying As Boolean = False
    Private wmp As WindowsMediaPlayer = New WindowsMediaPlayer

    Private soundPlayer As SoundPlayer
    Private serialPort As New SerialPort()
    Private serialPortRT As New SerialPort()
    Private lastLatitude As Double = 0.0
    Private lastLongitude As Double = 0.0
    Private lastSpeed As Double = 0.0
    Private lastTotalDistance As Double = 0.0
    Private lastBearing As Double = 0.0
    Private dataSendInterval As Integer = 5000 '5 second in millisecond
    'Private lines As List(Of String)
    Private currentIndex As Integer
    Private lastReceivedTime As DateTime
    Public DeviceID As String = ""
    Public busBodyNo As String = ""
    Public busDeviceId As String = ""
    Public serverTrac As String = "http://103.119.63.150:5055"
    Private mqttClient As MqttClient
    Private routeText As String = "~"
    Private routeNumber As String = "~"
    Private pesanRTIndoor As String = ""
    Private pesanRTSamping As String = ""
    Private GPSCOMPORT As String
    Private GPSBAUDRATE As Integer
    Private RTCOMPORT As String
    Private RTBAUDRATE As Integer
    Private LEDTYPE As String = ""
    Private MQTTBROKER As String
    Private MQTTPORT As Integer = 0
    Private REGNO As String = ""
    Private VECCODE As String = ""
    Private totalDistance As Double = 0
    Private lastCheckpointDistance As Double = 0
    Private Const CheckpointInterval As Double = 25 ' meters





    Private Sub Form2_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If mqttClient IsNot Nothing AndAlso mqttClient.IsConnected Then
            mqttClient.Disconnect()
        End If

        If serialPort IsNot Nothing AndAlso serialPort.IsOpen Then
            serialPort.Close()
        End If
        If serialPortRT IsNot Nothing AndAlso serialPortRT.IsOpen Then
            serialPortRT.Close()
        End If


    End Sub



    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReadDataSetting()
        Dim timer As New System.Windows.Forms.Timer()
        Dim timerMqTT As New System.Windows.Forms.Timer()
        lblDeviceId.Text = DeviceID
        timer.Interval = 1000

        AddHandler timer.Tick, AddressOf Timer_Tick

        timer.Enabled = True
        Try
            'serialPort = New SerialPort("COM2", 4800, Parity.None, 8, StopBits.One)
            serialPort.PortName = GPSCOMPORT
            serialPort.BaudRate = GPSBAUDRATE
            serialPort.DataBits = 8
            serialPort.Parity = Parity.None
            serialPort.StopBits = StopBits.One
            serialPortRT.PortName = RTCOMPORT
            serialPortRT.BaudRate = RTBAUDRATE
            serialPortRT.DataBits = 8
            serialPortRT.Parity = Parity.None
            serialPortRT.StopBits = StopBits.One
            AddHandler serialPort.DataReceived, AddressOf DataReceiverHandler

            Try
                serialPort.Open()
                serialPortRT.Open()
                UpdateGPSStatus("Listening")
                UpdateTextBox("GPS receiver connected and listening for data...")
            Catch ex As Exception
                MessageBox.Show("Error opening serial port: " & ex.Message)
            End Try

            'UpdateTextBox("GPS receiver connected and listening for data...")
            'UpdateTextBox("================================================")
            'Console.ReadLine()

            'Dim checkTimeoutTimer As New System.Windows.Forms.Timer()
            'checkTimeoutTimer.Interval = 10000 ' Check every 10 seconds
            'AddHandler checkTimeoutTimer.Tick, AddressOf CheckTimeout
            'checkTimeoutTimer.Enabled = True

            'lastReceivedTime = DateTime.Now

            MqttConnect()

            AddHandler timerMqTT.Tick, AddressOf Timer_Mqtt_Tick
            timerMqTT.Interval = dataSendInterval
            timerMqTT.Enabled = True

        Catch ex As Exception
            UpdateGPSStatus("Disconnect")
            UpdateTextBox("Error could not connect to GPS receiver." & ex.Message)
            'UpdateTextBox()
        End Try
    End Sub

    Private Sub CheckTimeout(ByVal sender As Object, ByVal e As EventArgs)
        If DateTime.Now.Subtract(lastReceivedTime).TotalMinutes > 1 Then
            UpdateTextBox("Warning: No data received from GPS for over 1 minute. Attempting to reconnect...")
            Try
                serialPort.Close()
                serialPort.Open()
                UpdateTextBox("Reconnected to GPS receiver.")
                UpdateGPSStatus("Reconnect")
            Catch ex As Exception
                UpdateTextBox("Error reconnecting to GPS receiver: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub WriteRT(ByVal data As String)
        ' serialPortRT = New SerialPort("COM4", 9600, Parity.None, 8, StopBits.None)
        Try
            If Not serialPortRT.IsOpen Then
                serialPortRT.Open()
            End If

            serialPortRT.Write(data)
        Catch ex As Exception
            MessageBox.Show("error write into running text: " & ex.Message)
        Finally
            If serialPortRT.IsOpen Then
                serialPortRT.Close()
            End If
        End Try


    End Sub

    Private Sub MqttConnect()
        Dim maxRetries As Integer = 3
        Dim retryCount As Integer = 0
        Dim retryInterval As Integer = 5000 ' 5 seconds

        Do
            Try
                If mqttClient IsNot Nothing AndAlso mqttClient.IsConnected Then
                    updateMqttTextBox("Already connected")
                    Exit Sub
                End If

                mqttClient = New MqttClient(MQTTBROKER, MQTTPORT, False, Nothing, Nothing, MqttSslProtocols.None)
                Dim clientId As String = Guid.NewGuid().ToString()
                mqttClient.Connect(clientId)

                If mqttClient.IsConnected Then
                    updateMqttTextBox("Connected")
                    Exit Sub
                Else
                    updateMqttTextBox("Disconnected. Retrying...")
                End If
            Catch ex As Exception
                updateMqttTextBox("Error: " & ex.Message)
            End Try

            retryCount += 1
            If retryCount < maxRetries Then
                System.Threading.Thread.Sleep(retryInterval)
            Else
                updateMqttTextBox("Max retries reached. Unable to connect.")
                Exit Sub
            End If
        Loop While retryCount < maxRetries
    End Sub


    Private Sub UpdateGPSStatus(ByVal text As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf UpdateGPSStatus), text)
        Else
            lblGPSStatus.Text = text

        End If
    End Sub

    Private Sub UpdateTextBox(ByVal text As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf UpdateTextBox), text)
        Else
            TextBoxOutput.Text &= text & Environment.NewLine

            TextBoxOutput.SelectionStart = TextBoxOutput.Text.Length
            TextBoxOutput.ScrollToCaret()
        End If
    End Sub

    Private Sub UpdateTotalDistanceTextBox(ByVal distance As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf UpdateTotalDistanceTextBox), distance)
        Else
            'txtTotalDistance.Text = distance
            lblDistance.Text = distance
        End If
    End Sub

    Private Sub UpdateSpeedTextBox(ByVal speed As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf UpdateSpeedTextBox), speed)
        Else
            lblSpeed.Text = speed & " " & "kmh"
            'txtSpeed.Text = speed
        End If
    End Sub

    Private Sub UpdateAltitudeTextBox(ByVal altitude As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf UpdateAltitudeTextBox), altitude)
        Else
            lblAltitude.Text = altitude & " " & "m"
        End If
    End Sub

    Private Sub updateLongitudeTextBox(ByVal longitude As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf updateLongitudeTextBox), longitude)
        Else
            lblLong.Text = longitude
            'txtLong.Text = longitude
        End If
    End Sub


    Private Sub updateLatitudeTextBox(ByVal latitude As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf updateLatitudeTextBox), latitude)
        Else
            lblLat.Text = latitude
            ' txtLat.Text = latitude
        End If
    End Sub

    Private Sub updateDateTextBox(ByVal isDate As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf updateDateTextBox), isDate)
        Else
            ' txtDate.Text = isDate
        End If

    End Sub


    Private Sub updateTimeTextBox(ByVal isTime As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf updateTimeTextBox), isTime)
        Else
            'txtTime.Text = isTime
        End If
    End Sub

    Private Sub updateBearingTextBox(ByVal bearing As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf updateBearingTextBox), bearing)
        Else
            'txtBearing.Text = bearing
            lblBearing.Text = bearing & " " & "°"
        End If
    End Sub



    Private Sub updateSOGTextBox(ByVal sog As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf updateSOGTextBox), sog)
        Else
            'txtBearing.Text = bearing
            lblSOG.Text = sog & " " & "Km/H"
        End If
    End Sub

    Private Sub updateMqttTextBox(ByVal msg As String)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of String)(AddressOf updateMqttTextBox), msg)
        Else
            ' txtMqtt.Text = msg
            lblMQTTStatus.Text = msg
        End If
    End Sub


    Private Sub DataReceiverHandler(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            Dim sp As SerialPort = CType(sender, SerialPort)
            Dim indata As String = sp.ReadLine()
            ProcessGPSData(indata)
        Catch ex As Exception
            UpdateTextBox("Error reading data from GPS." & ex.Message)
            'UpdateTextBox("Error reading data from GPS." & ex.Message)
        End Try
    End Sub

    Private Sub ProcessGPSData(ByVal data As String)
        UpdateTextBox("Raw data :" & data)
        If Not data.StartsWith("$") OrElse data.Length < 6 Then
            ' UpdateGPSStatus("Invalid data")
            UpdateTextBox("Invalid data received.")
        End If

        If Not ValidateChecksum(data) Then
            UpdateTextBox("Checksum validation failed.invalid data")
        End If

      
        Try
            If data.StartsWith("$GPGGA") Then
                Dim parts As String() = data.Split(","c)

                If IsValidGPSData(data) Then
                    Dim latitude As String = parts(2)
                    Dim longitude As String = parts(4)
                    Dim altitude As String = parts(9)
                    Dim routeLat As String = parts(3)

                    Dim isLat As String = ConvertLatitude(latitude, routeLat)
                    Dim isLong As String = ConvertLongitude(longitude)
                    lastLatitude = isLat
                    lastLongitude = isLong
                    updateLatitudeTextBox(isLat)
                    updateLongitudeTextBox(isLong)
                    UpdateAltitudeTextBox(altitude)
                    UpdateTextBox("Latitude: " & latitude)
                    UpdateTextBox("Longitude: " & longitude)
                    UpdateTextBox("Altitude: " & altitude & " meters")
                    Dim currentLat As Double
                    Dim currentLong As Double

                    Try
                        currentLat = CDbl(isLat)
                        currentLong = CDbl(isLong)

                        ' If we have a previous position, calculate the distance
                        If Not Double.IsNaN(lastLatitude) AndAlso Not Double.IsNaN(lastLongitude) Then
                            Dim distance As Double = CalculateDistance(lastLatitude, lastLongitude, currentLat, currentLong) * 1000 ' in meters
                            totalDistance += distance
                            UpdateTextBox("Distance moved: " & Format(distance, "0.00") & " meters")
                            UpdateTextBox("Total distance: " & Format(totalDistance, "0.00") & " meters")

                            ' Check if we've passed a 25-meter checkpoint
                            While totalDistance - lastCheckpointDistance >= CheckpointInterval
                                lastCheckpointDistance += CheckpointInterval
                                Dim checkpointNumber As Integer = CInt(lastCheckpointDistance / CheckpointInterval)
                                SendMqttData()
                                'MessageBox.Show("You've traveled " & (checkpointNumber * CheckpointInterval) & " meters!", "Distance Checkpoint", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End While
                        End If

                        ' Update the last known position
                        lastLatitude = currentLat
                        lastLongitude = currentLong
                    Catch ex As InvalidCastException
                        UpdateTextBox("Error converting latitude or longitude to number.")
                    End Try

                Else
                    UpdateTextBox("Invalid $GPGGA data.")
                End If

            ElseIf data.StartsWith("$GPVTG") Then
                If IsValidGPVTG(data) Then
                    Dim parts As String() = data.Split(","c)
                    Dim speedKnots As String = parts(5)
                    Dim sog As Double = Convert.ToDouble(parts(5))


                    sog = sog * 1.852
                    Dim speedKmh As Double = parts(7)
                    ' lastSpeed = speedKmh
                    Dim bearing As Double = Convert.ToDouble(parts(1)) ' bearing  = COG ( Center of gravity )
                    'lastBearing = bearing
                    updateSOGTextBox(sog.ToString("F3"))

                    ' UpdateSpeedTextBox(speedKmh.ToString("F1"))
                    updateBearingTextBox(bearing)
                    UpdateTextBox("Speed (Knots) from $GPVTG:" & speedKnots)
                    'UpdateTextBox("Speed (km/h) from $GPVTG:" & speedKmh)
                Else
                    UpdateTextBox("Invalid $GPVTG data.")
                End If

            ElseIf data.StartsWith("$GPRMC") Then
                If IsValidGPRMC(data) Then
                    ' Dim lastLat As Double
                    'Dim lastLong As Double
                    Dim totalDistance As Double = 0.0
                    Dim parts As String() = data.Split(","c)
                    Dim latitude As String = parts(3) & " " & parts(4)
                    Dim longitude As String = parts(5) & " " & parts(6)
                    Dim speedKnots As Double = Convert.ToDouble(parts(7))
                    Dim speedKmh As Double = (CDbl(speedKnots * 1.852)).ToString("0.00")
                    Dim dateTime As String = "Date: " & parts(9) & "Time: " & parts(1)
                    Dim timeFormat As String = ConvertTimeToFormat(parts(1))
                    Dim dateFormat As String = ConvertDateToFormat(parts(9))

                    'If lastLat <> 0 And lastLong <> 0 Then
                    '    Dim distance As Double = CalculateDistance(lastLat, lastLong, longitude, longitude)
                    '    totalDistance += distance
                    'End If

                    'lastLat = latitude
                    'lastLong = longitude

                    'lastTotalDistance = totalDistance
                    'UpdateTotalDistanceTextBox(totalDistance.ToString("0.00"))
                    lastSpeed = speedKmh

                    updateDateTextBox(dateFormat)
                    updateTimeTextBox(timeFormat)
                    UpdateSpeedTextBox(speedKmh)
                    UpdateTextBox("Latitude: " & latitude)
                    UpdateTextBox("Longitude: " & longitude)
                    UpdateTextBox("Speed (Knots) from $GPRMC:" & speedKnots)
                    UpdateTextBox("Speed (kmh) from $GPRMC:" & speedKmh.ToString("F2"))
                Else
                    UpdateTextBox("Invalid $GPRMC data")
                End If
            End If


        Catch ex As Exception
            ' UpdateGPSStatus("Error")
            UpdateTextBox("Error processing GPS data: " & ex.Message)
        End Try
    End Sub

    Private Function ValidateChecksum(ByVal data As String) As Boolean
        Dim splitData As String() = data.Split("*"c)
        If splitData.Length <> 2 Then
            Return False
        End If

        Dim sentence As String = splitData(0).Substring(1)
        Dim checksum As String = splitData(1).Trim()

        Dim calculatedChecksum As Integer = 0
        For Each ch As Char In sentence
            calculatedChecksum = calculatedChecksum Xor Asc(ch)
        Next

        Return calculatedChecksum.ToString("X2") = checksum
    End Function

    Private Function IsValidGPSData(ByVal data As String) As Boolean
        If data.StartsWith("$GPGGA") Then
            Dim parts As String() = data.Split(","c)

            If parts.Length > 6 AndAlso parts(6) <> "0" AndAlso Not String.IsNullOrEmpty(parts(2)) AndAlso Not String.IsNullOrEmpty(parts(4)) Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Function IsValidGPVTG(ByVal data As String) As Boolean
        Dim parts As String() = data.Split(","c)
        If parts.Length >= 9 AndAlso Not String.IsNullOrEmpty(parts(5)) AndAlso Not String.IsNullOrEmpty(parts(7)) Then
            Return True
        End If
        Return False
    End Function

    Private Function IsValidGPRMC(ByVal data As String) As Boolean
        Dim parts As String() = data.Split(","c)
        If parts.Length >= 12 AndAlso parts(2) = "A" AndAlso Not String.IsNullOrEmpty(parts(7)) Then
            Return True
        End If
        Return False
    End Function

    Private Sub btnPilihRute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPilihRute.Click
        Dim routeForm As New frmRute()
        routeForm.Show()

    End Sub

   

    Private Function CalculateDistance(ByVal lat1 As Double, ByVal lon1 As Double, ByVal lat2 As Double, ByVal lon2 As Double) As Double
        ' Haversine formula to calculate distance between two points on Earth
        Dim R As Double = 6371 ' Radius of the Earth in km
        Dim radiusInMeter As Double = 6371000 ' Radius of the earth in meter
        Dim dLat As Double = (lat2 - lat1) * (PI / 180)
        Dim dLon As Double = (lon2 - lon1) * (PI / 180)
        Dim a As Double = Sin(dLat / 2) * Sin(dLat / 2) + Cos(lat1 * (PI / 180)) * Cos(lat2 * (PI / 180)) * Sin(dLon / 2) * Sin(dLon / 2)
        Dim c As Double = 2 * Atan2(Sqrt(a), Sqrt(1 - a))
        Dim distance As Double = radiusInMeter * c

        Return distance
    End Function
    Private Function ConvertTimeToFormat(ByVal time As String) As String
        If time.Length >= 6 Then
            Dim hours As String = time.Substring(0, 2)
            Dim minutes As String = time.Substring(2, 2)
            Dim seconds As String = time.Substring(4, 2)
            Return hours & ":" & minutes & ":" & seconds
        Else
            Return String.Empty
        End If
    End Function

    Private Function ConvertDateToFormat(ByVal dateValue As String) As String
        If dateValue.Length = 6 Then
            Dim day As String = dateValue.Substring(0, 2)
            Dim month As String = dateValue.Substring(2, 2)
            Dim year As String = "20" & dateValue.Substring(4, 2)
            Return year & "-" & month & "-" & day
        Else
            Return String.Empty
        End If
    End Function

    Private Function ConvertLongitude(ByVal isLongitude As String) As String
        Dim dLon As Double = Convert.ToDouble(isLongitude)
        dLon = dLon / 100
        Dim lon() As String = dLon.ToString().Split(".")

        'Longitude = nmeas(5).ToString() + lon(0).ToString() + "." + ((Convert.ToDouble(lon(1)) / 60)).ToString("#####")
        Return CDbl(Val(lon(0).ToString() + "." + ((Convert.ToDouble(lon(1)) / 60)).ToString("######")))

    End Function

    Private Function ConvertLatitude(ByVal isLatitude As String, ByVal routeLat As String) As String
        Dim dLat As Double = Convert.ToDouble(isLatitude)
        dLat = dLat / 100
        Dim lat() As String = dLat.ToString().Split(".")
        Dim latitude = lat(0).ToString() + "." + ((Convert.ToDouble(lat(1)) / 60)).ToString("######")
        Dim latValue As String

        If routeLat = "S" Then
            latValue = "-" + latitude
        Else
            latValue = latitude
        End If
        'Latitude = nmeas(3).ToString() + lat(0).ToString() + "." + ((Convert.ToDouble(lat(1)) / 60)).ToString("#####")
        Return CDbl(Val(latValue))
    End Function

    Private Sub SendMqttData()

        Dim latitude As Double = lastLatitude
        Dim longitude As Double = lastLongitude
        Dim speed As Double = lastSpeed
        Dim bearing As Double = lastBearing
        Dim totalDistance As Double = lastTotalDistance

        ' Convert the data to JSON format
        Dim jsonData As String = CreateJsonPayload(busBodyNo, busDeviceId, latitude, longitude, speed, bearing, totalDistance)

        ' Publish the JSON data to the specified topic
        mqttClient.Publish("/tracking/obu4g", System.Text.Encoding.UTF8.GetBytes(jsonData), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, False)

        ' Inform the user that data was sent
        ' MessageBox.Show("Data sent to MQTT broker.")
        lblMqttMsg.Text = "Data send to broker"
        ' updateMqttTextBox("Data sent to mqtt broker.")
    End Sub


    Private Function CreateJsonPayload(ByVal busBodyNo As String, ByVal busDeviceId As String, ByVal latitude As Double, ByVal longitude As Double, ByVal speed As Double, ByVal bearing As Integer, ByVal totalDistance As Long) As String
        Dim jsonFormat As String = "{{ ""busBodyNo"": ""{0}"", ""busDeviceId"" : ""{1}"", ""latitude"" : {2}, ""longitude"" : {3}, ""speed"" : {4}, ""bearing"": {5}, ""totalDistance"" : {6} }}"

        Return String.Format(jsonFormat, busBodyNo, busDeviceId, latitude.ToString("F7", System.Globalization.CultureInfo.InvariantCulture), longitude.ToString("F7", System.Globalization.CultureInfo.InvariantCulture), speed.ToString("F6", System.Globalization.CultureInfo.InvariantCulture), bearing, totalDistance)
    End Function


    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        lblTime.Text = DateTime.Now.ToString("HH:mm:ss")
        lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
    End Sub


    Private Sub Timer_Mqtt_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Mqtt.Tick
        If mqttClient.IsConnected Then
            SendMqttData()
            lblMqttMsg.Text = "data sent to broker"
        Else
            lblMqttMsg.Text = "Data not sent to broker"
        End If
        'If mqttClient.IsConnected AndAlso lastLatitude <> 0.0 AndAlso lastLongitude <> 0.0 AndAlso lastSpeed <> 0.0 AndAlso lastTotalDistance <> 0.0 Then
        '    SendMqttData()
        'Else
        '    txtMqttMsg.Text = "Data MQTT not send."
        'End If
    End Sub

    Private Sub btnOperasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOperasi.Click
        If btnOperasi.BackColor = Color.Black Then
            btnOperasi.BackColor = Color.Green
            Dim filePath As String = "\Flash Disk\\obu4g config\rute.txt"
            Try
                Using reader As New StreamReader(filePath)
                    Dim linesList As New List(Of String)

                    While Not reader.EndOfStream
                        linesList.Add(reader.ReadLine())
                    End While
                    lines = linesList.ToArray()
                End Using

                ' Display the first line in lblRute
                If lines.Length > 0 Then
                    currentIndex = 0
                    Dim rute As String = lines(currentIndex)
                    Dim parts() As String = rute.Split(","c)
                    Dim textKoridor As String = parts(0).Trim() + "|"
                    Dim length As Integer = Text.Length
                    Me.sendRunningText(textKoridor + parts(1).Trim(), 0, length)
                    Me.sendRunningText(textKoridor + parts(1).Trim(), 1, length)
                    Me.sendRunningText(textKoridor + parts(1).Trim(), 2, length)
                    Me.lblRoute.Text = parts(1).Trim()
                    Me.lblRouteCode.Text = parts(0).Trim()
                End If
            Catch ex As Exception
                MessageBox.Show("Error reading file:" & ex.Message)
            End Try
        Else
            btnOperasi.BackColor = Color.Black
            defaultRunningText()
        End If

        

    
    End Sub

    Private Sub defaultRunningText()
        Me.sendRunningText("TJ| TRANSJAKARTA", 0, 0)
        Me.sendRunningText("TJ| TRANSJAKARTA", 1, 0)
        Me.sendRunningText("TJ| TRANSJAKARTA", 2, 0)
    End Sub

    Private Sub BtnIsiBBM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIsiBBM.Click
        If BtnIsiBBM.BackColor = Color.Black Then
            BtnIsiBBM.BackColor = Color.Green
            Me.sendRunningText("PENGISIAN BAHAN BAKAR", 0, 0)
            Me.sendRunningText("PENGISIAN BAHAN BAKAR", 1, 0)
            Me.sendRunningText("PENGISIAN BAHAN BAKAR", 2, 0)
        Else
            BtnIsiBBM.BackColor = Color.Black
            defaultRunningText()
        End If

       
    End Sub


    Private Sub btnPergiPulang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPergiPulang.Click
        If btnPergiPulang.BackColor = Color.Black Then
            btnPergiPulang.BackColor = Color.Green
            Me.sendRunningText("MOHON MAAF TIDAK MELAYANI PENUMPANG", 0, 0)
            Me.sendRunningText("MAAF TIDAK MELAYANI PNP", 1, 0)
            Me.sendRunningText("TIDAK MELAYANI PNP", 2, 0)
        Else
            btnPergiPulang.BackColor = Color.Black
            defaultRunningText()
        End If

      
    End Sub

    Private Sub btnPanic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPanic.Click
        If btnPanic.BackColor = Color.Black Then
            btnPanic.BackColor = Color.Red
            Me.sendRunningText("GANGGUAN-TIDAK MELAYANI PNP", 0, 0)
            Me.sendRunningText("GANGGUAN-TIDAK MELAYANI PNP", 1, 0)
            Me.sendRunningText("GANGGUAN-TIDAK MELAYANI PNP", 2, 0)
        Else
            btnPanic.BackColor = Color.Black
            defaultRunningText()
        End If

        

    End Sub

    Private Sub playSoundByDistance()
        'Dim fileText As String = "PISDATA.txt"
        'If
        'File.Exists(fileText) then

    End Sub





    Public Sub sendRunningText(ByVal msg As String, ByVal addr As Integer, ByVal staticLeft As Integer)
     
        Dim textToSend As String = ""

        If LEDTYPE = "Y" Then
            Select Case addr
                Case 0
                    Text = "2"
                    If Me.pesanRTIndoor <> "" Then
                        msg = msg + "-" + Me.pesanRTIndoor
                    End If
                Case 1
                    Text = "2"
                    If Me.pesanRTSamping <> "" Then
                        msg = msg + "-" + Me.pesanRTSamping
                    End If
                Case 2
                    Text = "3"
            End Select
            textToSend = String.Concat(New String() {"$", addr.ToString(), staticLeft.ToString(), Text, msg, "%"})


        End If
        If LEDTYPE = "RG" Then
            Select Case addr
                Case 0
                    If pesanRTIndoor <> "" Then
                        msg = msg + "-" + pesanRTIndoor
                    End If
                Case 1
                    If pesanRTSamping <> "" Then
                        msg = msg + "-" + pesanRTSamping
                    End If
            End Select
            If msg.IndexOf("|"c) >= 0 Then
                Dim array As String() = msg.Split(New Char() {"|"c})
                textToSend = String.Concat(New String() {"$", addr.ToString(), "00", routeNumber, array(0), "|", routeText, array(1), "%"})
            Else
                textToSend = String.Concat(New String() {"$", addr.ToString(), "00", routeText, msg, "%"})
            End If
        End If




       
        If serialPortRT.IsOpen Then
            Try
                serialPortRT.Write(textToSend)
                TextBox2.Text = textToSend
            Catch ex As Exception
                MessageBox.Show("Error sending data: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Serial port is not open.")
        End If


    End Sub


    Private Sub lblRoute_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblRoute.ParentChanged

    End Sub

    Private Sub ButtonWelcome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWelcome.Click
        'wmp = New WindowsMediaPlayer
        Dim filePath As String = "Flash Disk\\voc\welcome.wav"

        Dim player = New SoundPlayer(filePath)
        If ButtonWelcome.BackColor = Color.Black Then
            ButtonWelcome.BackColor = Color.Red
            Try
                ' Create a new SoundPlayer instance

                ButtonWelcome.Enabled = False


                ' Load the .wav file
                player.Load()

                ' Play the sound (use PlaySync() to wait until the sound finishes playing)
                player.Play()
             

                Me.sendRunningText(String.Concat(New String() {DeviceID, "/", REGNO, "/", VECCODE}), 0, 0)
                Me.sendRunningText(String.Concat(New String() {DeviceID, "/", REGNO, "/", VECCODE}), 1, 0)
                Me.sendRunningText(String.Concat(New String() {DeviceID, "/", REGNO, "/", VECCODE}), 2, 0)
                ButtonWelcome.Enabled = True
            Catch ex As Exception
                ' Handle any exceptions (e.g., file not found)
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        Else
            ButtonWelcome.BackColor = Color.Black
            'waveOut.Stop()
            player.Stop()
        End If

    End Sub

    Private Sub readDataRute()
        Dim filePath As String = "\Flash Disk\\obu4g config\rute.txt"
        Try
            Using reader As New StreamReader(filePath)
                Dim linesList As New List(Of String)

                While Not reader.EndOfStream
                    linesList.Add(reader.ReadLine())
                End While
                lines = linesList.ToArray()
            End Using

            ' Display the first line in lblRute
            If lines.Length > 0 Then
                currentIndex = 0
                lblRute.Text = lines(currentIndex)
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading file:" & ex.Message)
        End Try
    End Sub

    Private Sub ReadDataSetting()
        Dim filePath As String = "\Flash Disk\\obu4g config\setting.txt"

        Try
            Using reader As New StreamReader(filePath)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim parts() As String = line.Split("="c)

                    If parts.Length = 2 Then
                        Select Case parts(0).Trim().ToUpper()
                            Case "DEVICEID"
                                DeviceID = parts(1).Trim()
                            Case "BUSBODYNO"
                                busBodyNo = parts(1).Trim()
                            Case "GPSPORT"
                                GPSCOMPORT = parts(1).Trim()
                            Case "GPSBAUDRATE"
                                GPSBAUDRATE = Convert.ToInt32(parts(1).Trim())
                            Case "RTPORT"
                                RTCOMPORT = parts(1).Trim()
                            Case "RTBAUDRATE"
                                RTBAUDRATE = Convert.ToInt32(parts(1).Trim())
                            Case "MQTTCLIENTBROKER"
                                MQTTBROKER = parts(1).Trim()
                            Case "MQTTPORT"
                                MQTTPORT = Convert.ToInt32(parts(1).Trim())
                            Case "LED"
                                LEDTYPE = parts(1).Trim()
                            Case "ROUTETEXT"
                                routeText = parts(1).Trim()
                            Case "ROUTENUMBER"
                                routeNumber = parts(1).Trim()
                            Case "REGNO"
                                REGNO = parts(1).Trim()
                            Case "VEC_CODE"
                                VECCODE = parts(1).Trim()
                        End Select
                    End If
                End While
            End Using

            ' At this point, all variables will hold the values from the text file.
            ' You can now use these variables as needed in your application.

        Catch ex As Exception
            MessageBox.Show("Error reading file:" & ex.Message)
        End Try
    End Sub


    Private Sub btnSytemTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSytemTest.Click
        If btnSytemTest.BackColor = Color.Black Then
            btnSytemTest.BackColor = Color.Red
            Me.sendRunningText("SISTEM TEST", 0, 0)
            Me.sendRunningText("SISTEM TEST", 1, 0)
            Me.sendRunningText("SISTEM TEST", 2, 0)
        Else
            btnSytemTest.BackColor = Color.Black
            defaultRunningText()
        End If

      
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If txtId.Text = "0" Then
            txtLayer.Visible = False
            txtId.Text = "1"
        Else
            txtLayer.Visible = True
            txtId.Text = "0"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.sendRunningText(TextBox1.Text, 0, 0)
        Me.sendRunningText(TextBox1.Text, 1, 0)
        Me.sendRunningText(TextBox1.Text, 2, 0)
    End Sub
End Class