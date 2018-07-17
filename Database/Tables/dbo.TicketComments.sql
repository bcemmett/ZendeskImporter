CREATE TABLE [dbo].[TicketComments]
(
[TicketId] [bigint] NOT NULL,
[Id] [bigint] NOT NULL,
[Type] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Body] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[HtmlBody] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[PlainBody] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Public] [bit] NULL,
[AuthorId] [bigint] NULL,
[ViaChannel] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromAddress] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromName] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromFormattedPhone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromPhone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToAddress] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToName] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToFormattedPhone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToPhone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceRel] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[MetaDataCustomTimeSpent] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[MetaDataSystemIpAddress] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[CreatedAt] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
