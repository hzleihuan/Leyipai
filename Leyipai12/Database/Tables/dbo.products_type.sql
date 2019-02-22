CREATE TABLE [dbo].[products_type]
(
[type_id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[parent_id] [int] NULL,
[type_name] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[description] [varchar] (256) COLLATE Chinese_PRC_CI_AS NULL,
[state] [tinyint] NULL CONSTRAINT [DF_products_type_state] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[products_type] ADD CONSTRAINT [PK_products_type] PRIMARY KEY CLUSTERED  ([type_id]) ON [PRIMARY]
GO
