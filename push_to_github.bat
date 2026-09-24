@echo off
chcp 65001 > nul
set "PATH=C:\Users\Truong\AppData\Local\Programs\Git\cmd;C:\Users\Truong\AppData\Local\Programs\Git\mingw64\bin;%PATH%"
cd /d "D:\ThucHanhNet"

echo ========================================================
echo   PUSH CODE LEN GITHUB: vtruong28062005/ThucHanhNet
echo ========================================================
echo.
echo Dang thuc hien: git push -u origin main ...
echo (Neu co hop thoai GitHub dang nhap, ban hay chon 'Sign in with your browser')
echo.
git push -u origin main
echo.
if %ERRORLEVEL% EQU 0 (
    echo ========================================================
    echo   [THANH CONG] Da push code len GitHub thanh cong!
    echo ========================================================
) else (
    echo ========================================================
    echo   [CHUA HOAN TAT] Vui long kiem tra lai hoac thu lai.
    echo ========================================================
)
echo.
pause