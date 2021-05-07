
  CREATE OR REPLACE PROCEDURE "HS"."GET_SEAT" 
(flight_id in number,seats out sys_refcursor)
as
begin
open seats for
select SEAT_NUM,COST
from seat 
where flightid= flight_id and AVAILABILITY='Y';
end;
/
 