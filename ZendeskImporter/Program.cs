namespace ZendeskImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new ImportRunner("XXXXX", "YYYYY", "ZZZZZ");
            runner.Run();
        }
    }
}