@echo off
chcp 65001 >nul
title QUAN LY HOA DON TIEN DIEN - C# OOP (BAI 5)
color 0b
echo ============================================================
echo      CHUONG TRINH QUAN LY HOA DON TIEN DIEN (BAI 5 - C#)
echo ============================================================
echo Dang kiem tra va bien dich ma nguon C#...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /out:"%~dp0QuanLyHoaDon.exe" /codepage:65001 "%~dp0KhachHang.cs" "%~dp0KhachHangVietNam.cs" "%~dp0KhachHangNuocNgoai.cs" "%~dp0Program.cs"
if %ERRORLEVEL% EQU 0 (
    echo Bien dich thanh cong!
    echo ============================================================
    echo.
    "%~dp0QuanLyHoaDon.exe"
) else (
    echo Co loi xay ra trong qua trinh bien dich!
)
pause
