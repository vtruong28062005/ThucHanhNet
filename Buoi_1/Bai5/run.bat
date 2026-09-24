@echo off
chcp 65001 > nul
echo Dang bien dich cac file C# cho Bai 5...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /out:QuanLyHoaDon.exe /codepage:65001 KhachHang.cs KhachHangVietNam.cs KhachHangNuocNgoai.cs Program.cs
if %ERRORLEVEL% EQU 0 (
    echo Bien dich thanh cong! Dang khoi chay QuanLyHoaDon.exe...
    echo.
    QuanLyHoaDon.exe
) else (
    echo Co loi xay ra khi bien dich!
    pause
)
