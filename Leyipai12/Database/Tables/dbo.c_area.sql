CREATE TABLE [dbo].[c_area]
(
[id] [int] NOT NULL IDENTITY(1, 1) NOT FOR REPLICATION,
[area_name] [nvarchar] (255) COLLATE Chinese_PRC_CI_AS NULL,
[parent_id] [int] NULL,
[language] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[c_area] ADD CONSTRAINT [PK_c_area] PRIMARY KEY CLUSTERED  ([id]) ON [PRIMARY]
GO
