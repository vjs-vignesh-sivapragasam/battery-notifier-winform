[Setup]
AppName=Battery Notifier
AppVersion=1.0
DefaultDirName={pf}\Battery Notifier
DefaultGroupName=Battery Notifier
OutputDir=D:\V-Docs\Project\WinFormsApp1\Output;
OutputBaseFilename=BatteryNotifierSetup

[Files]
; Ensure the paths to your files are correct
Source: "D:\V-Docs\Project\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"; DestDir: "{app}"; Flags: ignoreversion

; If you have additional files like sound files, add them similarly
; Example:
; Source: "D:\V-Docs\Project\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\SoundFile.wav"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Battery Notifier"; Filename: "D:\V-Docs\Project\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"
Name: "{userdesktop}\Battery Notifier"; Filename: "D:\V-Docs\Project\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; ValueName: "BatteryNotifier"; ValueType: string; ValueData: "D:\V-Docs\Project\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"

[Run]
Filename: "D:\V-Docs\Project\WinFormsApp1\WinFormsApp1\bin\Debug\net8.0-windows\WinFormsApp1.exe"; Description: "Launch Battery Notifier"; Flags: nowait postinstall skipifsilent