@echo off

dir %1 /A:-d /S /B >> paths.txt

echo All file paths are in path.txt
