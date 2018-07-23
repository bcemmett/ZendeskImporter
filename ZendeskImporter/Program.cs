using System;
using System.Configuration;

namespace ZendeskImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new ImportRunner(
                ConfigurationManager.AppSettings["ZendeskUrl"],
                ConfigurationManager.AppSettings["ZendeskUser"],
                ConfigurationManager.AppSettings["ZendeskToken"],
                ConfigurationManager.ConnectionStrings["ZendeskImport"].ConnectionString);

            runner.Run();
            Console.ReadLine();
        }
    }
}