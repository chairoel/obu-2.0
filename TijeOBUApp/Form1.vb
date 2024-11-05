Imports System.IO.Ports
Imports System
Imports System.Media
Imports WMPLib
Imports System.IO
Imports System.IO.File

Public Class frmRute
    Private lines As String()
    Private currentIndex As Integer = 0
    Private SerialPort1 As New SerialPort()
    Private pesanRtSamping As String = ""
    Private pesanRTIndoor As String = ""
    Private LEDTYPE = "RG"
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterFormOnScreen()
        '' Configure the serial port
        'SerialPort1.PortName = "COM4"
        'SerialPort1.BaudRate = 2400
        'SerialPort1.DataBits = 8
        'SerialPort1.Parity = Parity.None
        'SerialPort1.StopBits = StopBits.One
        'SerialPort1.Handshake = Handshake.None

        '' Open the serial port
        'Try
        '    SerialPort1.Open()
        'Catch ex As Exception
        '    MessageBox.Show("Error opening serial port: " & ex.Message)
        'End Try

        'LoadFileContents()
        'UpdateDisplay()

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

    Private Sub SendData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendData.Click
        ' Assuming you have a TextBox named TextBox1 for input

        Me.sendRunningText(TextBox1.Text, 0, 0)
        ' Send the data
        'If SerialPort1.IsOpen Then
        '    Try

        '    Catch ex As Exception
        '        MessageBox.Show("Error sending data: " & ex.Message)
        '    End Try
        'Else
        '    MessageBox.Show("Serial port is not open.")
        'End If
    End Sub

    Private Sub sendRunningText(ByVal msg As String, ByVal addr As Integer, ByVal staticLeft As Integer)
        Dim routeNumber As String = "~"
        Dim routeText As String = "~"
        Dim textToSend As String = ""

        'If LEDTYPE = "Y" Then
        '    Select Case addr
        '        Case 0
        '            Text = "2"
        '            If Me.pesanRTIndoor <> "" Then
        '                msg = msg + "-" + Me.pesanRTIndoor
        '            End If
        '        Case 1
        '            Text = "2"
        '            If Me.pesanRTSamping <> "" Then
        '                msg = msg + "-" + Me.pesanRTSamping
        '            End If
        '        Case 2
        '            Text = "3"
        '    End Select
        '    textToSend = String.Concat(New String() {"$", addr.ToString(), staticLeft.ToString(), Text, msg, "%"})


        'Else
        Select Case addr
            Case 0
                If pesanRTIndoor <> "" Then
                    msg = msg + "-" + pesanRTIndoor
                End If
            Case 1
                If pesanRtSamping <> "" Then
                    msg = msg + "-" + pesanRtSamping
                End If
        End Select
        If msg.IndexOf("|"c) >= 0 Then
            Dim array As String() = msg.Split(New Char() {"|"c})
            textToSend = String.Concat(New String() {"$", addr.ToString(), "00", routeNumber, array(0), "|", routeText, array(1), "%"})
        Else
            textToSend = String.Concat(New String() {"$", addr.ToString(), "00", routeText, msg, "%"})
        End If
        ' End If


        TextBox1.Text = textToSend

        'If serialPort.IsOpen Then serialPort.Close()
        'serialPortRT = New SerialPort("COM4", 2400, Parity.None, 8, StopBits.None)
        ' SerialPort1.Open()
        ' Send the data
        If SerialPort1.IsOpen Then
            Try
                SerialPort1.Write(textToSend)
                ' serialPortRT.Close()
                ' serialPort.Open()
            Catch ex As Exception
                MessageBox.Show("Error sending data: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Serial port is not open.")
        End If

        'Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '    ' Close the serial port when the form is closing
        '    If SerialPort1.IsOpen Then
        '        SerialPort1.Close()
        '    End If
        'End Sub
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim wavFile As String = "Flash Disk\\voc\welcome.wav"
        Try
            ' Create a new SoundPlayer instance
            Dim player As New SoundPlayer(wavFile)

            ' Load the .wav file
            player.Load()

            ' Play the sound (use PlaySync() to wait until the sound finishes playing)
            player.Play()

        Catch ex As Exception
            ' Handle any exceptions (e.g., file not found)
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub btnPilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPilih.Click
        Dim inputRoute As String = Me.lblRute.Text
  
        Dim parts() As String = inputRoute.Split(","c)
        Dim textKoridor As String = parts(0).Trim() + "|"
        Dim length As Integer = Text.Length
        FormOBU.sendRunningText(textKoridor + parts(1).Trim(), 0, length)
        FormOBU.sendRunningText(textKoridor + parts(1).Trim(), 1, length)
        FormOBU.sendRunningText(textKoridor + parts(1).Trim(), 2, length)
        FormOBU.lblRoute.Text = parts(1).Trim()
        FormOBU.lblRouteCode.Text = parts(0).Trim()
        Me.Close()

    End Sub
    Private Sub LoadFileContents()
       
        Dim filePath As String = "\Flash Disk\\obu4g config\rute.txt"
        Dim lines As String()

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
                lblRute.Text = lines(0)
                currentIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading file:" & ex.Message)
        End Try
        'Try
        '    If Not File.Exists(filePath) Then
        '        MessageBox.Show("File not found: " & filePath)
        '        Return
        '    End If

        '    Using reader As New StreamReader(filePath)
        '        Dim line As String
        '        While Not reader.EndOfStream
        '            line = reader.ReadLine()
        '            If Not String.IsNullOrEmpty(line) Then
        '                lines.Add(line)
        '            End If
        '        End While
        '    End Using

        '    If lines.Count > 0 Then
        '        currentIndex = 0
        '    Else
        '        MessageBox.Show("No valid lines found in the file.")
        '    End If

        'Catch ex As IOException
        '    MessageBox.Show("IO Error reading file: " & ex.Message)
        'Catch ex As UnauthorizedAccessException
        '    MessageBox.Show("Access denied to file: " & ex.Message)
        'Catch ex As Exception
        '    MessageBox.Show("Unexpected error reading file: " & ex.Message & vbNewLine & "Stack Trace: " & ex.StackTrace)
        'End Try
    End Sub

    'Private Sub UpdateDisplay()
    '    If lines IsNot Nothing AndAlso currentIndex >= 0 AndAlso currentIndex < lines.Count Then
    '        lblRute.Text = lines(currentIndex)
    '    Else
    '        lblRute.Text = "No data to display"
    '    End If

    '    btnPrev.Enabled = (lines IsNot Nothing AndAlso currentIndex > 0)
    '    btnNext.Enabled = (lines IsNot Nothing AndAlso currentIndex < lines.Count - 1)
    'End Sub


    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        'If lines IsNot Nothing AndAlso currentIndex > 0 Then
        '    currentIndex -= 1
        '    UpdateDisplay()
        'End If

        If currentIndex > 0 Then
            currentIndex -= 1
            lblRute.Text = lines(currentIndex)
        Else
            MessageBox.Show("Already at the first line.")
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'If lines IsNot Nothing AndAlso currentIndex < lines.Count - 1 Then
        '    currentIndex += 1
        '    UpdateDisplay()
        'End If
        If currentIndex < lines.Length - 1 Then
            currentIndex += 1
            lblRute.Text = lines(currentIndex)
        Else
            MessageBox.Show("Already at the last line.")
        End If
    End Sub

    Private Sub CenterFormOnScreen()
        ' Calculate the center position
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height

        ' Set the form's position to the center of the screen
        Me.Left = (screenWidth - formWidth) \ 2
        Me.Top = (screenHeight - formHeight) \ 2
    End Sub
 
End Class