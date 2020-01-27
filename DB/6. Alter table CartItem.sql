USE [ShoppingCart]
GO

ALTER TABLE [dbo].[CartItem] WITH CHECK ADD CONSTRAINT [FK_CartItem_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CartItem] CHECK CONSTRAINT [FK_CartItem_Customer]
GO
