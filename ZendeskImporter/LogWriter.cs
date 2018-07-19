using System;
using System.IO;

namespace ZendeskImporter
{
    class LogWriter
    {
        public static void Append(long ticketId)
        {
            string path = @"C:\Users\ben.emmett\Documents\FailedTickets.txt";
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"Failed to import {ticketId} at {DateTime.UtcNow}");
            }
        }
    }
}