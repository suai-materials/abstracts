@echo off

cls
rem if _%1 == _ goto noparam, тоже будет работать
if "%~1" == "" goto noparam
if not exist %userprofile%\%1 mkdir %userprofile%\%1
if exist D:\ copy D:\* %userprofile%\%1 
goto end
:noparam
echo Batch file needed argument
:end
