using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ninject;

namespace CheckSite
{
    class Program
    {
        private static void Main(string[] args)
        {
            string uri = "http://dou.ua";

            string logType = string.Empty;
            IoCContainerInit(logType);

            var siteChecker = IoCContainer.Get<ISiteCheck>();
            var siteCheckLogger = IoCContainer.Get<ISiteCheckLog>();

            StartCheck(siteChecker, siteCheckLogger, uri);
        }
        //Запуск перевірки доступності сайту
        private static void StartCheck(ISiteCheck siteChecker, ISiteCheckLog siteCheckLogger, string uri)
        {
            do
            {
                var result = siteChecker.WebSiteCheck();
                siteCheckLogger.CheckLog1(uri, result);
            } 
                while (Console.KeyAvailable == false);
        }
        //вибір параметру виводу 
        private static void IoCContainerInit(string Void)
        {
            Console.WriteLine("Сhoose where to display results:");
            Console.WriteLine("For a console output type value 'c'");
            Console.WriteLine("For save output to file type value 'f'");
            Console.WriteLine("For a console output and save to file type value 'a'");
            string valueinput = Console.ReadLine();
            IoCContainer.Initialize((kernel) =>
            {
                kernel.Bind<ISiteCheck>().To<SiteCheck.SiteCheck1>().InTransientScope();

                switch (valueinput)
                {
                    case "c":
                        kernel.Bind<ISiteCheckLog>().To<CheckLog>().InTransientScope();
                        break;
                    case "f":
                        kernel.Bind<ISiteCheckLog>().To<TextCheckLog>().InTransientScope();
                        break;
                    case "a":
                        kernel.Bind<ISiteCheckLog>().To<TextCheckLog>().InTransientScope();
                        kernel.Bind<ISiteCheckLog>().To<CheckLog>().InTransientScope();
                        break;
                    default:
                        Console.WriteLine("You enter the invalid value!");
                        kernel.Bind<ISiteCheckLog>().To<CheckLog>().InTransientScope();
                        break;
                }
            });
        }
    }
}
