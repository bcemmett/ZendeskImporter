using System;
using System.Collections.Generic;
using System.Linq;
using ZendeskApi_v2;
using ZendeskApi_v2.Models.Tickets;

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

        public IList<Comment> GetComments(long ticketId)
        {
            var comments = _client.Tickets.GetTicketComments(ticketId);
            return comments.Comments;
        }
    }
}