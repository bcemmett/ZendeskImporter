CREATE TABLE [dbo].[UserCustomFields]
(
[UserId] [bigint] NOT NULL,
[Key] [nvarchar] (max) COLLATE Latin1_General_CI_AS NOT NULL,
[Value] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
