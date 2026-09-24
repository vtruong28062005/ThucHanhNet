@echo off
chcp 65001 >nul
title QUAN LY SINH VIEN - C# OOP (BAI 2)
color 0b
echo ============================================================
echo      CHUONG TRINH QUAN LY SINH VIEN (BAI TAP 2 - C#)
echo ============================================================

set CSC=
if exist "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" set CSC="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if "%CSC%"=="" if exist "C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe" set CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"

if not "%CSC%"=="" (
    echo Dang kiem tra va bien dich ma nguon C#...
    %CSC% /nologo /out:"%~dp0BaiTapSinhVien.exe" /codepage:65001 "%~dp0SinhVien.cs" "%~dp0Program.cs"
    if errorlevel 1 (
        echo Co loi xay ra trong qua trinh bien dich!
        pause
        exit /b
    )
    echo Bien dich thanh cong!
    echo ============================================================
    echo.
    "%~dp0BaiTapSinhVien.exe"
) else (
    if exist "%~dp0BaiTapSinhVien.exe" (
        echo Dang khoi chay truc tiep BaiTapSinhVien.exe...
        echo ============================================================
        echo.
        "%~dp0BaiTapSinhVien.exe"
    ) else (
        echo Khong tim thay trinh bien dich csc.exe va chua co file BaiTapSinhVien.exe!
        pause
    )
)
