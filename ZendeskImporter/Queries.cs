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
    Name ,
    Value
) VALUES (
    @TicketId ,
    @Name ,
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

        public const string InsertUser = @"
INSERT INTO dbo.Users ( 
    Active ,
    Alias ,
    CreatedAt ,
    CustomRoleId ,
    Details ,
    Email ,
    ExternalId ,
    Id ,
    LastLoginAt ,
    LocaleId ,
    Moderator ,
    Name ,
    Notes ,
    OnlyPrivateComments ,
    OrganizationId ,
    Phone ,
    RemotePhotoUrl ,
    Role ,
    Shared ,
    Signature ,
    Suspended ,
    TicketRestriction ,
    TimeZone ,
    UpdatedAt ,
    Verified 
) VALUES (
    @Active ,
    @Alias ,
    @CreatedAt ,
    @CustomRoleId ,
    @Details ,
    @Email ,
    @ExternalId ,
    @Id ,
    @LastLoginAt ,
    @LocaleId ,
    @Moderator ,
    @Name ,
    @Notes ,
    @OnlyPrivateComments ,
    @OrganizationId ,
    @Phone ,
    @RemotePhotoUrl ,
    @Role ,
    @Shared ,
    @Signature ,
    @Suspended ,
    @TicketRestriction ,
    @TimeZone ,
    @UpdatedAt ,
    @Verified
)
";


        public const string InsertUserTag = @"
INSERT INTO dbo.UserTags (
    UserId ,
    Tag
) VALUES (
    @UserId ,
    @Tag
)
";

        public const string InsertUserCustomField = @"
INSERT INTO dbo.UserCustomFields (
    UserId ,
    Name ,
    Value
) VALUES (
    @UserId ,
    @Name ,
    @Value
)
";

        public const string InsertOrganization = @"
INSERT INTO dbo.Organizations ( 
    CreatedAt ,
    Details ,
    ExternalId ,
    GroupId ,
    Id ,
    Name ,
    Notes ,
    SharedComments ,
    SharedTickets ,
    UpdatedAt
) VALUES (
    @CreatedAt ,
    @Details ,
    @ExternalId ,
    @GroupId ,
    @Id ,
    @Name ,
    @Notes ,
    @SharedComments ,
    @SharedTickets ,
    @UpdatedAt
)
";

        public const string InsertOrganizationTag = @"
INSERT INTO dbo.OrganizationTags (
    OrganizationId ,
    Tag
) VALUES (
    @OrganizationId ,
    @Tag
)
";

        public const string InsertOrganizationCustomField = @"
INSERT INTO dbo.OrganizationCustomFields (
    OrganizationId ,
    Name ,
    Value
) VALUES (
    @OrganizationId ,
    @Name ,
    @Value
)
";

        public const string InsertOrganizationDomain = @"
INSERT INTO dbo.OrganizationDomains (
    OrganizationId ,
    Domain
) VALUES (
    @OrganizationId ,
    @Domain
)
";

        public const string DeleteTicket = @"
DELETE FROM dbo.Tickets WHERE Id = @TicketId;
DELETE FROM dbo.TicketTags WHERE TicketId = @TicketId;
DELETE FROM dbo.TicketMetrics WHERE TicketId = @TicketId;
DELETE FROM dbo.TicketComments WHERE TicketId = @TicketId;
DELETE FROM dbo.TicketCollaborators WHERE TicketId = @TicketId;
DELETE FROM dbo.TicketCustomFields WHERE TicketId = @TicketId;
";

        public const string DeleteUser = @"
DELETE FROM dbo.Users WHERE Id = @UserId;
DELETE FROM dbo.UserTags WHERE UserId = @UserId;
DELETE FROM dbo.UserCustomFields WHERE UserId = @UserId;
";

        public const string DeleteOrganization = @"
DELETE FROM dbo.Organizations WHERE Id = @OrganizationId;
DELETE FROM dbo.OrganizationTags WHERE OrganizationId = @OrganizationId;
DELETE FROM dbo.OrganizationCustomFields WHERE OrganizationId = @OrganizationId;
DELETE FROM dbo.OrganizationDomains WHERE OrganizationId = @OrganizationId;
";
    }
}