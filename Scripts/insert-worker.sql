
  CREATE OR REPLACE PROCEDURE "HS"."INSERT_WORKER_ACCOUNT" 
(ss NUMBER,name1 VARCHAR2,name2 VARCHAR2,birthdate date,nationality1 VARCHAR2,pass VARCHAR2,phone_number VARCHAR2,gender1 VARCHAR2,type1 VARCHAR2,salary1 number,s date,airplane1 NUMBER)
as
begin
insert into account
values(ss,name1,name2,birthdate, nationality1,pass, phone_number, gender1);

insert into worker
values(ss, type1, salary1, s, airplane1);

end;
/
 