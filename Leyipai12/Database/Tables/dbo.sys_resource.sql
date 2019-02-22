CREATE TABLE [dbo].[sys_resource]
(
[rs_id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[rs_name] [varchar] (256) COLLATE Chinese_PRC_CI_AS NULL,
[rs_url] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[rs_type] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sys_resource] ADD CONSTRAINT [PK_sys_ resource] PRIMARY KEY CLUSTERED  ([rs_id]) ON [PRIMARY]
GO
