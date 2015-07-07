using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSite
{
    class TextCheckLog : ISiteCheckLog
    {
        string _message;
        DateTime now = DateTime.Now;

        //Збереження у текстовий файл CheckLog.txt
        public void CheckLog1(string uri, bool result)
        {
            if (result == true)
            {
                _message = now.ToLongTimeString() + ": Website " + uri + " is available";
            }
            else 
            {
                _message = now.ToLongTimeString() + ": Website" + uri + "is unavailable";
            }
            
            using (StreamWriter checkLogFile = File.AppendText(@"..\..\CheckLog.txt"))   
            {
                checkLogFile.WriteLine(_message);
            }
            //Повідомлення про успішний запис у файл
            Console.WriteLine("Check log successfully written in the file");
            Console.WriteLine("Press any key to exit from application\n");
            }
    }
}
