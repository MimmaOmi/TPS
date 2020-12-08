conn system/Manager123@Textile;

drop user c##PgditTPS20 cascade;

PROMPT Creating schema user 'c##PgditTPS20'
Create user c##PgditTPS20
identified by Tps
default tablespace users
temporary tablespace temp
quota unlimited on users;


PROMPT Grant DBA previleges to 'c##PgditTPS20'
grant connect, resource, dba to c##PgditTPS20;

PROMPT Try to connect as 'c##PgditTPS20'
connect c##PgditTPS20/Tps@Textile;

regsvr32 e:\oracle\product\12.1.0.2_32b\bin\ocijdbc12.dll





