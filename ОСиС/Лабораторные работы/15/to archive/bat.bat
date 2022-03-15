@echo OFF
FOR %%x IN (0 1 3 5 7 9) DO 7z a -tzip 1_%%x.zip *.pdf -mx=%%x
FOR %%x IN (0 1 3 5 7 9) DO 7z a -tzip 2_%%x.zip *.xls -mx=%%x