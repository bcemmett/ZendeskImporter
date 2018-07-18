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
                var comments = api.GetComments(ticket.Id.Value);
                persister.SaveTicketComments(ticket.Id.Value, comments);
            }

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
