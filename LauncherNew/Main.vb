Public Class Main
    Public Sub New()
        Dim MainThread As New Threading.Thread(AddressOf Main)
        MainThread.Start()
    End Sub
    'Private Sub CheckForExit()
    '    While Not ExitGlobally
    '        Threading.Thread.Sleep(10)
    '    End While
    '    CloseForm(ServerBrowser)
    '    CloseForm(UpdateMessageBox)
    '    CloseForm(InputServerPassword)
    '    CloseForm(AddAServer)
    '    CloseForm(Settings)
    '    CloseForm(SplashScreen)
    'End Sub
    Public Sub Main()
        DoStartupTasks()
        'LoadConfig()
        'DelayStartup()
        ShowForm(SplashScreen)
        SplashScreen.DisableButtons()
        If NoUpdate Then
            SetLabelText(SplashScreen.SplashScreenInfoLabel, "Update check has been disabled")
        Else
            SetLabelText(SplashScreen.SplashScreenInfoLabel, "Checking for updates...")
            If GetDownloadSocket() Then
                If Not CheckAndDownloadForUpdates() Then
                    SetLabelText(SplashScreen.SplashScreenInfoLabel, "Failed to check for updates...")
                Else
                    SetLabelText(SplashScreen.SplashScreenInfoLabel, "Completed updates...")
                End If
            End If
        End If
        SplashScreen.EnableButtons()
        While Not ExitGlobally
            If Not SplashScreenText = String.Empty Then
                'absolute shit code because nothing i try works to set the label from another thread
                If Not SplashScreen.SplashScreenInfoLabel.Text = SplashScreenText Then
                    SetLabelText(SplashScreen.SplashScreenInfoLabel, SplashScreenText)
                End If
            End If
            Application.DoEvents()
            Threading.Thread.Sleep(40)
        End While
        'All Done, Close everything
        ExitGlobally = True
    End Sub
    Public Shared SplashScreenText As String = String.Empty

    Private Sub DelayStartup()
        Dim AbsStartTime = Sys_FloatTime()
        While ((Sys_FloatTime() - AbsStartTime) < 3) Or (FormIsOpen(ServerBrowser))
            If ExitGlobally Then Exit While
            Application.DoEvents()
            Threading.Thread.Sleep(1)
        End While
    End Sub
    Private Sub DoStartupTasks()
        'If IO.File.Exists(IO.Directory.GetCurrentDirectory & "\d3d8.dll") Then
        '    Dim d3d8hash = Hash(IO.Directory.GetCurrentDirectory & "\d3d8.dll")
        '    If d3d8hash = "42CD3139B69A53F140BD18C063F72D3F" Then
        '        DeleteFile(IO.Directory.GetCurrentDirectory & "\d3d8.dll")
        '    End If
        'End If
        ProcessesKillAll("Updater")
        DeleteIfExists("Updater.exe")

        If GetCommandLineArg("-tobrowser") <> NULL Then
            ShowForm(ServerBrowser)
        Else
            ShowForm(SplashScreen)
        End If
        CPath = Environment.GetCommandLineArgs(0)
        CurrentDir = IO.Directory.GetCurrentDirectory
        If Not IO.File.Exists(CurrentDir & "\2kclient.exe") Then
            If IO.File.Exists(CurrentDir & "\2knet\2kclient.exe") Then
                CurrentDir &= "\2knet"
            Else
                MsgBox("ERROR: Could not find 2kclient.exe!", MsgBoxStyle.Critical)
                Throw New Exception("ERROR: Could not find 2kclient.exe!")
            End If
        End If
        ServerHash = Hash(CurrentDir & "\2kserver.exe")
        ClientHash = Hash(CurrentDir & "\2kclient.exe")

        'If IO.File.Exists("2knet\") Then EngineHash = Hash("engine.dll")
    End Sub
End Class
