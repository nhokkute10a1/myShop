create proc sp_Advertisement_GetById 
@Advertisement_ID int
as
begin
select A.*
from Advertisement A
where A.Advertisement_ID=@Advertisement_ID
end