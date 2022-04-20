@echo OFF
FOR %%x IN (0 1 2 3 4 5) DO rar a  1_%%x.rar *.pdf -m%%x
FOR %%x IN (0 1 2 3 4 5) DO rar a  2_%%x.rar *.xls -m%%x