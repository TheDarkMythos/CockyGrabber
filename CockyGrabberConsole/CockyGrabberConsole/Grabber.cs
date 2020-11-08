using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CockyGrabber;
using Cookie = CockyGrabber.Classes.Cookie;

namespace CockyGrabberConsole
{
    public class Grabber
    {
        // ========== GRAB FIREFOX COOKIES ==========
        public static void GrabFirefoxWithHostname(string hostname)
        {
            Program.WriteLine();
            FirefoxGrabber grabber = new FirefoxGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetCookiesByHostname(hostname))
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }
        public static void GrabFirefox()
        {
            Program.WriteLine();
            FirefoxGrabber grabber = new FirefoxGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetAllCookies())
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }


        // ========== GRAB CHROME COOKIES ==========
        public static void GrabChromeWithHostname(string hostname)
        {
            Program.WriteLine();
            ChromeGrabber grabber = new ChromeGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            if (!grabber.KeyExists())
            {
                Program.WriteLine("Key Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetCookiesByHostname(hostname, grabber.GetKey()))
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }
        public static void GrabChrome()
        {
            Program.WriteLine();
            ChromeGrabber grabber = new ChromeGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            if (!grabber.KeyExists())
            {
                Program.WriteLine("Key Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetAllCookies(grabber.GetKey()))
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }


        // ========== GRAB OPERA GX COOKIES ==========
        public static void GrabOperaGxWithHostname(string hostname)
        {
            Program.WriteLine();
            OperaGxGrabber grabber = new OperaGxGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            if (!grabber.KeyExists())
            {
                Program.WriteLine("Key Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetCookiesByHostname(hostname, grabber.GetKey()))
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }
        public static void GrabOperaGx()
        {
            Program.WriteLine();
            OperaGxGrabber grabber = new OperaGxGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            if (!grabber.KeyExists())
            {
                Program.WriteLine("Key Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetAllCookies(grabber.GetKey()))
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }

        // ========== GRAB OPERA GX COOKIES ==========
        public static void GrabEdgeWithHostname(string hostname)
        {
            Program.WriteLine();
            EdgeGrabber grabber = new EdgeGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            if (!grabber.KeyExists())
            {
                Program.WriteLine("Key Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetCookiesByHostname(hostname, grabber.GetKey()))
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }
        public static void GrabEdge()
        {
            Program.WriteLine();
            EdgeGrabber grabber = new EdgeGrabber();
            if (!grabber.CookiesExists())
            {
                Program.WriteLine("Cookies Not Found!", ConsoleColor.DarkRed);
                return;
            }
            if (!grabber.KeyExists())
            {
                Program.WriteLine("Key Not Found!", ConsoleColor.DarkRed);
                return;
            }
            foreach (Cookie cookie in grabber.GetAllCookies(grabber.GetKey()))
            {
                Program.WriteLine();
                Program.Write($"{cookie.HostName}:\t\t", ConsoleColor.Red);
                Program.Write($"{cookie.Name}=  ", ConsoleColor.Cyan);
                Program.Write($"{cookie.Value}", ConsoleColor.Green);
                Program.WriteLine();
            }
            Program.WriteLine();
        }
    }
}
