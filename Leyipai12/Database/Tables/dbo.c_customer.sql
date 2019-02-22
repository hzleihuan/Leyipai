CREATE TABLE [dbo].[c_customer]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[username] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[password] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[types] [int] NOT NULL,
[c_name] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[c_code] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[tariffline] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[tel] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[mobile] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[email] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[link_men] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[address] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[account_info] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[prestige_info] [varchar] (1024) COLLATE Chinese_PRC_CI_AS NULL,
[remark] [varchar] (1024) COLLATE Chinese_PRC_CI_AS NULL,
[rank] [tinyint] NULL,
[state] [tinyint] NOT NULL CONSTRAINT [DF_c_customer_state] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[c_customer] ADD CONSTRAINT [PK_c_customer] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
