using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webSpider2
{
    internal class searchEngine
    {
        // a table of the keywords, and webpages asociated with that keyword.
        public Dictionary<string, List<webPage>> keyTable = new Dictionary<string, List<webPage>>();

        List<string> allURL = new List<string>();

        public string fixUrl(webPage p, string link)
        {
            link = Regex.Replace(link, "\\?.*$", "");

            if (link.StartsWith("//"))
            {
                return p.getProtocol() + link;
            }

            if (link.StartsWith("/"))
            {
                return p.getDomain() + link;
            }

            else
            {
                return p.getDomain() + p.getPath() + link;
            }

            return link;
        }

        public void scour(webPage p)
        {
            getHTML(p);
            string tHTML = p.allHTML;
            Console.WriteLine($"Indexing {p.url}");
            foreach (Match m in Regex.Matches(tHTML, "<[aA][^>]+href\\s*=\\s*\"([^\"]*)"))
            {
                string link = fixUrl(p, m.Groups[1].Value);
                p.links.Add(link);
                Console.WriteLine(link);
                webPage newP = new webPage();
                newP.url = link;
                
                if (allURL.Count < 10 && !allURL.Contains(link))
                {
                    scour(newP);
                }
               

            }
            foreach (Match m in Regex.Matches(tHTML, "[a-zA-Z]{3,}"))
            {
                string newKey = m.Groups[0].Value;
               
                if (!p.keywords.Contains(newKey)){
                    p.keywords.Add(newKey);
                    if (!keyTable.ContainsKey(newKey))
                    {
                        List<webPage> nLst = new List<webPage>();
                        keyTable.Add(newKey, nLst);
                        Console.WriteLine($"Adding {newKey} to index for {p.url}");
                    }
                    keyTable[newKey].Add(p);
                    
                }
                
                
            }


        }

        public void getHTML(webPage p)
        {
            WebClient w = new WebClient();
            Stream newStream = w.OpenRead(p.url);
            StreamReader newStreamReader = new StreamReader(newStream);
            p.allHTML = newStreamReader.ReadToEnd();
        }
    }

}
