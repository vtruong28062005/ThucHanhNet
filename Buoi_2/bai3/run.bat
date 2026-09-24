@echo off
chcp 65001 > nul
REM Dong tien trinh cu neu dang chay de tranh loi khoa file (CS0016)
taskkill /F /IM QuanLyKinhDoanh.exe >nul 2>&1

echo ========================================================
echo   DANG BIEN DICH CHUONG TRINH C# QUAN LY KINH DOANH (LAB 9 - BAI 3)...
echo   (CONG VIEC 1, 2, 3a, 3b, 3c, 4)
echo ========================================================

set CSC="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if not exist %CSC% (
    set CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"
)

%CSC% /nologo /target:winexe /r:System.dll,System.Data.dll,System.Drawing.dll,System.Windows.Forms.dll,System.Xml.dll /out:QuanLyKinhDoanh.exe DatabaseHelper.cs Program.cs frmMain.cs frmMuaHang.cs frmThongKeMua.cs frmThongKeBan.cs frmTimKiemBanHang.cs frmBanHang.cs frmDanhMuc.cs

if %ERRORLEVEL% EQU 0 (
    echo.
    echo [OK] Bien dich thanh cong! Dang khoi chay QuanLyKinhDoanh.exe...
    echo ========================================================
    echo.
    start QuanLyKinhDoanh.exe
) else (
    echo.
    echo [X] Co loi xay ra khi bien dich! Vui long kiem tra lai.
    pause
)
