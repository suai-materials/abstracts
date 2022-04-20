@echo off

:start
if _%1 == _ goto end
echo %1 Batch file
type backup\%1.bat
echo:
pause
shift
goto start
:end
