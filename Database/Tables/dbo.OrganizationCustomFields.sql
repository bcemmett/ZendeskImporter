CREATE TABLE [dbo].[OrganizationCustomFields]
(
[OrganizationId] [bigint] NOT NULL,
[Name] [nvarchar] (max) COLLATE Latin1_General_CI_AS NOT NULL,
[Value] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
