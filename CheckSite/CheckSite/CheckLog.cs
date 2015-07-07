using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckSite
{
    class CheckLog : ISiteCheckLog
    {
     DateTime _now = DateTime.Now;
     //Виведення на консоль
	 public void CheckLog1(string uri, bool result)
	    {
         if (result == true)
            {
                Console.WriteLine(_now.ToLongTimeString() + ": Website {0} is available", uri);
            }
            else
            {
                Console.WriteLine(_now.ToLongTimeString() + ": Website {0} is unavailable", uri);
            }
	     Console.WriteLine("Press any key to exit from application\n");
	    }
    }
}
