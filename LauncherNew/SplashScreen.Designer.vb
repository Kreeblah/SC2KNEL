<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.nightfirepclink = New System.Windows.Forms.LinkLabel()
        Me.SplashScreenInfoLabel = New System.Windows.Forms.Label()
        Me.exit_btn = New System.Windows.Forms.Button()
        Me.Hide_btn = New System.Windows.Forms.Button()
        Me.nfsourcelink = New System.Windows.Forms.LinkLabel()
        Me.options_btn = New System.Windows.Forms.Button()
        Me.browseservers_btn = New System.Windows.Forms.Button()
        Me.hostserver_btn = New System.Windows.Forms.Button()
        Me.Title = New System.Windows.Forms.Label()
        Me.createlbl = New System.Windows.Forms.Label()
        Me.findlbl = New System.Windows.Forms.Label()
        Me.SCLogo = New System.Windows.Forms.PictureBox()
        Me.pubserver = New System.Windows.Forms.RadioButton()
        Me.privserver = New System.Windows.Forms.RadioButton()
        Me.versionlabel = New System.Windows.Forms.Label()
        CType(Me.SCLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nightfirepclink
        '
        Me.nightfirepclink.ActiveLinkColor = System.Drawing.Color.Transparent
        Me.nightfirepclink.AutoSize = True
        Me.nightfirepclink.BackColor = System.Drawing.Color.Transparent
        Me.nightfirepclink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.nightfirepclink.DisabledLinkColor = System.Drawing.Color.Transparent
        Me.nightfirepclink.ForeColor = System.Drawing.Color.Transparent
        Me.nightfirepclink.LinkColor = System.Drawing.Color.Transparent
        Me.nightfirepclink.Location = New System.Drawing.Point(12, 0)
        Me.nightfirepclink.Name = "nightfirepclink"
        Me.nightfirepclink.Size = New System.Drawing.Size(153, 17)
        Me.nightfirepclink.TabIndex = 7
        Me.nightfirepclink.TabStop = True
        Me.nightfirepclink.Text = "nightfirepc.com                        "
        Me.nightfirepclink.UseCompatibleTextRendering = True
        Me.nightfirepclink.VisitedLinkColor = System.Drawing.Color.Transparent
        '
        'SplashScreenInfoLabel
        '
        Me.SplashScreenInfoLabel.AutoEllipsis = True
        Me.SplashScreenInfoLabel.BackColor = System.Drawing.Color.Transparent
        Me.SplashScreenInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplashScreenInfoLabel.ForeColor = System.Drawing.Color.White
        Me.SplashScreenInfoLabel.Location = New System.Drawing.Point(8, 202)
        Me.SplashScreenInfoLabel.Name = "SplashScreenInfoLabel"
        Me.SplashScreenInfoLabel.Size = New System.Drawing.Size(460, 29)
        Me.SplashScreenInfoLabel.TabIndex = 13
        Me.SplashScreenInfoLabel.Text = "Initializing Launcher"
        Me.SplashScreenInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'exit_btn
        '
        Me.exit_btn.BackColor = System.Drawing.Color.Transparent
        Me.exit_btn.BackgroundImage = CType(resources.GetObject("exit_btn.BackgroundImage"), System.Drawing.Image)
        Me.exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.exit_btn.FlatAppearance.BorderSize = 0
        Me.exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exit_btn.ForeColor = System.Drawing.Color.Black
        Me.exit_btn.Location = New System.Drawing.Point(417, 0)
        Me.exit_btn.Name = "exit_btn"
        Me.exit_btn.Size = New System.Drawing.Size(64, 24)
        Me.exit_btn.TabIndex = 12
        Me.exit_btn.UseVisualStyleBackColor = False
        '
        'Hide_btn
        '
        Me.Hide_btn.BackColor = System.Drawing.Color.Transparent
        Me.Hide_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.minimize
        Me.Hide_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Hide_btn.FlatAppearance.BorderSize = 0
        Me.Hide_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Hide_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Hide_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Hide_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hide_btn.ForeColor = System.Drawing.Color.Black
        Me.Hide_btn.Location = New System.Drawing.Point(417, 24)
        Me.Hide_btn.Name = "Hide_btn"
        Me.Hide_btn.Size = New System.Drawing.Size(64, 24)
        Me.Hide_btn.TabIndex = 11
        Me.Hide_btn.UseVisualStyleBackColor = False
        '
        'nfsourcelink
        '
        Me.nfsourcelink.ActiveLinkColor = System.Drawing.Color.Transparent
        Me.nfsourcelink.AutoSize = True
        Me.nfsourcelink.BackColor = System.Drawing.Color.Transparent
        Me.nfsourcelink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.nfsourcelink.DisabledLinkColor = System.Drawing.Color.Transparent
        Me.nfsourcelink.ForeColor = System.Drawing.Color.Transparent
        Me.nfsourcelink.LinkColor = System.Drawing.Color.Transparent
        Me.nfsourcelink.Location = New System.Drawing.Point(387, 48)
        Me.nfsourcelink.Name = "nfsourcelink"
        Me.nfsourcelink.Size = New System.Drawing.Size(151, 17)
        Me.nfsourcelink.TabIndex = 8
        Me.nfsourcelink.TabStop = True
        Me.nfsourcelink.Text = "nightfiresource.com                "
        Me.nfsourcelink.UseCompatibleTextRendering = True
        Me.nfsourcelink.VisitedLinkColor = System.Drawing.Color.Transparent
        '
        'options_btn
        '
        Me.options_btn.BackColor = System.Drawing.Color.Transparent
        Me.options_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.options
        Me.options_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.options_btn.Enabled = False
        Me.options_btn.FlatAppearance.BorderSize = 0
        Me.options_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.options_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.options_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.options_btn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.options_btn.ForeColor = System.Drawing.Color.Black
        Me.options_btn.Location = New System.Drawing.Point(417, 48)
        Me.options_btn.Name = "options_btn"
        Me.options_btn.Size = New System.Drawing.Size(64, 24)
        Me.options_btn.TabIndex = 10
        Me.options_btn.UseVisualStyleBackColor = False
        Me.options_btn.Visible = False
        '
        'browseservers_btn
        '
        Me.browseservers_btn.BackColor = System.Drawing.Color.Transparent
        Me.browseservers_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.serverlist
        Me.browseservers_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.browseservers_btn.FlatAppearance.BorderSize = 0
        Me.browseservers_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.browseservers_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.browseservers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.browseservers_btn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browseservers_btn.ForeColor = System.Drawing.Color.Black
        Me.browseservers_btn.Location = New System.Drawing.Point(365, 98)
        Me.browseservers_btn.Name = "browseservers_btn"
        Me.browseservers_btn.Size = New System.Drawing.Size(95, 38)
        Me.browseservers_btn.TabIndex = 9
        Me.browseservers_btn.UseVisualStyleBackColor = False
        '
        'hostserver_btn
        '
        Me.hostserver_btn.BackColor = System.Drawing.Color.Transparent
        Me.hostserver_btn.BackgroundImage = Global.SC2KNEL.My.Resources.Resources.hostserver
        Me.hostserver_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.hostserver_btn.FlatAppearance.BorderSize = 0
        Me.hostserver_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.hostserver_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.hostserver_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.hostserver_btn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hostserver_btn.ForeColor = System.Drawing.Color.Black
        Me.hostserver_btn.Location = New System.Drawing.Point(25, 98)
        Me.hostserver_btn.Name = "hostserver_btn"
        Me.hostserver_btn.Size = New System.Drawing.Size(95, 38)
        Me.hostserver_btn.TabIndex = 14
        Me.hostserver_btn.UseVisualStyleBackColor = False
        '
        'Title
        '
        Me.Title.AutoEllipsis = True
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.Font = New System.Drawing.Font("Lucida Sans Unicode", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.White
        Me.Title.Location = New System.Drawing.Point(8, 9)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(334, 29)
        Me.Title.TabIndex = 15
        Me.Title.Text = "SimCity 2000 Network Edition"
        Me.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'createlbl
        '
        Me.createlbl.AutoSize = True
        Me.createlbl.BackColor = System.Drawing.Color.Transparent
        Me.createlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createlbl.ForeColor = System.Drawing.Color.White
        Me.createlbl.Location = New System.Drawing.Point(12, 139)
        Me.createlbl.Name = "createlbl"
        Me.createlbl.Size = New System.Drawing.Size(120, 20)
        Me.createlbl.TabIndex = 16
        Me.createlbl.Text = "Create Server"
        '
        'findlbl
        '
        Me.findlbl.AutoSize = True
        Me.findlbl.BackColor = System.Drawing.Color.Transparent
        Me.findlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.findlbl.ForeColor = System.Drawing.Color.White
        Me.findlbl.Location = New System.Drawing.Point(358, 139)
        Me.findlbl.Name = "findlbl"
        Me.findlbl.Size = New System.Drawing.Size(110, 20)
        Me.findlbl.TabIndex = 17
        Me.findlbl.Text = "Find Servers"
        '
        'SCLogo
        '
        Me.SCLogo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SCLogo.BackColor = System.Drawing.Color.Transparent
        Me.SCLogo.BackgroundImage = CType(resources.GetObject("SCLogo.BackgroundImage"), System.Drawing.Image)
        Me.SCLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SCLogo.Location = New System.Drawing.Point(138, 48)
        Me.SCLogo.Name = "SCLogo"
        Me.SCLogo.Size = New System.Drawing.Size(214, 151)
        Me.SCLogo.TabIndex = 18
        Me.SCLogo.TabStop = False
        '
        'pubserver
        '
        Me.pubserver.AutoSize = True
        Me.pubserver.BackColor = System.Drawing.Color.Transparent
        Me.pubserver.Checked = True
        Me.pubserver.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pubserver.ForeColor = System.Drawing.Color.White
        Me.pubserver.Location = New System.Drawing.Point(12, 162)
        Me.pubserver.Name = "pubserver"
        Me.pubserver.Size = New System.Drawing.Size(57, 19)
        Me.pubserver.TabIndex = 19
        Me.pubserver.TabStop = True
        Me.pubserver.Text = "Public"
        Me.pubserver.UseVisualStyleBackColor = False
        '
        'privserver
        '
        Me.privserver.AutoSize = True
        Me.privserver.BackColor = System.Drawing.Color.Transparent
        Me.privserver.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.privserver.ForeColor = System.Drawing.Color.White
        Me.privserver.Location = New System.Drawing.Point(71, 162)
        Me.privserver.Name = "privserver"
        Me.privserver.Size = New System.Drawing.Size(61, 19)
        Me.privserver.TabIndex = 20
        Me.privserver.Text = "Private"
        Me.privserver.UseVisualStyleBackColor = False
        '
        'versionlabel
        '
        Me.versionlabel.AutoSize = True
        Me.versionlabel.BackColor = System.Drawing.Color.Transparent
        Me.versionlabel.ForeColor = System.Drawing.Color.White
        Me.versionlabel.Location = New System.Drawing.Point(384, 6)
        Me.versionlabel.Name = "versionlabel"
        Me.versionlabel.Size = New System.Drawing.Size(42, 13)
        Me.versionlabel.TabIndex = 21
        Me.versionlabel.Text = "Version"
        '
        'SplashScreen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.SC2KNEL.My.Resources.Resources._256
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(480, 240)
        Me.Controls.Add(Me.versionlabel)
        Me.Controls.Add(Me.privserver)
        Me.Controls.Add(Me.pubserver)
        Me.Controls.Add(Me.SCLogo)
        Me.Controls.Add(Me.findlbl)
        Me.Controls.Add(Me.createlbl)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.hostserver_btn)
        Me.Controls.Add(Me.Hide_btn)
        Me.Controls.Add(Me.exit_btn)
        Me.Controls.Add(Me.browseservers_btn)
        Me.Controls.Add(Me.SplashScreenInfoLabel)
        Me.Controls.Add(Me.options_btn)
        Me.Controls.Add(Me.nfsourcelink)
        Me.Controls.Add(Me.nightfirepclink)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Nightfire Launcher"
        CType(Me.SCLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nightfirepclink As System.Windows.Forms.LinkLabel
    Friend WithEvents SplashScreenInfoLabel As System.Windows.Forms.Label
    Friend WithEvents exit_btn As System.Windows.Forms.Button
    Friend WithEvents Hide_btn As System.Windows.Forms.Button
    Friend WithEvents nfsourcelink As System.Windows.Forms.LinkLabel
    Friend WithEvents options_btn As System.Windows.Forms.Button
    Friend WithEvents browseservers_btn As System.Windows.Forms.Button
    Friend WithEvents hostserver_btn As System.Windows.Forms.Button
    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents createlbl As System.Windows.Forms.Label
    Friend WithEvents findlbl As System.Windows.Forms.Label
    Friend WithEvents SCLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pubserver As System.Windows.Forms.RadioButton
    Friend WithEvents privserver As System.Windows.Forms.RadioButton
    Friend WithEvents versionlabel As System.Windows.Forms.Label

End Class
