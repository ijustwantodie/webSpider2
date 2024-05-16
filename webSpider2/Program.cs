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

            Console.WriteLine("please enter a keyword for search.");
            string nSearch = Console.ReadLine();
            if (newEngine.keyTable.ContainsKey(nSearch))
            {
                foreach (webPage p in newEngine.keyTable[nSearch])
                {
                    Console.WriteLine($"Keyword appears on {p.url}");
                }
            }
            else
            {
                Console.WriteLine("keyword not found");

                
            }


        }
    }
}