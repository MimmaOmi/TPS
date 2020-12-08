@echo off
For /f "tokens=1-4 delims=/ " %%a in ('date /t') do (set mydate=%%c_%%a_%%b)
For /f "tokens=1-2 delims=/:" %%a in ("%time%") do (set mytime=%%a%%b)
EXP c##PgditTPS20/Tps@Textile file = PGDITTPS20DB_%mydate%_%mytime%.bak