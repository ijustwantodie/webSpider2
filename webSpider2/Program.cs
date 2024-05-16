namespace webSpider2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nSearch = "d";
            const string BASIC = "https://www.wikipedia.org/";

            webPage wikipedia = new webPage();
            wikipedia.url = BASIC;

            searchEngine newEngine = new searchEngine();
            newEngine.scour(wikipedia);

            while (nSearch != "")
            {
                Console.WriteLine("please enter a keyword for search.");
                nSearch = Console.ReadLine();
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
}