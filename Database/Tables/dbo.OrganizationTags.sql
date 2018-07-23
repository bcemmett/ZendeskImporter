CREATE TABLE [dbo].[OrganizationTags]
(
[OrganizationId] [bigint] NOT NULL,
[Tag] [nvarchar] (max) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
