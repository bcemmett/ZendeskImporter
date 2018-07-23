using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ZendeskApi_v2.Models.Tickets;
using ZendeskApi_v2.Models.Users;

namespace ZendeskImporter
{
    class DataPersister
    {
        public void SaveTicket(Ticket ticket)
        {
            SaveRootTicket(ticket);
            SaveTicketTags(ticket.Id.Value, ticket.Tags);
            SaveTicketCollaborators(ticket.Id.Value, ticket.CollaboratorIds);
            SaveTicketCustomFields(ticket.Id.Value, ticket.CustomFields);
        }

        private void SaveTicketCustomFields(long ticketId, IList<CustomField> customFields)
        {
            if (customFields == null)
            {
                return;
            }
            foreach (var customField in customFields)
            {
                SaveTicketCustomField(ticketId, customField);
            }
        }

        private void SaveTicketCustomField(long ticketId, CustomField customField)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TicketId", ticketId));
            parameters.Add(new SqlParameter("@CustomFieldId", customField.Id));
            parameters.Add(new SqlParameter("@Value", (object)customField.Value?.ToString() ?? DBNull.Value));
            RunQuery(Queries.InsertTicketCustomField, parameters);
        }

        private void SaveTicketCollaborators(long ticketId, IList<long> collaborators)
        {
            if (collaborators == null)
            {
                return;
            }
            foreach (var collaborator in collaborators)
            {
                SaveTicketCollaborator(ticketId, collaborator);
            }
        }

        private void SaveTicketCollaborator(long ticketId, long collaborator)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TicketId", ticketId));
            parameters.Add(new SqlParameter("@CollaboratorId", collaborator));
            RunQuery(Queries.InsertTicketCollaborator, parameters);
        }

        private void SaveTicketTags(long ticketId, IList<string> tags)
        {
            if (tags == null)
            {
                return;
            }
            foreach (var tag in tags)
            {
                SaveTicketTag(ticketId, tag);
            }
        }

        private void SaveTicketTag(long ticketId, string tag)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TicketId", ticketId));
            parameters.Add(new SqlParameter("@Tag", tag));
            RunQuery(Queries.InsertTicketTag, parameters);
        }

        private void SaveRootTicket(Ticket ticket)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AssigneeId", (object)ticket.AssigneeId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@BrandId", (object)ticket.BrandId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@CreatedAt", (object)ticket.CreatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Description", (object)ticket.Description ?? DBNull.Value));
            parameters.Add(new SqlParameter("@DueAt", (object)ticket.DueAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@GroupId", (object)ticket.GroupId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@HasIncidents", (object)ticket.HasIncidents ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Id", (object)ticket.Id ?? DBNull.Value));
            parameters.Add(new SqlParameter("@IsPublic", (object)ticket.IsPublic ?? DBNull.Value));
            parameters.Add(new SqlParameter("@OrganizationId", (object)ticket.OrganizationId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Priority", (object)ticket.Priority ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Recipient", (object)ticket.Recipient ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RequesterLocaleId", (object)ticket.Requester?.LocaleId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RequesterName", (object)ticket.Requester?.Name ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RequesterEmail", (object)ticket.Requester?.Email ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RequesterId", (object)ticket.RequesterId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@SatisfactionRatingScore", (object)ticket.SatisfactionRating?.Score ?? DBNull.Value));
            parameters.Add(new SqlParameter("@SatisfactionRatingComment", (object)ticket.SatisfactionRating?.Comment ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Status", (object)ticket.Status ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Subject", (object)ticket.Subject ?? DBNull.Value));
            parameters.Add(new SqlParameter("@SubmitterId", (object)ticket.SubmitterId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@TicketFormId", (object)ticket.TicketFormId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Type", (object)ticket.Type ?? DBNull.Value));
            parameters.Add(new SqlParameter("@UpdatedAt", (object)ticket.UpdatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaChannel", (object)ticket.Via?.Channel ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromAddress", (object)ticket.Via?.Source?.From?.Address ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromName", (object)ticket.Via?.Source?.From?.Name ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromFormattedPhone", (object)ticket.Via?.Source?.From?.FormattedPhone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromPhone", (object)ticket.Via?.Source?.From?.Phone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToAddress", (object)ticket.Via?.Source?.To?.Address ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToName", (object)ticket.Via?.Source?.To?.Name ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToFormattedphone", (object)ticket.Via?.Source?.To?.FormattedPhone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToPhone", (object)ticket.Via?.Source?.To?.Phone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceRel", (object)ticket.Via?.Source?.Rel ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaFollowupSourceId", (object)ticket.ViaFollowupSourceId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ForumTopicId", (object)ticket.ForumTopicId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ProblemId", (object)ticket.ProblemId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ExternalId", (object)ticket.ExternalId?.ToString() ?? DBNull.Value));
            RunQuery(Queries.InsertTicket, parameters);
        }

        public void SaveTicketMetrics(long ticketId, TicketMetric metrics)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AgentWaitTimeInMinutesBusiness", (object)metrics.AgentWaitTimeInMinutes?.Business ?? DBNull.Value));
            parameters.Add(new SqlParameter("@AgentWaitTimeInMinutesCalendar", (object)metrics.AgentWaitTimeInMinutes?.Calendar ?? DBNull.Value));
            parameters.Add(new SqlParameter("@AssignedAt", (object)metrics.AssignedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@AssigneeStations", (object)metrics.AssigneeStations ?? DBNull.Value));
            parameters.Add(new SqlParameter("@AssigneeUpdatedAt", (object)metrics.AssigneeUpdatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@CreatedAt", (object)metrics.CreatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@FirstResolutionTimeInMinutesBusiness", (object)metrics.FirstResolutionTimeInMinutes?.Business ?? DBNull.Value));
            parameters.Add(new SqlParameter("@FirstResolutionTimeInMinutesCalendar", (object)metrics.FirstResolutionTimeInMinutes?.Calendar ?? DBNull.Value));
            parameters.Add(new SqlParameter("@FullResolutionTimeInMinutesBusiness", (object)metrics.FullResolutionTimeInMinutes?.Business ?? DBNull.Value));
            parameters.Add(new SqlParameter("@FullResolutionTimeInMinutesCalendar", (object)metrics.FullResolutionTimeInMinutes?.Calendar ?? DBNull.Value));
            parameters.Add(new SqlParameter("@GroupStations", (object)metrics.GroupStations ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Id", metrics.Id));
            parameters.Add(new SqlParameter("@InitiallyAssignedAt", (object)metrics.InitiallyAssignedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@LastCommentAddedAt", (object)metrics.LatestCommentAddedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@OnHoldTimeInMinutesBusiness", (object)metrics.OnHoldTimeInMinutes?.Business ?? DBNull.Value));
            parameters.Add(new SqlParameter("@OnHoldTimeInMinutesCalendar", (object)metrics.OnHoldTimeInMinutes?.Calendar ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Reopens", (object)metrics.Reopens ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Replies", (object)metrics.Replies ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ReplyTimeInMinutesBusiness", (object)metrics.ReplyTimeInMinutes?.Business ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ReplyTimeInMinutesCalendar", (object)metrics.ReplyTimeInMinutes?.Calendar ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RequesterUpdatedAt", (object)metrics.RequesterUpdatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RequesterWaitTimeInMinutesBusiness", (object)metrics.RequesterWaitTimeInMinutes?.Business ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RequesterWaitTimeInMinutesCalendar", (object)metrics.RequesterWaitTimeInMinutes?.Calendar ?? DBNull.Value));
            parameters.Add(new SqlParameter("@SolvedAt", (object)metrics.SolvedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@StatusUpdatedAt", (object)metrics.StatusUpdatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@TicketId", metrics.TicketId));
            parameters.Add(new SqlParameter("@UpdatedAt", (object)metrics.UpdatedAt?.DateTime ?? DBNull.Value));
            RunQuery(Queries.InsertTicketMetrics, parameters);
        }

        public void SaveTicketComments(long ticketId, IList<Comment> comments)
        {
            if (comments == null)
            {
                return;
            }
            foreach (var comment in comments)
            {
                SaveTicketComment(ticketId, comment);
            }
        }

        private void SaveTicketComment(long ticketId, Comment comment)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@TicketId", ticketId));
            parameters.Add(new SqlParameter("@Id", comment.Id));
            parameters.Add(new SqlParameter("@Type", (object)comment.Type ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Body", (object)comment.Body ?? DBNull.Value));
            parameters.Add(new SqlParameter("@HtmlBody", (object)comment.HtmlBody ?? DBNull.Value));
            parameters.Add(new SqlParameter("@PlainBody", (object)comment.PlainBody ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Public", (object)comment.Public ?? DBNull.Value));
            parameters.Add(new SqlParameter("@AuthorId", (object)comment.AuthorId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaChannel", (object)comment.Via?.Channel ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromAddress", (object)comment.Via?.Source?.From?.Address ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromName", (object)comment.Via?.Source?.From?.Name ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromFormattedPhone", (object)comment.Via?.Source?.From?.FormattedPhone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceFromPhone", (object)comment.Via?.Source?.From?.Phone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToAddress", (object)comment.Via?.Source?.To?.Address ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToName", (object)comment.Via?.Source?.To?.Name ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToFormattedPhone", (object)comment.Via?.Source?.To?.FormattedPhone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceToPhone", (object)comment.Via?.Source?.To?.Phone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ViaSourceRel", (object)comment.Via?.Source?.Rel ?? DBNull.Value));
            parameters.Add(new SqlParameter("@MetaDataCustomTimeSpent", (object)comment.MetaData?.Custom?.TimeSpent ?? DBNull.Value));
            parameters.Add(new SqlParameter("@MetaDataSystemIpAddress", (object)comment.MetaData?.System?.IpAddress ?? DBNull.Value));
            parameters.Add(new SqlParameter("@CreatedAt", (object)comment.CreatedAt?.DateTime ?? DBNull.Value));
            RunQuery(Queries.InsertTicketComment, parameters);
        }

        public void SaveUsers(List<User> users)
        {
            if (users == null)
            {
                return;
            }
            foreach (var user in users)
            {
                SaveUser(user);
            }
        }

        private void SaveUser(User user)
        {
            SaveRootUser(user);
            SaveUserTags(user.Id.Value, user.Tags);
            SaveUserCustomFields(user.Id.Value, user.CustomFields);
        }

        private void SaveRootUser(User user)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Active", (object)user.Active ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Alias", (object)user.Alias ?? DBNull.Value));
            parameters.Add(new SqlParameter("@CreatedAt", (object)user.CreatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@CustomRoleId", (object)user.CustomRoleId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Details", (object)user.Details ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Email", (object)user.Email ?? DBNull.Value));
            parameters.Add(new SqlParameter("@ExternalId", (object)user.ExternalId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Id", user.Id.Value));
            parameters.Add(new SqlParameter("@LastLoginAt", (object)user.LastLoginAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@LocaleId", (object)user.LocaleId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Moderator", (object)user.Moderator ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Name", (object)user.Name ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Notes", (object)user.Notes ?? DBNull.Value));
            parameters.Add(new SqlParameter("@OnlyPrivateComments", (object)user.OnlyPrivateComments ?? DBNull.Value));
            parameters.Add(new SqlParameter("@OrganizationId", (object)user.OrganizationId ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Phone", (object)user.Phone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@RemotePhotoUrl", (object)user.RemotePhotoUrl ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Role", (object)user.Role ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Shared", (object)user.Shared ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Signature", (object)user.Signature ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Suspended", (object)user.Suspended ?? DBNull.Value));
            parameters.Add(new SqlParameter("@TicketRestriction", (object)user.TicketRestriction ?? DBNull.Value));
            parameters.Add(new SqlParameter("@TimeZone", (object)user.TimeZone ?? DBNull.Value));
            parameters.Add(new SqlParameter("@UpdatedAt", (object)user.UpdatedAt?.DateTime ?? DBNull.Value));
            parameters.Add(new SqlParameter("@Verified", (object)user.Verified ?? DBNull.Value));
            RunQuery(Queries.InsertIntoUsers, parameters);
        }

        private void SaveUserTags(long userId, IList<string> tags)
        {
            if (tags == null)
            {
                return;
            }
            foreach (var tag in tags)
            {
                SaveUserTag(userId, tag);
            }
        }

        private void SaveUserTag(long userId, string tag)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            parameters.Add(new SqlParameter("@Tag", tag));
            RunQuery(Queries.InsertUserTag, parameters);
        }

        private void SaveUserCustomFields(long userId, IDictionary<string, object> customFields)
        {
            if (customFields == null)
            {
                return;
            }
            foreach (var customField in customFields)
            {
                SaveUserCustomField(userId, customField.Key, customField.Value);
            }
        }

        private void SaveUserCustomField(long userId, string name, object value)
        {
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            parameters.Add(new SqlParameter("@Name", name));
            parameters.Add(new SqlParameter("@Value", (object)value?.ToString() ?? DBNull.Value));
            RunQuery(Queries.InsertUserCustomField, parameters);
        }

        private void RunQuery(string query, List<SqlParameter> parameters)
        {
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=Zendesk;Integrated Security=true;"))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddRange(parameters.ToArray());
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}