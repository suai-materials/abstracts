@echo off
cls 
echo start backup
if exist backup\1.bat (del backup\1.bat)
copy *.* backup
echo backup ended