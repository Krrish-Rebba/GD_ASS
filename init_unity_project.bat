@echo off
setlocal
echo ========================================================
echo   Unity Project Initializer (ETCS406 Game Development)
echo ========================================================

set UNITY_EXE=C:\Program Files\Unity\Hub\Editor\6000.5.4f1\Editor\Unity.exe

if not exist "%UNITY_EXE%" (
    echo [ERROR] Unity Editor not found at: %UNITY_EXE%
    echo Please verify your Unity installation in Unity Hub.
    pause
    exit /b 1
)

if "%~1"=="" (
    echo Usage: init_unity_project.bat ^<SubfolderName^>
    echo Example: init_unity_project.bat Assignment_03_2D_Platformer
    echo.
    echo Available assignments:
    echo   1. Assignment_03_2D_Platformer
    echo   2. Assignment_04_Physics_Simulation
    echo   3. Assignment_05_NavMesh_AI
    echo   4. Assignment_06_Interactive_Story
    echo   5. Assignment_07_AR_VR_XR
    echo   6. Assignment_08_User_Testing
    echo   7. Assignment_09_Final_Mini_Project
    echo.
    set /p TARGET_FOLDER="Enter subfolder name: "
) else (
    set TARGET_FOLDER=%~1
)

set PROJECT_PATH=%~dp0%TARGET_FOLDER%\UnityProject

echo [INFO] Creating/Opening Unity Project at: %PROJECT_PATH%
echo [INFO] This might take 1-3 minutes to initialize for the first time...
"%UNITY_EXE%" -createProject "%PROJECT_PATH%" -quit

if %ERRORLEVEL% EQU 0 (
    echo [SUCCESS] Unity project initialized successfully at: %PROJECT_PATH%
) else (
    echo [NOTE] Unity exited with code %ERRORLEVEL%. Check Unity Editor logs.
)

pause
