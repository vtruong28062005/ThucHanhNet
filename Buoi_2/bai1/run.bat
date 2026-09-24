@echo off
chcp 65001 > nul
REM Dong tien trinh cu neu dang chay de tranh loi file bi khoa (CS0016)
taskkill /F /IM QuanLyKhachSan.exe >nul 2>&1

echo ========================================================
echo   DANG BIEN DICH CHUONG TRINH C# QUAN LY KHACH SAN...
echo   (CONG VIEC 2 & 3: FORM QUAN LY PHONG + FORM KHACH THUE)
echo ========================================================
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe /nologo /target:winexe /r:System.dll,System.Data.dll,System.Drawing.dll,System.Windows.Forms.dll,System.Xml.dll /out:QuanLyKhachSan.exe Program.cs FormPhong.cs FormKhachThue.cs
if %ERRORLEVEL% EQU 0 (
    echo.
    echo [OK] Bien dich thanh cong! Dang khoi chay QuanLyKhachSan.exe...
    echo ========================================================
    echo.
    start QuanLyKhachSan.exe
) else (
    echo.
    echo [X] Co loi xay ra khi bien dich! Vui long kiem tra lai.
    pause
)
