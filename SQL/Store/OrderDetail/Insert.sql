CREATE PROCEDURE sp_OrderDetail_Insert
--@OrderDetail_ID int,
@OrderMaster_ID int,
@Product_ID int,
@Quanlity int,
@Amout float,
@OrderDetail_Date datetime,
@OrderDetail_Status int= NULL,
@Lock int= NULL,
@Is_Active bit NULL
As
BEGIN
	INSERT INTO OrderDetail(
	 OrderMaster_ID,
      Product_ID,
      Quanlity,
      Amout,
      OrderDetail_Date,
      OrderDetail_Status,
      Lock,
      Is_Active
	)
	VALUES(
	@OrderMaster_ID,
	@Product_ID,
	@Quanlity,
	@Amout,
	@OrderDetail_Date,
	@OrderDetail_Status,
	@Lock,
	@Is_Active
	)
END