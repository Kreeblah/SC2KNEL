Public Module Globals
    Public ExitGlobally As Boolean = False
    Public NightfireProcess As Process
    Public ConnectArg As String = " " 'force the connect
    Public ExtraCommandLineArgs As String = " " 'Extra arguments
    Public RawMouseInput As Boolean = True 'Enable Raw Mouse Input?
    Public NoUpdate As Boolean = False 'No update argument
    Public NoJoy As Boolean = False 'Don't enable joystick/xinput controller support
    Public AlwaysUpdate As Boolean = False 'No Update Message Box (always update game)
    Public CPath As String = ""
    Public CurrentDir As String = ""
    Public DontLaunchNF As Boolean = False 'Don't Launch Nightfire
    Public Hunk As Integer = 0
    Public Heap As Integer = 0
    Public Const NULL = Nothing
    Public restart As Boolean = False
    Public BondEXE As String = "Bond2.exe"
    Public Const BOND2HASH As String = "1CB48E314143772B4D83D0ADFCBBB095" '"EC2560FEE1F3F966314DF17B8B7E1A97"
End Module
