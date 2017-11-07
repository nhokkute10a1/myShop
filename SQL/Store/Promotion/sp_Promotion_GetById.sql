Create proc sp_Promotion_GetById
@Promotion_ID int
as
begin
select *
from Promotion P
where P.Promotion_ID=@Promotion_ID
end

sp_Promotion_GetById 1