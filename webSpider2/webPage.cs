using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace webSpider2
{
    internal class webPage
    {
        // the url of the webpage
        public string url;

        // any keywords associated with the webpage
        public List<string> keywords = new List<string>();

        // the html code of the webpage
        public string allHTML;

        public List<string> links = new List<string>(); 

        public string getProtocol()
        {
            return Regex.Match(this.url, "^http[s]:").Value;
        }

        public string getDomain()
        {
            return Regex.Match(this.url, "^http[s]:\\/\\/[^\\/]+").Value;
        }

        public string getPath()
        {
            string domain = this.getDomain();
            string path = this.url.Replace(domain, "");
            string[] paths = path.Split('/');
            path = "";
            for (int i = 0; i < paths.Length-1; i++)
            {
                path += paths[i] + "/";
            }
            return path;
        }
    }
}
