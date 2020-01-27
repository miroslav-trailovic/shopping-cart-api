-- 3 is an example of a new_reseed_value.
DBCC CHECKIDENT ('[dbo].[CartItem]', RESEED, 3);
GO