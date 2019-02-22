CREATE TABLE [dbo].[sys_user]
(
[uid] [int] NOT NULL,
[rid] [int] NOT NULL,
[username] [varchar] (128) COLLATE Chinese_PRC_CI_AS NOT NULL,
[password] [varchar] (128) COLLATE Chinese_PRC_CI_AS NOT NULL,
[realname] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[department] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[qq] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[email] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[tel] [varchar] (128) COLLATE Chinese_PRC_CI_AS NULL,
[state] [tinyint] NOT NULL CONSTRAINT [DF_sys_user_state] DEFAULT (0)
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[sys_user] ADD CONSTRAINT [PK_sys_user] PRIMARY KEY CLUSTERED  ([username]) ON [PRIMARY]
GO
