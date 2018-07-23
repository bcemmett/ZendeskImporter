CREATE TABLE [dbo].[OrganizationDomains]
(
[OrganizationId] [bigint] NOT NULL,
[Domain] [nvarchar] (max) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
