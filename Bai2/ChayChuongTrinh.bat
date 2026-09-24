@echo off
chcp 65001 >nul
title QUAN LY SINH VIEN - C# OOP (BAI 2)
color 0b
echo ============================================================
echo      CHUONG TRINH QUAN LY SINH VIEN (BAI TAP 2 - C#)
echo ============================================================
echo Dang kiem tra va bien dich ma nguon C#...
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /out:"%~dp0BaiTapSinhVien.exe" /codepage:65001 "%~dp0SinhVien.cs" "%~dp0Program.cs"
if %ERRORLEVEL% EQU 0 (
    echo Bien dich thanh cong!
    echo ============================================================
    echo.
    "%~dp0BaiTapSinhVien.exe"
) else (
    echo Co loi xay ra trong qua trinh bien dich!
)
pause
