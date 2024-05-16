namespace webSpider2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            const string BASIC = "https://www.wikipedia.org/";

            webPage wikipedia = new webPage();
            wikipedia.url = BASIC;

            searchEngine newEngine = new searchEngine();
            newEngine.scour(wikipedia);
            

        }
    }
}