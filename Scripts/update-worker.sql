
  CREATE OR REPLACE PROCEDURE "HS"."UPDATE_WORKER_ACCOUNT" 
(ss NUMBER,name1 VARCHAR2,name2 VARCHAR2,birthdate date,nationality1 VARCHAR2,pass VARCHAR2,phone_number VARCHAR2,gender1 VARCHAR2,type1 VARCHAR2,salary1 number,s date,airplane1 NUMBER)
as
begin
update account set
F_NAME=name1,L_NAME=name2,B_DATE=birthdate,NATIONALITY= nationality1,PASSWORD=pass,PHONE= phone_number,GENDER= gender1 where SSN=ss;
update worker set
TYPE=type1 , SALARY=salary1 ,"S-DATE" = s, AIRPLAINID = airplane1 where SSN=ss;
end;
/
 