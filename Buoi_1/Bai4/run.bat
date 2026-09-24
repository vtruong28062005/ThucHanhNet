@echo off
chcp 65001 > nul
echo Dang bien dich cac file C# cho Bai 4...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /out:Bai4.exe Vemaybay.cs Nguoi.cs Hanhkhach.cs Program.cs
if %ERRORLEVEL% EQU 0 (
    echo Bien dich thanh cong! Dang khoi chay Bai4.exe...
    echo.
    Bai4.exe
) else (
    echo Co loi xay ra khi bien dich!
    pause
)
