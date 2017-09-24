Create Procedure sp_Advertisement_Delete
@Advertisement_ID int
AS
BEGIN
	DELETE A
	FROM Advertisement A
	WHERE A.Advertisement_ID=@Advertisement_ID
END