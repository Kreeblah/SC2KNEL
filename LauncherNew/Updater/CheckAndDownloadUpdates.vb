Module CheckAndDownloadUpdates
    Public Hosts As New Queue(Of String) 'List of hosts
    Public Host As String = "" 'Host being used
    Public Info As String = ""
    Public wClient As New Net.WebClient
    Public cp As New crypt
    Public key As String = cp.EncryptString128Bit("mvzgbcjnchxhpksioszfaxbyoeleiwxn", "izlpktncrfizxfrohzsocxbupyafrcjt")
    Public UnzipQueue As New Queue(Of String) 'Unzip queue
    Public UnzipListDone As Boolean = False 'Unzip list done
    Public UnzipFinished As Boolean = True 'Unzip finished
    Public ExecuteList As New Queue(Of String) 'Execute list
    Public ExecuteListDontRunGame As New Queue(Of String) 'Execute list (Don't Run Game)
    Public ServerHash As String = "" 'Server Hash
    Public ClientHash As String = "" 'Client Hash
    Public RequiresUpdate As Boolean = False 'Requires update
    Public UnzipThread As New Threading.Thread(AddressOf Unzip) 'Unzip Thread
    Public PressedNoToUpdate As Boolean = False
    Public Sub Download(ByVal Address As String, ByVal Path As String) 'Thread that handles downloading
        SetLabelText(SplashScreen.SplashScreenInfoLabel, "Downloading available updates")
        Do
            DeleteIfExists(Path)
            If My.Computer.Network.IsAvailable Then
                Try
                    If ExitGlobally Then Exit Sub
                    wClient.DownloadFile(Address, Path) 'Download the update
                    Exit Do
                Catch ex As Exception
                    If Hosts.Count > 0 Then
                        Host = Hosts.Dequeue 'Try another download mirror, the last one failed
                    Else
                        MsgBox("ERROR 1: FAILED TO DOWNLOAD UPDATE, CLOSING! Reason: " & ex.Message)
                        ExitGlobally = True
                        Exit Sub
                    End If
                End Try
            End If
        Loop
    End Sub
    Public Function GetDownloadSocket() As Boolean
        Hosts.Enqueue("http://nightfirepc.com/simcitypatches")
        Host = Hosts.Dequeue 'get a mirror to check for updates
        Do
Retry:
            Dim spl1 = Host.Replace("http://", "")
            spl1 = spl1.Replace("\", "/")
            Dim spl2 = spl1.Split("/")
            SetLabelText(SplashScreen.SplashScreenInfoLabel, "Connecting to " & spl2(0))
            Application.DoEvents()
            If My.Computer.Network.IsAvailable Then
                Try
                    SetLabelText(SplashScreen.SplashScreenInfoLabel, "Connected, Checking for Updates")
                    Application.DoEvents()
                    If GetCommandLineArg("-dedicated") <> NULL Then 'Is this a dedicated server or a client?
                        Info = System.Text.Encoding.ASCII.GetString(wClient.DownloadData(Host & "/server.text"))
                    Else
                        Info = System.Text.Encoding.ASCII.GetString(wClient.DownloadData(Host & "/client.text"))
                    End If
                    Info = cp.DecryptString128Bit(Info, key)
                    If Not Info.StartsWith("0:") Then
                        SetLabelText(SplashScreen.SplashScreenInfoLabel, "Invalid file, trying another mirror")
                        Application.DoEvents()
                        If Hosts.Count > 0 Then
                            Host = Hosts.Dequeue
                            GoTo retry
                        Else
                            SetLabelText(SplashScreen.SplashScreenInfoLabel, "Failed to check for updates!")
                            Application.DoEvents()
                            Return False
                        End If
                    End If
                    Return True
                Catch ex As Exception
                    If Hosts.Count > 0 Then
                        Host = Hosts.Dequeue
                    Else
                        SetLabelText(SplashScreen.SplashScreenInfoLabel, "Failed to check for updates!")
                        DelayRuntime(2)
                        Return False
                    End If
                End Try
            Else
                SetLabelText(SplashScreen.SplashScreenInfoLabel, "WARNING: No Internet Connection!")
                DelayRuntime(2)
                Return False
            End If
        Loop
        Return False
    End Function
    Public Function CheckAndDownloadForUpdates()
        Dim InfoReader As New IO.StringReader(Info) 'Info reader
        Dim UpdateList As New Queue(Of String) 'Update list
        Dim AlwaysUpdateList As New Queue(Of String) 'Always update list
        Dim AlwaysUpdateListNotExtracted As New Queue(Of String) 'Always update list(not extracted)
        Dim DownloadAndMerge As New Queue(Of Merge) 'Download and merge
        Dim UpdateIsAvailable As Boolean = False 'An Update Is Available (Any)
        'Dim wp As WindowsPrincipal = New WindowsPrincipal(WindowsIdentity.GetCurrent)
        'Dim admin As Boolean = wp.IsInRole(WindowsBuiltInRole.Administrator)
        Dim admin As Boolean = IsDirectoryWritable(Environment.CurrentDirectory)
        While (InfoReader.Peek > 0)
            Try
                Dim Ln As String() = InfoReader.ReadLine().Split(":")
                Select Case Ln(0)
                    Case 0
                        If Not Ln(1) = ServerHash Then
                            RequiresUpdate = True
                            UpdateIsAvailable = True
                        End If
                    Case 1
                        UpdateList.Enqueue(Host & "/" & Ln(1))
                    Case 2
                        If UpdateIsAvailable Or admin Then
                            AlwaysUpdateList.Enqueue(Host & "/" & Ln(1))
                        End If
                    Case 3
                        If UpdateIsAvailable Or admin Then
                            AlwaysUpdateListNotExtracted.Enqueue(Host & "/" & Ln(1))
                        End If
                    Case 4
                        Try
                            wClient.DownloadData(Ln(1))
                        Catch ex As Exception
                        End Try
                    Case 5
                        Dim IHash As String = ""
                        If Ln(2).ToLower = "bond.exe" Then
                            Ln(2) = Globals.CPath
                        End If
                        If IO.File.Exists(Ln(2)) Then
                            IHash = Hash(Ln(2))
                        End If
                        If Not IHash = Ln(1) Then
                            UpdateIsAvailable = True
                            AlwaysUpdateList.Enqueue(Host & "/" & Ln(3))
                        End If
                    Case 6
                        If UpdateIsAvailable Then
                            If Not Globals.AlwaysUpdate Then
                                If Ln(1).Contains("\") Then
                                    Ln(1) = Ln(1).Replace("\", ControlChars.NewLine)
                                End If
                                SetLabelText(SplashScreen.SplashScreenInfoLabel, "A new version is available")
                                UpdateMessageBox.textbox.Text = UpdateMessageBox.textbox.Text & Ln(1)
                                UpdateMessageBox.Text = Ln(2)

                                Application.DoEvents()

                                UpdateMessageBox.Show()  'Show the message box that an update is available and its changelog
                                UpdateMessageBox.TopMost = True

                                While UpdateMessageBox.done = False
                                    If UpdateMessageBox.Visible = False Then
                                        Exit While
                                    End If
                                    Application.DoEvents()
                                    Threading.Thread.Sleep(10)
                                End While

                                UpdateMessageBox.Hide()

                                If UpdateMessageBox.updatee = False Then
                                    Globals.NoUpdate = True
                                    PressedNoToUpdate = True
                                    'Close()
                                    Return False
                                Else
                                    If Not admin Then
                                        MsgBox("ERROR: Not running as administrator! Cannot update game.", MsgBoxStyle.Critical)
                                        ExitGlobally = True
                                        Return False
                                    End If
                                End If
                                UpdateMessageBox.Close()
                            End If
                        End If
                    Case 7
                        Dim cf As String = ""
                        Try
                            cf = IO.File.ReadAllText(Ln(2))
                        Catch ex As Exception
                        End Try
                        If Not cf.ToLower.Contains(Ln(1).ToLower) Then
                            UpdateIsAvailable = True
                            DownloadAndMerge.Enqueue(New Merge(Ln(3), Ln(2)))
                        End If
                    Case 8
                        Globals.ExtraCommandLineArgs &= Ln(1) & " "
                    Case 9
                        ExecuteListDontRunGame.Enqueue(Ln(1))
                    Case 10
                        ExecuteList.Enqueue(Ln(1))
                    Case 11
                        'optional update, only download if file doesn't exist
                        Dim IHash As String = ""
                        If Ln(2).ToLower = "bond.exe" Then
                            Ln(2) = Globals.CPath
                        End If
                        If Not IO.File.Exists(Ln(2)) Then
                            UpdateIsAvailable = True
                            AlwaysUpdateList.Enqueue(Host & "/" & Ln(3))
                        End If
                End Select
            Catch ex As Exception
            End Try
        End While
        Try
            UnzipThread.Start()
        Catch ex As Exception
        End Try
        If RequiresUpdate Then
            While UpdateList.Count > 0
                Try
                    SetLabelText(SplashScreen.SplashScreenInfoLabel, "Downloading available updates")
                    Dim temp As String = UpdateList.Dequeue
                    Dim name1 As String() = temp.Split("/")
                    Dim name As String = name1(name1.Length - 1)
                    Dim tp As String = System.IO.Path.GetTempPath
                    Download(temp, tp & name)
                    UnzipQueue.Enqueue(tp & name)
                Catch ex As Exception
                End Try
            End While
        End If
        While AlwaysUpdateList.Count > 0
            Try
                SetLabelText(SplashScreen.SplashScreenInfoLabel, "Downloading available updates")
                Dim temp As String = AlwaysUpdateList.Dequeue
                Dim name1 As String() = temp.Split("/")
                Dim name As String = name1(name1.Length - 1)
                Dim tp As String = System.IO.Path.GetTempPath
                Download(temp, tp & name)
                UnzipQueue.Enqueue(tp & name)
            Catch ex As Exception
            End Try
        End While
        While AlwaysUpdateListNotExtracted.Count > 0
            Try
                SetLabelText(SplashScreen.SplashScreenInfoLabel, "Downloading available updates")
                Dim temp As String = AlwaysUpdateList.Dequeue
                Dim name1 As String() = temp.Split("/")
                Dim name As String = name1(name1.Length - 1)
                Dim tp As String = System.IO.Path.GetTempPath
                Download(temp, System.IO.Directory.GetCurrentDirectory & "\" & name)
            Catch ex As Exception
            End Try
        End While
        UnzipListDone = True
        While DownloadAndMerge.Count > 0
            Try
                Dim temp As Merge = DownloadAndMerge.Dequeue
                Dim tp As String = System.IO.Path.GetTempPath
                Dim data As String = System.Text.Encoding.ASCII.GetString(wClient.DownloadData(Host & "/" & temp.Download))
                My.Computer.FileSystem.WriteAllText(temp.Merge, ControlChars.NewLine & data, False)
            Catch ex As Exception
            End Try
        End While
        While UnzipQueue.Count > 0
            Application.DoEvents()
            Threading.Thread.Sleep(33)
        End While
        While Not UnzipFinished
            Application.DoEvents()
            Threading.Thread.Sleep(33)
        End While
        For Each a As String In ExecuteList
            Try
                'Dim executelist As Process = Process.Start(a, AppWinStyle.Hide)
                Shell(a, AppWinStyle.Hide, False)
            Catch ex As Exception
            End Try
        Next
        Dim c As Boolean = False
        If ExecuteListDontRunGame.Count > 0 Then c = True
        For Each a As String In ExecuteListDontRunGame
            Try
                'Dim executeliste As Process = Process.Start(a, AppWinStyle.Hide)
                Shell(a, AppWinStyle.Hide, False)
            Catch ex As Exception
            End Try
        Next
        If c Then
            ExitGlobally = True
            Return False
        End If
        Return True
    End Function 'return false on failure
    Public Sub Unzip() 'Handles unzipping downloaded files
        Dim x As New ICSharpCode.SharpZipLib.Zip.FastZip
        'All Zip files must be encrypted with password: 13374355
        Dim p As String = cp.DecryptString128Bit("6C494FA55A68E84A528A89CB8BFE4DE6", key)
        Do
            Try
                Dim UZ As String = UnzipQueue.Dequeue
                Try
                    UnzipFinished = False
                    x.RestoreAttributesOnExtract = True
                    x.Password = p
                    x.ExtractZip(UZ, IO.Directory.GetCurrentDirectory, "-\.db$")
                    IO.File.Delete(UZ)
                    UnzipFinished = True
                Catch ex As Exception
                    DeleteIfExists(UZ)
                End Try
            Catch ex As Exception
                If UnzipListDone And (UnzipQueue.Count = 0) Then
                    UnzipFinished = True
                    Exit Do
                End If
            End Try
            If ExitGlobally Then Exit Do
            Application.DoEvents()
            Threading.Thread.Sleep(1)
        Loop
    End Sub
    Public Class Merge
        Public Download As String
        Public Merge As String
        Public Sub New(ByVal Dl As String, ByVal File As String)
            Download = Dl
            Merge = File
        End Sub
    End Class
    Public Class HashFileDownload
        Public Hash As String
        Public File As String
        Public Download As String
        Public Sub New(ByVal H As String, ByVal F As String, ByVal D As String)
            Hash = H
            File = F
            Download = D
        End Sub
    End Class
End Module
