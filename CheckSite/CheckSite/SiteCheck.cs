using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckSite
{
    internal class SiteCheck
    {
        public class SiteCheck1 : ISiteCheck
        {
            private string uri;

            //сайт для перевірки
            public SiteCheck1()
            {
                uri = "http://dou.ua/";
            }
            //Перевірка відповіді від сайту
            public bool WebSiteCheck()
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(uri);
                    request.Method = WebRequestMethods.Http.Get;
                    request.MaximumResponseHeadersLength = 4;
                    request.Timeout = 200000;
                    HttpWebResponse response = (HttpWebResponse) request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        response.Close();
                        return true;
                    }
                    else
                    {
                        response.Close();
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
