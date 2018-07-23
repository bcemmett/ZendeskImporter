CREATE TABLE [dbo].[Users]
(
[Active] [bit] NULL,
[Alias] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[CreatedAt] [datetime] NULL,
[CustomRoleId] [bigint] NULL,
[Details] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Email] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ExternalId] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Id] [bigint] NOT NULL,
[LastLoginAt] [datetime] NULL,
[LocaleId] [bigint] NULL,
[Moderator] [bit] NULL,
[Name] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Notes] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[OnlyPrivateComments] [bit] NULL,
[OrganizationId] [bigint] NULL,
[Phone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[RemotePhotoUrl] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Role] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Shared] [bit] NULL,
[Signature] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Suspended] [bit] NULL,
[TicketRestriction] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[TimeZone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[UpdatedAt] [datetime] NULL,
[Verified] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
