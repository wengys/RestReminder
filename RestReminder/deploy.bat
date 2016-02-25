SCHTASKS /CREATE /TN MYREMINDER /TR \""%CD%\RESTREMINDER\" \"00:00:30\"" /SC MINUTE /MO 30 /F
"C:\WINDOWS\system32\mmc.exe" "C:\WINDOWS\system32\taskschd.msc" /s