CREATE TABLE [dbo].[TicketCustomFields]
(
[TicketId] [bigint] NOT NULL,
[CustomFieldId] [bigint] NOT NULL,
[Value] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
