using System;
using System.Collections.Generic;
using System.Linq;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Tickets;
using ZendeskApi_v2.Models.Users;

namespace ZendeskImporter
{
    class ZendeskRetriever
    {
        private readonly ZendeskApi _client;

        public ZendeskRetriever()
        {
            _client = new ZendeskApi(
                "XXXXX",
                "YYYYY",
                "ZZZZZ",
                String.Empty);
        }

        public List<Ticket> GetAllTickets()
        {
            var ticketIds = new HashSet<long>();
            var tickets = new List<Ticket>();
            var offSet = DateTimeOffset.MinValue;
            while (true)
            {
                Console.WriteLine($"Getting tickets after {offSet.UtcDateTime:u}");
                var newTickets = _client.Tickets.GetIncrementalTicketExport(offSet);
                tickets.AddRange(newTickets.Tickets.Where(t => !ticketIds.Contains(t.Id.Value)));
                ticketIds.UnionWith(newTickets.Tickets.Select(t => t.Id.Value));
                offSet = newTickets.EndTime;
                if (newTickets.Tickets.Count != 1000)
                {
                    return tickets;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var userIds = new HashSet<long>();
            var users = new List<User>();
            var offSet = DateTimeOffset.MinValue;
            while (true)
            {
                Console.WriteLine($"Getting users after {offSet.UtcDateTime:u}");
                var newUsers = _client.Users.GetIncrementalUserExport(offSet);
                users.AddRange(newUsers.Users.Where(u => !userIds.Contains(u.Id.Value)));
                userIds.UnionWith(newUsers.Users.Select(u => u.Id.Value));
                offSet = newUsers.EndTime;
                if (newUsers.Users.Count != 1000)
                {
                    return users;
                }
            }
        }

        public IList<Comment> GetTicketComments(long ticketId)
        {
            var comments = _client.Tickets.GetTicketComments(ticketId);
            return comments.Comments;
        }

        public TicketMetric GetTicketMetrics(long ticketId)
        {
            var metrics = _client.Tickets.GetTicketMetricsForTicket(ticketId);
            return metrics.TicketMetric;
        }
    }
}