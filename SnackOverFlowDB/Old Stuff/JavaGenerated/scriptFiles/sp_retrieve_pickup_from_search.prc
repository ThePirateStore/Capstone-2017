USE [SnackOverflowDB]
GO
IF EXISTS(SELECT * FROM sys.objects WHERE type = 'P' AND  name = 'sp_retrieve_pickup_from_search')
BEGIN
Drop PROCEDURE sp_retrieve_pickup_from_search
Print '' print  ' *** dropping procedure sp_retrieve_pickup_from_search'
End
GO

Print '' print  ' *** creating procedure sp_retrieve_pickup_from_search'
GO
Create PROCEDURE sp_retrieve_pickup_from_search
(
@PICKUP_ID[INT]=NULL,
@SUPPLIER_ID[INT]=NULL,
@WAREHOUSE_ID[INT]=NULL,
@DRIVER_ID[INT]=NULL,@DRIVER_ID_ESCAPE[BIT] = NULL,
@EMPLOYEE_ID[INT]=NULL,@EMPLOYEE_ID_ESCAPE[BIT] = NULL
)
AS
BEGIN
Select PICKUP_ID, SUPPLIER_ID, WAREHOUSE_ID, DRIVER_ID, EMPLOYEE_ID
FROM PICKUP
WHERE (PICKUP.PICKUP_ID=@PICKUP_ID OR @PICKUP_ID IS NULL)
AND (PICKUP.SUPPLIER_ID=@SUPPLIER_ID OR @SUPPLIER_ID IS NULL)
AND (PICKUP.WAREHOUSE_ID=@WAREHOUSE_ID OR @WAREHOUSE_ID IS NULL)
AND (PICKUP.DRIVER_ID=@DRIVER_ID OR @DRIVER_ID IS NULL OR @DRIVER_ID_ESCAPE = 1)
AND (PICKUP.EMPLOYEE_ID=@EMPLOYEE_ID OR @EMPLOYEE_ID IS NULL OR @EMPLOYEE_ID_ESCAPE = 1)
END