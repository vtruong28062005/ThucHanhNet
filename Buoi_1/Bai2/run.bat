@echo off
chcp 65001 > nul
set CSC=
if exist "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe" set CSC="C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if "%CSC%"=="" if exist "C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe" set CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"

if not "%CSC%"=="" (
    echo Dang bien dich cac file C# cho Bai 2...
    %CSC% /nologo /out:BaiTapSinhVien.exe /codepage:65001 SinhVien.cs Program.cs
    if errorlevel 1 (
        echo Co loi xay ra khi bien dich!
        pause
        exit /b
    )
    echo Bien dich thanh cong! Dang khoi chay BaiTapSinhVien.exe...
    echo.
    BaiTapSinhVien.exe
) else (
    if exist BaiTapSinhVien.exe (
        BaiTapSinhVien.exe
    ) else (
        echo Khong tim thay trinh bien dich csc.exe va chua co file BaiTapSinhVien.exe!
        pause
    )
)
