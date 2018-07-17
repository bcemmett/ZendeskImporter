CREATE TABLE [dbo].[TicketTags]
(
[TicketId] [bigint] NOT NULL,
[Tag] [nvarchar] (max) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
