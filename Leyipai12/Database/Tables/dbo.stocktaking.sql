CREATE TABLE [dbo].[stocktaking]
(
[id] [int] NOT NULL IDENTITY(1, 1),
[depot_id] [int] NULL,
[stocktaking_id] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL,
[takinger] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[taking_date] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[taking_des] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[state] [tinyint] NULL CONSTRAINT [DF_stocktaking_state] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[stocktaking] ADD CONSTRAINT [PK_stocktaking] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
