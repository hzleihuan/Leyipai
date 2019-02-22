CREATE TABLE [dbo].[order_detail]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[order_id] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[products_id] [int] NOT NULL,
[quantity] [int] NOT NULL,
[price] [money] NOT NULL,
[discount_rate] [float] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[order_detail] ADD CONSTRAINT [PK_order_detail] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
