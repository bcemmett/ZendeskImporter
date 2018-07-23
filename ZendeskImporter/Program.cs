using System;
using System.Threading;

namespace ZendeskImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new ZendeskRetriever();
            var persister = new DataPersister();

            var ticketCustomFieldLookup = api.GetTicketCustomFields();
            var tickets = api.GetAllTickets();
            int totalTickets = tickets.Count;
            int currrentTicket = 0;

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Processing ticket {ticket.Id.Value} ({currrentTicket++} of {totalTickets})");
                Thread.Sleep(250);
                if (ticket.Status != "deleted")
                persister.SaveTicket(ticket, ticketCustomFieldLookup);
                {
                    var comments = api.GetTicketComments(ticket.Id.Value);
                    persister.SaveTicketComments(ticket.Id.Value, comments);
                    var metrics = api.GetTicketMetrics(ticket.Id.Value);
                    persister.SaveTicketMetrics(ticket.Id.Value, metrics);
                }
            }

            var users = api.GetAllUsers();
            persister.SaveUsers(users);
            
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}