@echo off
chcp 65001 > nul
echo Dang bien dich Program.cs...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /out:Bai3.exe Program.cs
if %ERRORLEVEL% EQU 0 (
    echo Bien dich thanh cong! Dang chay chuong trinh...
    echo.
    Bai3.exe
) else (
    echo Co loi xay ra khi bien dich!
    pause
)
