Module Server
    Private PublicServer As Boolean = True
    Private CityName As String
    Private PlayerCount As Byte
    Const MaxPlayers As Byte = 4
    Private Port As Integer = 2586 'TCP = server UDP = query
    Public Sub StartServer()
        For Each proc As Process In Process.GetProcessesByName("2kserver")
            Dim warning = MsgBox("Error: An existing 2kserver was found running. Do you want to close it? YOUR CITY WILL NOT BE SAVED!", MsgBoxStyle.YesNo)
            If warning = MsgBoxResult.Yes Then
                proc.Kill()
            Else
                Exit Sub
            End If
        Next
        SplashScreen.DisableButtons()
        If SplashScreen.privserver.Checked Then PublicServer = False
        SetLabelText(SplashScreen.SplashScreenInfoLabel, "Waiting for server to start...")
        Dim serverthr As New Threading.Thread(AddressOf ServerThread)
        serverthr.Start()
    End Sub
    Private Sub ServerThread()

        Main.SplashScreenText = "Attempting to forward port " & Port & " TCP..."
        Threading.Thread.Sleep(1000)
        Dim porti As New ProcessStartInfo
        porti.WorkingDirectory = CurrentDir
        porti.FileName = CurrentDir & "\port " & Port & " - enable.bat"
        porti.UseShellExecute = True
        Dim portforward As New Process
        portforward.StartInfo = porti
        portforward.Start()

        Main.SplashScreenText = "Attempting to forward port " & Port & " UDP..."
        Threading.Thread.Sleep(1000)
        porti.FileName = CurrentDir & "\port " & Port & "u - enable.bat"
        Dim portforwardquery As New Process
        portforwardquery.StartInfo = porti
        portforwardquery.Start()

        Main.SplashScreenText = "Starting 2KServer..."
        Dim sc2knesi As New ProcessStartInfo
        sc2knesi.WorkingDirectory = CurrentDir
        sc2knesi.FileName = CurrentDir & "\2KSERVER.exe"
        sc2knesi.UseShellExecute = False
        Dim sc2knes As New Process
        sc2knes.StartInfo = sc2knesi
        sc2knes.Start()
        Threading.Thread.Sleep(1000)

        If Not PublicServer Then
            ExitGlobally = True
            Exit Sub
        End If

        If Not sc2knes.HasExited Then
            mem = New ProcessMemory(sc2knes, ProcessMemory.ProcessAccess.VMRead)
            mem.Open()
        End If

        Main.SplashScreenText = "Waiting for city to start..."
        'Wait until server has started
        While mem.Read(&H47E560, 1)(0) = 0
            Threading.Thread.Sleep(500)
            If sc2knes.HasExited Then
                ExitGlobally = True
                Return
            End If
        End While
        CityName = mem.ReadString(&H47E560, 32, System.Text.ASCIIEncoding.ASCII)
        Main.SplashScreenText = "Server is ready, do not close this window..."
        Dim querythread As New Threading.Thread(AddressOf QueryListener)
        querythread.Start()
        Heartbeat(sc2knes)
        ExitGlobally = True
    End Sub
    Private sudp As Net.Sockets.UdpClient = Nothing
    Private Sub QueryListener()
        Try
            sudp = New Net.Sockets.UdpClient(Port)
        Catch ex As Exception
            ExitGlobally = True
            MsgBox("ERROR: Could not create network socket on UDP port " & Port & ", reason: " & ex.Message, MsgBoxStyle.Critical)
            Return
        End Try
        sudp.Client.ReceiveTimeout = 1000
        sudp.Client.SendTimeout = 1000
        Dim lastQuery As New Dictionary(Of Long, Integer)
        Dim lastQuery2 As New List(Of Long)
        Dim queryid As ULong = 0
        While Not ExitGlobally
            Dim rep As New Net.IPEndPoint(Net.IPAddress.Any, 0)
            Dim query As String = Recv(sudp, rep)
            If lastQuery.Count > 0 Then
                For Each a In lastQuery
                    If (Environment.TickCount - a.Value) >= 500 Then
                        lastQuery2.Add(a.Key)
                    End If
                Next
                For Each a In lastQuery2
                    lastQuery.Remove(a)
                Next
            End If
            If lastQuery.ContainsKey(rep.Address.Address) Then Continue While
            If query.Length > 0 Then
                If queryid >= UInt64.MaxValue Then
                    queryid = 0
                Else
                    queryid += 1
                End If
                PlayerCount = mem.Read(&H488FEA, 1)(0)
                Dim s_status As Byte() = System.Text.Encoding.ASCII.GetBytes("\gamename\sc2kne\gamever\1.0\gamemode\openplaying\hostport\" & Port & "\maxplayers\" & MaxPlayers & "\hostname\" & CityName & "\numplayers\" & PlayerCount & "\password\0\final\\queryid\" & queryid)
                Dim s_info As Byte() = s_status
                If query.StartsWith("\info\") Then
                    Send(rep.Address.ToString, rep.Port, s_info, sudp)
                    Main.SplashScreenText = "Received info query from " & rep.Address.ToString & " at " & DateTime.Now
                ElseIf query.StartsWith("\status\") Then
                    Main.SplashScreenText = "Received status query from " & rep.Address.ToString & " at " & DateTime.Now
                    Send(rep.Address.ToString, rep.Port, s_status, sudp)
                End If
            End If
        End While

    End Sub
    Private Sub Heartbeat(ByVal proc As Process)
        If ExitGlobally Then Return
        Dim dns As Net.IPHostEntry = System.Net.Dns.GetHostEntry(ServerBrowser.masterip)
        Dim masterip2 = dns.AddressList(0)
        Dim endpoint As New Net.IPEndPoint(masterip2, 27900)
        Dim nextheartbeat As Integer = 0
        While Not ExitGlobally
            If proc.HasExited Then Return
            If Environment.TickCount >= nextheartbeat Then
                nextheartbeat = Environment.TickCount + 30000
                Try
                    ServerBrowser.SendPacket(endpoint.Address.ToString, endpoint.Port, System.Text.Encoding.ASCII.GetBytes("\heartbeat\" & Port & "\"), sudp)
                Catch ex As Exception
                    nextheartbeat = Environment.TickCount + 1000
                End Try
            End If
            Threading.Thread.Sleep(1000)
        End While
    End Sub
    Public Sub Send(ByVal host As String, ByVal port As Integer, ByVal data As Byte(), ByVal client As Net.Sockets.UdpClient)
        Try
            client.Send(data, data.Length, host, port)
        Catch ex As Exception
        End Try
    End Sub
    Public Function Recv(ByVal client As Net.Sockets.UdpClient, ByRef endpoint As Net.IPEndPoint) As String
        Dim a As String = ""
        Try
            a = System.Text.Encoding.ASCII.GetString(client.Receive(endpoint))
        Catch ex As Exception
        End Try
        Return a
    End Function
End Module
