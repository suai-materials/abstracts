@echo OFF
FOR %%x IN (0 1 3 5 7 9) DO 7z a -tzip %%x.zip *.pdf -mx=%%x