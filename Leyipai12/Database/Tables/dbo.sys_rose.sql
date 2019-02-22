CREATE TABLE [dbo].[sys_rose]
(
[rid] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[rose_name] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[des] [varchar] (256) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sys_rose] ADD CONSTRAINT [PK_sys_rose] PRIMARY KEY CLUSTERED  ([rid]) ON [PRIMARY]
GO
