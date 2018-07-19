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
            var tickets = api.GetAllTickets();
            int totalTickets = tickets.Count;
            int currrentTicket = 0;
            int failures = 0;
            foreach (var ticket in tickets)
            {
                if (failures >= 50)
                {
                    Console.WriteLine("Too many failures :-(");
                    Console.ReadLine();
                }
                try
                {
                    Console.WriteLine($"Processing ticket {ticket.Id.Value} ({currrentTicket++} of {totalTickets})");
                    Thread.Sleep(1000);
                    persister.SaveTicket(ticket);
                    var comments = api.GetTicketComments(ticket.Id.Value);
                    persister.SaveTicketComments(ticket.Id.Value, comments);
                    var metrics = api.GetTicketMetrics(ticket.Id.Value);
                    persister.SaveTicketMetrics(ticket.Id.Value, metrics);
                    failures = 0;
                }
                catch (Exception e)
                {
                    failures++;
                    LogWriter.Append(ticket.Id.Value);
                }
            }

            var users = api.GetAllUsers();
            persister.SaveUsers(users);
            
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}