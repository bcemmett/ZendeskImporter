CREATE TABLE [dbo].[Tickets]
(
[AssigneeId] [bigint] NULL,
[BrandId] [bigint] NULL,
[CreatedAt] [datetime] NULL,
[Description] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[DueAt] [datetime] NULL,
[GroupId] [bigint] NULL,
[HasIncidents] [bit] NULL,
[Id] [bigint] NOT NULL,
[IsPublic] [bit] NULL,
[OrganizationId] [bigint] NULL,
[Priority] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Recipient] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[RequesterLocaleId] [bigint] NULL,
[RequesterName] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[RequesterEmail] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[RequesterId] [bigint] NULL,
[SatisfactionRatingScore] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[SatisfactionRatingComment] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Status] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[Subject] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[SubmitterId] [bigint] NULL,
[TicketFormId] [bigint] NULL,
[Type] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[UpdatedAt] [datetime] NULL,
[ViaChannel] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromAddress] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromName] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromFormattedPhone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceFromPhone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToAddress] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToName] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToFormattedphone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceToPhone] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaSourceRel] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[ViaFollowupSourceId] [bigint] NULL,
[ForumTopicId] [bigint] NULL,
[ProblemId] [bigint] NULL,
[ExternalId] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tickets] ADD CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
