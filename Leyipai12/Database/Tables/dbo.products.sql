CREATE TABLE [dbo].[products]
(
[product_id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[product_name] [varchar] (256) COLLATE Chinese_PRC_CI_AS NOT NULL,
[type_id] [int] NOT NULL,
[brand_id] [int] NOT NULL,
[cost_price] [money] NULL,
[wholesale_price] [money] NULL,
[retail_price] [money] NULL,
[units] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[weight] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[material] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[spec] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[prc] [varchar] (512) COLLATE Chinese_PRC_CI_AS NULL,
[upperLimit] [int] NULL,
[lowerLimit] [int] NULL,
[expiry_date] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[code] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[description] [varchar] (4000) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[products] ADD CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED  ([product_id]) ON [PRIMARY]
GO
