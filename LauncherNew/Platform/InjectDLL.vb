Imports System.Runtime.InteropServices
Imports System.Text
Module Inject
    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal bInheritHandle As Integer, ByVal dwProcessId As Integer) As Integer
    Private Declare Function VirtualAllocEx Lib "kernel32" (ByVal hProcess As Integer, ByVal lpAddress As Integer, ByVal dwSize As Integer, ByVal flAllocationType As Integer, ByVal flProtect As Integer) As Integer
    Private Declare Function WriteProcessMemory Lib "kernel32" (ByVal hProcess As Integer, ByVal lpBaseAddress As Integer, ByVal lpBuffer() As Byte, ByVal nSize As Integer, ByVal lpNumberOfBytesWritten As UInteger) As Boolean
    Private Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As Integer, ByVal lpProcName As String) As Integer
    Private Declare Function GetModuleHandle Lib "kernel32" Alias "GetModuleHandleA" (ByVal lpModuleName As String) As Integer
    Private Declare Function CreateRemoteThread Lib "kernel32" (ByVal hProcess As Integer, ByVal lpThreadAttributes As Integer, ByVal dwStackSize As Integer, ByVal lpStartAddress As Integer, ByVal lpParameter As Integer, ByVal dwCreationFlags As Integer, ByVal lpThreadId As Integer) As Integer
    Private Declare Function CreateEvent Lib "kernel32" Alias "CreateEventA" (ByVal lpEventAttributes As IntPtr, ByVal bManualReset As Boolean, ByVal bInitialState As Boolean, ByVal lpName As String) As IntPtr
    Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
    Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As Integer) As Integer
    Public Function InjectFile(ByVal DLLPath As String) As Boolean
        Dim ProcessName As Process() = Process.GetProcessesByName("Bond2")
        Dim ProcessID = ProcessName(0).Id
        DLLPath = IO.Directory.GetCurrentDirectory & "\" & DLLPath
        On Error GoTo exiterror
        Dim DProc As Integer
        Dim DAdd As Integer
        Dim DWrote As UInteger
        Dim DAll As Integer
        Dim DThe As Integer
        Dim DMHD As Integer
        DProc = OpenProcess(&H1F0FFF, 1, ProcessID)
        DAdd = VirtualAllocEx(DProc, 0, DLLPath.Length, &H1000, &H4)
        If (DAdd > 0) Then
            Dim DByte() As Byte
            DByte = StrChar(DLLPath)
            WriteProcessMemory(DProc, DAdd, DByte, DLLPath.Length, DWrote)
            DMHD = GetModuleHandle("kernel32.dll")
            DAll = GetProcAddress(DMHD, "LoadLibraryA")
            DThe = CreateRemoteThread(DProc, 0, 0, DAll, DAdd, 0, 0)
            If (DThe > 0) Then
                WaitForSingleObject(DThe, &HFFFF)
                CloseHandle(DThe)
                CreateEvent(0, False, False, "RInputEvent32")
                Return True
            Else
                GoTo exiterror
            End If
        Else
            GoTo exiterror
        End If
        InjectFile = True
        Exit Function
exiterror:
        InjectFile = False
    End Function
    Private Function StrChar(ByRef strString As String) As Byte()
        Dim bytTemp() As Byte
        Dim i As Short
        ReDim bytTemp(0)
        For i = 1 To Len(strString)
            If bytTemp(UBound(bytTemp)) <> 0 Then ReDim Preserve bytTemp(UBound(bytTemp) + 1)
            bytTemp(UBound(bytTemp)) = Asc(Mid(strString, i, 1))
        Next i
        ReDim Preserve bytTemp(UBound(bytTemp) + 1)
        bytTemp(UBound(bytTemp)) = 0
        StrChar = bytTemp
    End Function
End Module