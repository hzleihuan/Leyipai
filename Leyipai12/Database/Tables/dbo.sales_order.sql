CREATE TABLE [dbo].[sales_order]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[period_id] [int] NOT NULL CONSTRAINT [DF_sales_order_period_id] DEFAULT (0),
[sales_orderId] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[create_date] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[sales_type] [int] NOT NULL,
[customer_id] [int] NOT NULL,
[depot_id] [int] NOT NULL,
[delivery_type] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[delivery_place] [varchar] (180) COLLATE Chinese_PRC_CI_AS NULL,
[logistics_id] [int] NULL,
[logistics_num] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[sales_income] [money] NULL,
[attach_pay] [money] NULL,
[discount] [money] NULL,
[username] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[auditing_user] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[description] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[state] [int] NOT NULL CONSTRAINT [DF_sales_order_state] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sales_order] ADD CONSTRAINT [PK_sales_order] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
