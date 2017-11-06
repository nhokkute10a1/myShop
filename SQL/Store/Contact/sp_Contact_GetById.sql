Create Procedure sp_Contact_GetById
@Contact_ID int
as
begin
select C.*
from Contact C
where C.Contact_ID=@Contact_ID
end 

sp_Contact_GetById 3