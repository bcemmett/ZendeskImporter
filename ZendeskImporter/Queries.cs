﻿namespace ZendeskImporter
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
    Url ,
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
    ExternalId )
VALUES (
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
    @Url ,
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
    }
}