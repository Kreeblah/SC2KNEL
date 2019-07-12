Public Class SplashScreen
    Public Shared SplashLabel As String = "Waiting..."


    'Draggable form taken from http://www.dreamincode.net/forums/topic/171832-draggable-form-without-border/
    'Declare the variables
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub SplashScreen_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub SplashScreen_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub
    Private Sub SplashScreen_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
    'End of dragging form

    Private Sub CloseMe()
        While Not ExitGlobally
            Threading.Thread.Sleep(100)
        End While
        If Me.InvokeRequired Then
            On Error GoTo Failed
            Me.Invoke(New MethodInvoker(AddressOf CloseMe))
            Exit Sub
        Else
            Me.Close()
            Exit Sub
        End If
Failed:
        'Me.Close()
    End Sub
    Public Sub DisableButtons()
        browseservers_btn.Enabled = False
        browseservers_btn.BackgroundImage = SC2KNEL.My.Resources.serverlist_disabled
        options_btn.Enabled = False
        options_btn.BackgroundImage = SC2KNEL.My.Resources.options_disabled
        hostserver_btn.Enabled = False
        hostserver_btn.BackgroundImage = SC2KNEL.My.Resources.hostserver_disabled
        findlbl.Enabled = False
        createlbl.Enabled = False
        privserver.Enabled = False
        pubserver.Enabled = False
    End Sub
    Public Sub EnableButtons()
        browseservers_btn.Enabled = True
        browseservers_btn.BackgroundImage = SC2KNEL.My.Resources.serverlist
        options_btn.Enabled = True
        options_btn.BackgroundImage = SC2KNEL.My.Resources.options
        hostserver_btn.Enabled = True
        hostserver_btn.BackgroundImage = SC2KNEL.My.Resources.hostserver
        findlbl.Enabled = True
        createlbl.Enabled = True
        privserver.Enabled = True
        pubserver.Enabled = True
    End Sub
    Public Sub SetInfoText(ByVal text As String)
        Me.BeginInvoke(Sub() Me.SplashScreenInfoLabel.Text = text)
        Me.BeginInvoke(Sub() Me.Refresh())
    End Sub
    Private Sub SplashScreen_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ExitGlobally = True
    End Sub
    Private Sub SplashScreen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        versionlabel.Text = "v" & FileVersionInfo.GetVersionInfo(Application.ExecutablePath).ProductVersion
        Dim ExitThread As New Threading.Thread(AddressOf CloseMe)
        ExitThread.Start()
    End Sub
    Private Sub exit_btn_Click(sender As System.Object, e As System.EventArgs) Handles exit_btn.Click
        ExitGlobally = True
    End Sub
    Private Sub exit_btn_Hover(sender As System.Object, e As System.EventArgs) Handles exit_btn.MouseHover
        exit_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.exit_hover
    End Sub
    Private Sub exit_btn_ExitHover(sender As System.Object, e As System.EventArgs) Handles exit_btn.MouseLeave
        exit_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources._exit
    End Sub
    Private Sub Hide_btn_Click(sender As System.Object, e As System.EventArgs) Handles Hide_btn.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Hide_btn_Hover(sender As System.Object, e As System.EventArgs) Handles Hide_btn.MouseHover
        Hide_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.minimize_hover
    End Sub
    Private Sub Hide_btn_ExitHover(sender As System.Object, e As System.EventArgs) Handles Hide_btn.MouseLeave
        Hide_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.minimize
    End Sub
    Private Sub options_btn_Click(sender As System.Object, e As System.EventArgs) Handles options_btn.Click
        'ShowForm(Settings)
    End Sub
    Private Sub options_btn_Hover(sender As System.Object, e As System.EventArgs) Handles options_btn.MouseHover
        options_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.options_hover
    End Sub
    Private Sub options_btn_ExitHover(sender As System.Object, e As System.EventArgs) Handles options_btn.MouseLeave
        options_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.options
    End Sub
    Private Sub browseservers_btn_Click(sender As System.Object, e As System.EventArgs) Handles browseservers_btn.Click
        HideForm(Me)
        ShowForm(ServerBrowser)
        ServerBrowser.Activate()
    End Sub
    Private Sub hostserver_btn_Click(sender As System.Object, e As System.EventArgs) Handles hostserver_btn.Click
        Title.Text = "SimCity 2000 NE Server"
        Me.BackgroundImage = My.Resources._2562
        Server.StartServer()
    End Sub
    Private Sub browseservers_btn_Hover(sender As System.Object, e As System.EventArgs) Handles browseservers_btn.MouseHover
        browseservers_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.serverlist_hover
    End Sub
    Private Sub browseservers_btn_ExitHover(sender As System.Object, e As System.EventArgs) Handles browseservers_btn.MouseLeave
        browseservers_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.serverlist
    End Sub
    Private Sub hostserver_btn_Hover(sender As System.Object, e As System.EventArgs) Handles hostserver_btn.MouseHover
        hostserver_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.hostserver_hover
    End Sub
    Private Sub hostserver_btn_ExitHover(sender As System.Object, e As System.EventArgs) Handles hostserver_btn.MouseLeave
        hostserver_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.hostserver
    End Sub
End Class
