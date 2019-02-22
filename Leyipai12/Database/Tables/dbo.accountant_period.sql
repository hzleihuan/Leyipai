CREATE TABLE [dbo].[accountant_period]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[period_name] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[Period_bdate] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[Period_edate] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[income] [money] NULL,
[outpay] [money] NULL,
[state] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[accountant_period] ADD CONSTRAINT [PK_accountant_period] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
