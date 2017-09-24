CREATE PROCEDURE sp_OrderDetail_Delete
@OrderDetail_ID int
AS
BEGIN
	DELETE OD
	FROM OrderDetail OD
	WHERE OD.OrderDetail_ID=@OrderDetail_ID
END