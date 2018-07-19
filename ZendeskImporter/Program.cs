using System;

namespace ZendeskImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new ZendeskRetriever();
            var persister = new DataPersister();
            
            var tickets = api.GetAllTickets();
            foreach (var ticket in tickets)
            {
                persister.SaveTicket(ticket);
                var comments = api.GetTicketComments(ticket.Id.Value);
                persister.SaveTicketComments(ticket.Id.Value, comments);
                var metrics = api.GetTicketMetrics(ticket.Id.Value);
                persister.SaveTicketMetrics(ticket.Id.Value, metrics);
            }

            var users = api.GetAllUsers();
            persister.SaveUsers(users);


            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}