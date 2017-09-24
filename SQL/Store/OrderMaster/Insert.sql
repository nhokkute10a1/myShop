Create Procedure sp_OrderMaster_Insert
--@OrderMaster_ID int,
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
	Insert Into OrderMaster(
	 UserProfile_ID,
      Payment_ID,
      Provice_ID,
      OrderMaster_Code,
      PriceShip,
      VAT,
      Total,
      Note,
      OrderMaster_Date,
      OrderMaster_Status,
      Lock,
      Is_Active
	)
	Values(
	@UserProfile_ID ,
	@Payment_ID,
	@Provice_ID,
	@OrderMaster_Code,
	@PriceShip,
	@VAT,
	@Total,
	@Note,
	@OrderMaster_Date,
	@OrderMaster_Status,
	@Lock,
	@Is_Active
	)
End