@echo off

if _%1 == _ goto noparam
dir %1 /A:-d /S /B > paths.txt
if errorlevel 1 goto end
echo All file paths are in paths.txt
goto end
:noparam
echo Specify the path as a parameter
:end