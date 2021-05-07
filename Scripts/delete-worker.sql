
  CREATE OR REPLACE PROCEDURE "HS"."DELETE_WORKER_ACCOUNT" 
(ss NUMBER)
as
begin
delete from worker where SSN=ss;
delete from account where SSN=ss;
end;
/
 