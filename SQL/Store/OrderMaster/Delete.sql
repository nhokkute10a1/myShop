Create Procedure sp_OrderMaster_Delete
@OrderMaster_ID int
As
Begin
	Delete OM
	From OrderMaster OM
	Where OM.OrderMaster_ID=@OrderMaster_ID
End