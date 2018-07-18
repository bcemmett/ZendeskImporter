using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ZendeskApi_v2.Models.Tickets;

namespace ZendeskImporter
{
    class DataPersister
    {
        public void SaveTickets(List<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                SaveTicket(ticket);
                SaveTicketTags(ticket.Id.Value, ticket.Tags);
                SaveTicketCollaborators(ticket.Id.Value, ticket.CollaboratorIds);
                SaveTicketCustomFields(ticket.Id.Value, ticket.CustomFields);
            }
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

        private void SaveTicket(Ticket ticket)
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
            parameters.Add(new SqlParameter("@Url", (object)ticket.Url ?? DBNull.Value));
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