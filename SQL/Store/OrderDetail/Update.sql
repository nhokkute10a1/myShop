CREATE PROCEDURE sp_OrderDetail_Update
@OrderDetail_ID int,
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
	UPDATE OD
	SET OD.OrderMaster_ID=@OrderMaster_ID,
      OD.Product_ID=@Product_ID,
     OD. Quanlity=@Quanlity,
     OD.Amout=@Amout,
      OD.OrderDetail_Date=@OrderDetail_Date,
     OD. OrderDetail_Status=@OrderDetail_Status,
      OD.Lock=@Lock,
     OD. Is_Active=@Is_Active
	FROM OrderDetail OD
	WHERE OD.OrderDetail_ID=@OrderDetail_ID
END