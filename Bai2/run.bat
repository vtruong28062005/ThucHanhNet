@echo off
chcp 65001 > nul
echo Dang bien dich cac file C# cho Bai 2...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /out:BaiTapSinhVien.exe /codepage:65001 SinhVien.cs Program.cs
if %ERRORLEVEL% EQU 0 (
    echo Bien dich thanh cong! Dang khoi chay BaiTapSinhVien.exe...
    echo.
    BaiTapSinhVien.exe
) else (
    echo Co loi xay ra khi bien dich!
    pause
)
