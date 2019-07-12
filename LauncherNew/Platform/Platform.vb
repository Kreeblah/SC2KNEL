Module Platform
    Public Sub DelayRuntime(ByVal bythismanysecs)
        Dim time = Sys_FloatTime()
        While Sys_FloatTime() - time < bythismanysecs
            Application.DoEvents()
            Threading.Thread.Sleep(1)
        End While
    End Sub
    Private Delegate Sub CloseFormDelegate(ByVal form As Form)
    Public Sub CloseForm(ByVal form As Form)
        If form.InvokeRequired Then
            On Error GoTo Failed
            form.Invoke(New CloseFormDelegate(AddressOf CloseForm))
            Exit Sub
        Else
            form.Close()
            Exit Sub
        End If
Failed:
        'Me.Close()
    End Sub
    Private Delegate Sub LabelDelegate(ByVal target As Label, ByVal text As String)
    Public Sub SetLabelText(ByVal target As Label, ByVal text As String)
        If target.InvokeRequired Then
            target.Invoke(New LabelDelegate(AddressOf SetLabelText), text)
        Else
            target.Text = text
            target.FindForm.Refresh()
        End If
    End Sub
    Private Delegate Sub HideDelegate(ByVal targetform As Form)
    Public Sub HideForm(ByVal targetform As Form)
        If targetform.InvokeRequired Then
            targetform.Invoke(New HideDelegate(AddressOf HideForm))
        Else
            FormHide(targetform)
        End If
    End Sub
    Private Sub FormHide(ByVal targetform As Form)
        targetform.Opacity = 0
        targetform.Hide()
    End Sub
    Private Delegate Sub ShowDelegate(ByVal targetform As Form)
    Public Sub ShowForm(ByVal targetform As Form)
        If targetform.InvokeRequired Then
            targetform.Invoke(New ShowDelegate(AddressOf ShowForm))
        Else
            FormShow(targetform)
        End If
    End Sub
    Private Sub FormShow(ByVal targetform As Form)
        targetform.Opacity = 1
        targetform.Show()
    End Sub
    Public Function FormIsOpen(ByVal targetform As Form) As Boolean
        For i As Integer = 0 To Application.OpenForms.Count - 1
            Dim frm As Form = Application.OpenForms.Item(i)
            If frm.Name = targetform.Name Then Return True
        Next
        Return False
    End Function
    Public timer_frequency As Double = Stopwatch.Frequency
    Public Function Sys_FloatTime() As Double
        Dim tick As Double = Stopwatch.GetTimestamp
        Dim ms As Double = (tick / timer_frequency)
        Return ms
    End Function 'Gets the current time in seconds
    Public Function GetCommandLineArgs() As String
        Dim fullargs() As String = Environment.GetCommandLineArgs()
        Dim allargs As String = ""
        For Each a In fullargs
            If Not a = fullargs(0) Then
                allargs &= a & " "
            End If
        Next
        Return allargs
    End Function 'Returns all args as a single string, excluding path to the exe
    Public Function GetCommandLineArg(ByVal name As String) As Object
        Dim fullargs() As String = Environment.GetCommandLineArgs()
        Dim allargs As New List(Of String)
        For Each a In fullargs
            If Not a = fullargs(0) Then 'Don't return the path to the exe
                allargs.Add(a)
            End If
        Next
        If allargs.Contains(name) Then
            Dim num = allargs.IndexOf(name)
            Dim count = allargs.Count
            If count > num + 1 Then
                Return allargs(num + 1)
            Else
                Return True
            End If
        End If
        Return False

        'old useless code below
        'Dim argl As New Dictionary(Of String, String)
        'Dim argsingle As New List(Of String)
        'Dim arg = System.Environment.GetCommandLineArgs
        'Dim hasargs = False
        'If arg.Length > 1 Then
        '    hasargs = True
        'End If
        'Dim key As String = ""
        'Dim value As String = ""
        'For i As Integer = 0 To arg.Length - 1
        '    Dim temp = arg(i)
        '    If temp.StartsWith("-") Then
        '        key = temp
        '        argsingle.Add(key.ToLower)
        '    ElseIf key.Length > 0 Then
        '        value = temp
        '        If argl.ContainsKey(key) Then
        '            argl(key) = value
        '        Else
        '            argl.Add(key, value)
        '        End If
        '        key = ""
        '    End If
        'Next

        'For Each arg As String In Environment.GetCommandLineArgs()
        '    If arg.Contains("-tobrowser") Then
        '        SplashScreen.browseservers_btn.Enabled = False
        '        SplashScreen.browseservers_btn.BackgroundImage = My.Resources.Resources.serverlist_disabled
        '        ShowForm(ServerBrowser)
        '    End If
        '    If arg.Contains("+connect") Then
        '        If ExtraCommandLineArgs.Contains("-toconsole") Then ExtraCommandLineArgs = ExtraCommandLineArgs.Replace("-toconsole ", "")
        '    ElseIf arg.Contains("-fullscreen") Then
        '        If ExtraCommandLineArgs.Contains("-windowed") Then ExtraCommandLineArgs = Args.Replace("-windowed", "")
        '    End If
        '    If Not Args = " " Then
        '        If arg.ToLower = "-dedicated" Then
        '            Dedicated = True
        '            If Args.Length > 0 Then
        '                Args += " " & arg
        '            Else
        '                Args += arg
        '            End If
        '        Else
        '            If Args.Length > 0 Then
        '                Args += " " & arg
        '            Else
        '                Args += arg
        '            End If
        '        End If
        '    Else
        '        CPath = arg
        '        Args = ""
        '    End If
        'Next arg
    End Function 'Returns if an arg exists and its value if it has one
End Module
