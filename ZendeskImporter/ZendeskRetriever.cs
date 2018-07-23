﻿using System;
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
                Thread.Sleep(10000);
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
                users.AddRange(newUsers.Users);
                offSet = newUsers.EndTime;
                if (newUsers.Users.Count != 1000)
                {
                    return users;
                }
                Thread.Sleep(10000);
            }
        }

        public List<Organization> GetAllOrganizations()
        {
            var orgs = new List<Organization>();
            var offSet = DateTimeOffset.MinValue;
            while (true)
            {
                Console.WriteLine($"Getting organizations after {offSet.UtcDateTime:u}");
                var newOrgs = _client.Organizations.GetIncrementalOrganizationExport(offSet);
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
                offSet = newOrgs.EndTime;
                if (newOrgs.Organizations.Count != 1000)
                {
                    return orgs;
                }
                Thread.Sleep(10000);
            }
        }

        public IList<Comment> GetTicketComments(long ticketId)
        {
            var comments = _client.Tickets.GetTicketComments(ticketId);
            Thread.Sleep(150);
            return comments.Comments;
        }

        public TicketMetric GetTicketMetrics(long ticketId)
        {
            var metrics = _client.Tickets.GetTicketMetricsForTicket(ticketId);
            Thread.Sleep(150);
            return metrics.TicketMetric;
        }
    }
}