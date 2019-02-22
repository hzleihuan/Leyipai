CREATE TABLE [dbo].[backup_database]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[file_name] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[deal_time] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[backup_database] ADD CONSTRAINT [PK_backup_database] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
