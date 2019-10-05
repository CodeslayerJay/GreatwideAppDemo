--=============================================
-- REVIEW SEED DATA FOR ADVENTURE WORKS
--=============================================
DECLARE @temp_ProductId int
SET @temp_ProductId = (SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY ModifiedDate DESC)
--NEWID()

INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	@temp_ProductId,
	'Bob Bland', GetDate(), 'bod@test.com',	3, 'The product was good. Nothing exceptional.', GetDate())

INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	@temp_ProductId,
	'Billy Boy', GetDate(), 'bod@test.com',	2, 'No Comment.', GetDate())

INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	@temp_ProductId,
	'Susan Sharon', GetDate(), 'sbod@test.com',	4, 'I thought this was an amazing product!', GetDate())

INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	@temp_ProductId,
	'Sally Soup', GetDate(), 'sbod@test.com',	4, null, GetDate())

--=================
--INSERT RANDOMLY
--=================


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	3, 'The product was good. Nothing exceptional.', GetDate())

INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	1, 'The product was good. Nothing exceptional.', GetDate())

INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	1, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	3, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	3, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	5, null, GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	5, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	2, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	3, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	3, null, GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	5, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	3, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	1, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	3, 'The product was good. Nothing exceptional.', GetDate())


INSERT INTO [Production].[ProductReview]
(ProductID, ReviewerName, ReviewDate, EmailAddress, Rating, Comments, ModifiedDate)
	VALUES(
	(SELECT TOP 1 ProductID FROM [Production].[Product] WHERE ListPrice > 0 ORDER BY NEWID()),
	'Bob Bland', GetDate(), 'bod@test.com',	4, 'The product was good. Nothing exceptional.', GetDate())



	