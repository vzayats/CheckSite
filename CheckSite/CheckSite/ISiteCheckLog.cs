using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSite
{
  public  interface ISiteCheckLog
    {
	    void CheckLog1(string uri, bool result);
    }
}
