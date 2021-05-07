
  CREATE OR REPLACE PROCEDURE "HS"."GET_CUSTOMER_INFO" 
(Needed_ssn in NUMBER ,cred_number out NUMBER,passport_number out varchar2,
Of_name out VARCHAR2,Ol_name out varchar2,
OBdate out date,Onationality out VARCHAR2,Opass out varchar2,
Ophone out varchar2,Ogender out varchar2
)
as
begin
select credit_card_num,  passport_num
into cred_number,passport_number
from customer 
where ssn=Needed_ssn;
 select  f_name, l_name, b_date, nationality, password, phone, gender
   into Of_name,Ol_name,OBdate,Onationality,Opass,Ophone,Ogender
   from account
   where account.SSN= Needed_SSN;

end;
/
 