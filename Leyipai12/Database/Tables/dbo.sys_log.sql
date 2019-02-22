CREATE TABLE [dbo].[sys_log]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[log_time] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[log_username] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[log_info] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sys_log] ADD CONSTRAINT [PK_sys_log] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
