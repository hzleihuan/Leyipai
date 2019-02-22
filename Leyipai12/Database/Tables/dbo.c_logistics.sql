CREATE TABLE [dbo].[c_logistics]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[logistics_name] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[description] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[c_logistics] ADD CONSTRAINT [PK_c_logistics] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
