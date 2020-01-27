USE [ShoppingCart]
GO

/****** Object:  Table [dbo].[Article] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[PromotionCodeId] int NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Article] WITH CHECK ADD CONSTRAINT [FK_Article_PromotionCode] FOREIGN KEY([PromotionCodeId])
REFERENCES [dbo].[PromotionCode] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_PromotionCode]
GO
