using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Organizations;
using ZendeskApi_v2.Models.Tickets;
using ZendeskApi_v2.Models.Users;

namespace ZendeskImporter
{
    class ZendeskRetriever
    {
        private readonly ZendeskApi _client;

        public ZendeskRetriever(string zendeskUrl, string zendeskUser, string zendeskToken)
        {
            _client = new ZendeskApi(zendeskUrl, zendeskUser, zendeskToken, String.Empty);
        }

        public Dictionary<long, string> GetTicketCustomFields()
        {
            var fields = _client.Tickets.GetTicketFields();
            var lookup = fields.TicketFields.ToDictionary(t => t.Id.Value, t => t.Title);
            return lookup;
        }

        public List<Ticket> GetAllTickets(DateTime startTime, out DateTime finalEndTime)
        {
            var tickets = new List<Ticket>();
            while (true)
            {
                Console.WriteLine($"Getting tickets after {startTime:u}");
                var newTickets = _client.Tickets.GetIncrementalTicketExport(startTime);
                foreach (var newTicket in newTickets.Tickets)
                {
                    //remove duplicates from the existing list
                    var itemToRemove = tickets.SingleOrDefault(t => t.Id.Value == newTicket.Id.Value);
                    if (itemToRemove != null)
                    {
                        tickets.Remove(itemToRemove);
                    }
                }
                tickets.AddRange(newTickets.Tickets);
                startTime = newTickets.EndTime;
                if (newTickets.Tickets.Count != 1000)
                {
                    finalEndTime = newTickets.EndTime;
                    return tickets;
                }
                Thread.Sleep(10000);
            }
        }

        public List<User> GetAllUsers(DateTime startTime, out DateTime finalEndTime)
        {
            var users = new List<User>();
            while (true)
            {
                Console.WriteLine($"Getting users after {startTime:u}");
                var newUsers = _client.Users.GetIncrementalUserExport(startTime);
                foreach (var newUser in newUsers.Users)
                {
                    //remove duplicates from the existing list
                    var itemToRemove = users.SingleOrDefault(u => u.Id.Value == newUser.Id.Value);
                    if (itemToRemove != null)
                    {
                        users.Remove(itemToRemove);
                    }
                }
                users.AddRange(newUsers.Users);
                startTime = newUsers.EndTime.UtcDateTime;
                if (newUsers.Users.Count != 1000)
                {
                    finalEndTime = newUsers.EndTime.UtcDateTime;
                    return users;
                }
                Thread.Sleep(10000);
            }
        }

        public List<Organization> GetAllOrganizations(DateTime startTime, out DateTime finalEndTime)
        {
            var orgs = new List<Organization>();
            while (true)
            {
                Console.WriteLine($"Getting organizations after {startTime:u}");
                var newOrgs = _client.Organizations.GetIncrementalOrganizationExport(startTime);
                foreach (var newOrg in newOrgs.Organizations)
                {
                    //remove duplicates from the existing list
                    var itemToRemove = orgs.SingleOrDefault(u => u.Id.Value == newOrg.Id.Value);
                    if (itemToRemove != null)
                    {
                        orgs.Remove(itemToRemove);
                    }
                }
                orgs.AddRange(newOrgs.Organizations);
                startTime = newOrgs.EndTime.UtcDateTime;
                if (newOrgs.Organizations.Count != 1000)
                {
                    finalEndTime = newOrgs.EndTime.UtcDateTime;
                    return orgs;
                }
                Thread.Sleep(10000);
            }
        }

        public IList<Comment> GetTicketComments(long ticketId)
        {
            var comments = new List<Comment>();
            int page = 1;
            while (true)
            {
                var newComments = _client.Tickets.GetTicketComments(ticketId, null, page);
                foreach (var newComment in newComments.Comments)
                {
                    //remove duplicates from the existing list
                    var itemToRemove = comments.SingleOrDefault(c => c.Id.Value == newComment.Id.Value);
                    if (itemToRemove != null)
                    {
                        comments.Remove(itemToRemove);
                    }
                }
                comments.AddRange(newComments.Comments);
                page++;
                if (newComments.Comments.Count != 100)
                {
                    Thread.Sleep(150);
                    return comments;
                }
            }
        }

        public TicketMetric GetTicketMetrics(long ticketId)
        {
            var metrics = _client.Tickets.GetTicketMetricsForTicket(ticketId);
            Thread.Sleep(150);
            return metrics.TicketMetric;
        }
    }
}