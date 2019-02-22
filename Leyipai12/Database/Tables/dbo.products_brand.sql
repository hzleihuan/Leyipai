CREATE TABLE [dbo].[products_brand]
(
[brand_id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[brand_name] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[description] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL,
[state] [tinyint] NULL CONSTRAINT [DF_products_brand_state] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[products_brand] ADD CONSTRAINT [PK_products_brand] PRIMARY KEY CLUSTERED  ([brand_id]) ON [PRIMARY]
GO
