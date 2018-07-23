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
                ConfigurationManager.AppSettings["ZendeskToken"]);

            runner.Run();
        }
    }
}