using System;
using System.Collections.Generic;
using System.Text;

namespace Trustcenter
{
   public class Randomkey
    {
       public string rand()
       {
           Random rnd = new Random();
           long a = rnd.Next(100000000);
           string rn = a.ToString();
           return rn;
       }
    }
}
