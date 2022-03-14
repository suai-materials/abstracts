@echo off
cls
echo start backup
echo[
echo enter folder
echo BACKUP - B DATA - D 
choice /C BD /M "your choice?"
if errorlevel 2 goto d
if errorlevel 1 goto b
:d
if not exist data mkdir data 
copy *.* data
goto end
:b 
if not exist backup mkdir backup
copy *.* backup
:end
echo stop backup