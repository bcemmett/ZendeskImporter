CREATE TABLE [dbo].[TicketMetrics]
(
[AgentWaitTimeInMinutesBusiness] [bigint] NULL,
[AgentWaitTimeInMinutesCalendar] [bigint] NULL,
[AssignedAt] [datetime] NULL,
[AssigneeStations] [bigint] NULL,
[AssigneeUpdatedAt] [datetime] NULL,
[CreatedAt] [datetime] NULL,
[FirstResolutionTimeInMinutesBusiness] [bigint] NULL,
[FirstResolutionTimeInMinutesCalendar] [bigint] NULL,
[FullResolutionTimeInMinutesBusiness] [bigint] NULL,
[FullResolutionTimeInMinutesCalendar] [bigint] NULL,
[GroupStations] [bigint] NULL,
[Id] [bigint] NOT NULL,
[InitiallyAssignedAt] [datetime] NULL,
[LastCommentAddedAt] [datetime] NULL,
[OnHoldTimeInMinutesBusiness] [bigint] NULL,
[OnHoldTimeInMinutesCalendar] [bigint] NULL,
[Reopens] [bigint] NULL,
[Replies] [bigint] NULL,
[ReplyTimeInMinutesBusiness] [bigint] NULL,
[ReplyTimeInMinutesCalendar] [bigint] NULL,
[RequesterUpdatedAt] [datetime] NULL,
[RequesterWaitTimeInMinutesBusiness] [bigint] NULL,
[RequesterWaitTimeInMinutesCalendar] [bigint] NULL,
[SolvedAt] [datetime] NULL,
[StatusUpdatedAt] [datetime] NULL,
[TicketId] [bigint] NOT NULL,
[UpdatedAt] [datetime] NULL
) ON [PRIMARY]
GO
