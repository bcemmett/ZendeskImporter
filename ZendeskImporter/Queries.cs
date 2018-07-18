namespace ZendeskImporter
{
    class Queries
    {
        public const string InsertTicket = @"
INSERT INTO dbo.Tickets ( 
    AssigneeId ,
    BrandId ,
    CreatedAt ,
    Description ,
    DueAt ,
    GroupId ,
    HasIncidents ,
    Id ,
    IsPublic ,
    OrganizationId ,
    Priority ,
    Recipient ,
    RequesterLocaleId ,
    RequesterName ,
    RequesterEmail ,
    RequesterId ,
    SatisfactionRatingScore ,
    SatisfactionRatingComment ,
    Status ,
    Subject ,
    SubmitterId ,
    TicketFormId ,
    Type ,
    UpdatedAt ,
    ViaChannel ,
    ViaSourceFromAddress ,
    ViaSourceFromName ,
    ViaSourceFromFormattedPhone ,
    ViaSourceFromPhone ,
    ViaSourceToAddress ,
    ViaSourceToName ,
    ViaSourceToFormattedphone ,
    ViaSourceToPhone ,
    ViaSourceRel ,
    ViaFollowupSourceId ,
    ForumTopicId ,
    ProblemId ,
    ExternalId
) VALUES (
    @AssigneeId ,
    @BrandId ,
    @CreatedAt ,
    @Description ,
    @DueAt ,
    @GroupId ,
    @HasIncidents ,
    @Id ,
    @IsPublic ,
    @OrganizationId ,
    @Priority ,
    @Recipient ,
    @RequesterLocaleId ,
    @RequesterName ,
    @RequesterEmail ,
    @RequesterId ,
    @SatisfactionRatingScore ,
    @SatisfactionRatingComment ,
    @Status ,
    @Subject ,
    @SubmitterId ,
    @TicketFormId ,
    @Type ,
    @UpdatedAt ,
    @ViaChannel ,
    @ViaSourceFromAddress ,
    @ViaSourceFromName ,
    @ViaSourceFromFormattedPhone ,
    @ViaSourceFromPhone ,
    @ViaSourceToAddress ,
    @ViaSourceToName ,
    @ViaSourceToFormattedphone ,
    @ViaSourceToPhone ,
    @ViaSourceRel ,
    @ViaFollowupSourceId ,
    @ForumTopicId ,
    @ProblemId ,
    @ExternalId
)
";

        public const string InsertTicketTag = @"
INSERT INTO dbo.TicketTags (
    TicketId ,
    Tag
) VALUES (
    @TicketId ,
    @Tag
)
";

        public const string InsertTicketCollaborator = @"
INSERT INTO dbo.TicketCollaborators (
    TicketId ,
    CollaboratorId
) VALUES (
    @TicketId ,
    @CollaboratorId
)
";

        public const string InsertTicketCustomField = @"
INSERT INTO dbo.TicketCustomFields (
    TicketId ,
    CustomFieldId ,
    Value
) VALUES (
    @TicketId ,
    @CustomFieldId ,
    @Value
)
";

        public const string InsertTicketComment = @"
INSERT INTO dbo.TicketComments ( 
    TicketId ,
    Id ,
    Type ,
    Body ,
    HtmlBody ,
    PlainBody ,
    [Public] ,
    AuthorId ,
    ViaChannel ,
    ViaSourceFromAddress ,
    ViaSourceFromName ,
    ViaSourceFromFormattedPhone ,
    ViaSourceFromPhone ,
    ViaSourceToAddress ,
    ViaSourceToName ,
    ViaSourceToFormattedPhone ,
    ViaSourceToPhone ,
    ViaSourceRel ,
    MetaDataCustomTimeSpent ,
    MetaDataSystemIpAddress ,
    CreatedAt
) VALUES (
    @TicketId ,
    @Id ,
    @Type ,
    @Body ,
    @HtmlBody ,
    @PlainBody ,
    @Public ,
    @AuthorId ,
    @ViaChannel ,
    @ViaSourceFromAddress ,
    @ViaSourceFromName ,
    @ViaSourceFromFormattedPhone ,
    @ViaSourceFromPhone ,
    @ViaSourceToAddress ,
    @ViaSourceToName ,
    @ViaSourceToFormattedPhone ,
    @ViaSourceToPhone ,
    @ViaSourceRel ,
    @MetaDataCustomTimeSpent ,
    @MetaDataSystemIpAddress ,
    @CreatedAt
)
";

        public const string InsertTicketMetrics = @"
INSERT INTO dbo.TicketMetrics ( 
    AgentWaitTimeInMinutesBusiness ,
    AgentWaitTimeInMinutesCalendar ,
    AssignedAt ,
    AssigneeStations ,
    AssigneeUpdatedAt ,
    CreatedAt ,
    FirstResolutionTimeInMinutesBusiness ,
    FirstResolutionTimeInMinutesCalendar ,
    FullResolutionTimeInMinutesBusiness ,
    FullResolutionTimeInMinutesCalendar ,
    GroupStations ,
    Id ,
    InitiallyAssignedAt ,
    LastCommentAddedAt ,
    OnHoldTimeInMinutesBusiness ,
    OnHoldTimeInMinutesCalendar ,
    Reopens ,
    Replies ,
    ReplyTimeInMinutesBusiness ,
    ReplyTimeInMinutesCalendar ,
    RequesterUpdatedAt ,
    RequesterWaitTimeInMinutesBusiness ,
    RequesterWaitTimeInMinutesCalendar ,
    SolvedAt ,
    StatusUpdatedAt ,
    TicketId ,
    UpdatedAt
) VALUES (
    @AgentWaitTimeInMinutesBusiness ,
    @AgentWaitTimeInMinutesCalendar ,
    @AssignedAt ,
    @AssigneeStations ,
    @AssigneeUpdatedAt ,
    @CreatedAt ,
    @FirstResolutionTimeInMinutesBusiness ,
    @FirstResolutionTimeInMinutesCalendar ,
    @FullResolutionTimeInMinutesBusiness ,
    @FullResolutionTimeInMinutesCalendar ,
    @GroupStations ,
    @Id ,
    @InitiallyAssignedAt ,
    @LastCommentAddedAt ,
    @OnHoldTimeInMinutesBusiness ,
    @OnHoldTimeInMinutesCalendar ,
    @Reopens ,
    @Replies ,
    @ReplyTimeInMinutesBusiness ,
    @ReplyTimeInMinutesCalendar ,
    @RequesterUpdatedAt ,
    @RequesterWaitTimeInMinutesBusiness ,
    @RequesterWaitTimeInMinutesCalendar ,
    @SolvedAt ,
    @StatusUpdatedAt ,
    @TicketId ,
    @UpdatedAt
)
";
    }
}