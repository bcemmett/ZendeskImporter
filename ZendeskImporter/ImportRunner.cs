using System;

namespace ZendeskImporter
{
    class ImportRunner
    {
        private readonly ZendeskRetriever _api;
        private readonly DataPersister _persister;
        
        public ImportRunner(string zendeskUrl, string zendeskUser, string zendeskToken, string dbConnectionString)
        {
            _api = new ZendeskRetriever(zendeskUrl, zendeskUser, zendeskToken);
            _persister = new DataPersister(dbConnectionString);
        }

        public void Run()
        {
            UpdateTickets();
            UpdateUsers();
            UpdateOrganizations();
            Console.WriteLine("Done");
        }

        private void UpdateTickets()
        {
            var ticketCustomFieldLookup = _api.GetTicketCustomFields();
            var initialStartTime = _persister.GetPreviousHighWatermark(DataPersister.ObjectType.Ticket);
            DateTime finalEndTime;
            var tickets = _api.GetAllTickets(initialStartTime, out finalEndTime);
            int currrentTicket = 1;

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Processing ticket {ticket.Id.Value} ({currrentTicket++} of {tickets.Count})");
                _persister.SaveTicket(ticket, ticketCustomFieldLookup);
                if (ticket.Status != "deleted")
                {
                    var comments = _api.GetTicketComments(ticket.Id.Value);
                    _persister.SaveTicketComments(ticket.Id.Value, comments);
                    var metrics = _api.GetTicketMetrics(ticket.Id.Value);
                    _persister.SaveTicketMetrics(ticket.Id.Value, metrics);
                }
            }
            _persister.SetHighWatermark(DataPersister.ObjectType.Ticket, finalEndTime);
        }

        private void UpdateUsers()
        {
            var users = _api.GetAllUsers();
            _persister.SaveUsers(users);
        }

        private void UpdateOrganizations()
        {
            var orgs = _api.GetAllOrganizations();
            _persister.SaveOrganizations(orgs);
        }
    }
}