--================================================
--SAMPLE STORED PROCEDURE FOR GREATWIDE APP DEMO
--================================================

USE [AdventureWorks]
GO

CREATE OR ALTER PROCEDURE spProducts_GetProduct(@product_id int)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [AdventureWorks].[Production].[Product] WHERE ProductID = @product_id
END
