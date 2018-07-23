CREATE TABLE [dbo].[Organizations]
(
[CreatedAt] [datetime] NULL,
[Details] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ExternalId] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[GroupId] [bigint] NULL,
[Id] [bigint] NOT NULL,
[Name] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Notes] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[SharedComments] [bit] NULL,
[SharedTickets] [bit] NULL,
[UpdatedAt] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Organizations] ADD CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
