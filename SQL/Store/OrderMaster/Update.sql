Create Procedure sp_OrderMaster_Update
@OrderMaster_ID int,
@UserProfile_ID int ,
@Payment_ID int =NULL,
@Provice_ID int =NULL,
@OrderMaster_Code varchar(50) ,
@PriceShip float=NULL,
@VAT float=NULL,
@Total float=NULL,
@Note nvarchar(max)=NULL,
@OrderMaster_Date datetime ,
@OrderMaster_Status int=NULL,
@Lock int=NULL,
@Is_Active bit =NULL
As
Begin
	Update OM
	Set OM.UserProfile_ID=@UserProfile_ID ,
      OM.Payment_ID=@Payment_ID,
      OM.Provice_ID=@Provice_ID,
      OM.OrderMaster_Code=@OrderMaster_Code,
      OM.PriceShip=@PriceShip,
      OM.VAT=@VAT,
      OM.Total=@Total,
      OM.Note=@Note,
      OM.OrderMaster_Date=@OrderMaster_Date,
      OM.OrderMaster_Status=@OrderMaster_Status,
      OM.Lock=@Lock,
      OM.Is_Active=@Is_Active
	From OrderMaster OM
	Where OM.OrderMaster_ID=@OrderMaster_ID
End