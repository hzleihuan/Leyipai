CREATE TABLE [dbo].[stocktaking_detail]
(
[id] [int] NOT NULL,
[stocktaking_id] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL,
[product_id] [int] NOT NULL,
[oldstock] [int] NULL,
[newstock] [int] NULL,
[dealstock] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stocktaking_detail] ADD CONSTRAINT [PK_stocktaking_detail] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
