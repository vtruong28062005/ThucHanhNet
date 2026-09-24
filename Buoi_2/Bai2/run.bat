@echo off
chcp 65001 > nul
REM Dong tien trinh cu neu dang chay de tranh loi khoa file (CS0016)
taskkill /F /IM QuanLyDiem.exe >nul 2>&1

echo ========================================================
echo   DANG BIEN DICH CHUONG TRINH C# QUAN LY DIEM (LAB 9 - BAI 2)...
echo   (CONG VIEC 1, 2, 3, 4: frmMain, frmMonHoc, frmDiem)
echo ========================================================

set CSC="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if not exist %CSC% (
    set CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
)

%CSC% /nologo /target:winexe /r:System.dll,System.Data.dll,System.Drawing.dll,System.Windows.Forms.dll,System.Xml.dll /out:QuanLyDiem.exe DatabaseHelper.cs Program.cs frmMain.cs frmMonHoc.cs frmDiem.cs

if %ERRORLEVEL% EQU 0 (
    echo.
    echo [OK] Bien dich thanh cong! Dang khoi chay QuanLyDiem.exe...
    echo ========================================================
    echo.
    start QuanLyDiem.exe
) else (
    echo.
    echo [X] Co loi xay ra khi bien dich! Vui long kiem tra lai.
    pause
)
