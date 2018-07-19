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
            var tickets = new List<Ticket>();
            var offSet = DateTimeOffset.MinValue;
            while (true)
            {
                Console.WriteLine($"Getting tickets after {offSet.UtcDateTime:u}");
                var newTickets = _client.Tickets.GetIncrementalTicketExport(offSet);
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
                offSet = newTickets.EndTime;
                if (newTickets.Tickets.Count != 1000)
                {
                    return tickets;
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            var offSet = DateTimeOffset.MinValue;
            while (true)
            {
                Console.WriteLine($"Getting users after {offSet.UtcDateTime:u}");
                var newUsers = _client.Users.GetIncrementalUserExport(offSet);
                foreach (var newUser in newUsers.Users)
                {
                    //remove duplicates from the existing list
                    var itemToRemove = users.SingleOrDefault(u => u.Id.Value == newUser.Id.Value);
                    if (itemToRemove != null)
                    {
                        users.Remove(itemToRemove);
                    }
                }
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