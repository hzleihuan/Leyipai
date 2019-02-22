CREATE TABLE [dbo].[c_depot]
(
[depot_id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[depot_name] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[state] [tinyint] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[c_depot] ADD CONSTRAINT [PK_c_depot] PRIMARY KEY CLUSTERED  ([depot_id]) ON [PRIMARY]
GO
