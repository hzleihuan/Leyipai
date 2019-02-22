CREATE TABLE [dbo].[depot_products]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[product_id] [int] NULL,
[depot_id] [int] NULL,
[quantity] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[depot_products] ADD CONSTRAINT [PK_depot_products] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
