using System;

namespace ZendeskImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new ZendeskRetriever();
            var tickets = api.GetAllTickets();
            var persister = new DataPersister();
            persister.SaveTickets(tickets);
            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
