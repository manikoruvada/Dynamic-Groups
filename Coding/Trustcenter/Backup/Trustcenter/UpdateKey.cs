using System;
using System.Collections.Generic;
using System.Text;

namespace Trustcenter
{
    public class UpdateKey
    {
        static string qqb;
        static public int zCount;
        static public int oCount;
        
        public UpdateKey()
        {
            // getQubit(rta, kta, Sesskey);
        }

        public int getQubit(char rta, char kta, string sesskey1)
        {
            //string sesskey = sesskey1;
            ////long
            //Int64 l1 = Convert.ToInt64(sesskey);
            //Int64  l = l1;
            ////Int64 skb = Convert.ToInt32(l, 2);

            ////string skb = StrToHex.binaryConvertion(l);
            string skb = Convert.ToString(Convert.ToInt32(sesskey1, 10), 2);
            Console.WriteLine("SessKey Binary: " + skb);
            int countZero = getZeros(skb);
            int countOne = getOnes(skb);

            zCount = countZero;
            oCount = countOne;

            int qk = genrateQK(rta, kta, countZero, countOne);
            return qk;
        }

        public int genrateQK(char rta, char kta, int countZero, int countOne)
        {
            int qbt = 0;
            if (rta == '0' && kta == '0')
            {
                qbt = (int)(0.707 * (countZero + countOne));
                qqb = "00";
            }
            else if (rta == '1' && kta == '0')
            {
                qbt = (int)(0.707 * (countZero - countOne));
                qqb = "10";
            }
            else if (rta == '0' && kta == '1')
            {
                qbt = countZero;
                qqb = "01";
            }
            else if (rta == '1' && kta == '1')
            {
                qbt = countOne;
                qqb = "11";
            }
            return qbt;
        }

        public int getZeros(string sesskey)
        {
            int countZero = 0;
            for (int i = 0; i < sesskey.Length; i++)
            {
                char c =Convert.ToChar(sesskey.Substring(i));
                if (c == '0')
                {
                    countZero++;
                }
            }
            Console.WriteLine("000000000: " + countZero);
            return countZero;
        }

        public int getOnes(string sesskey)
        {

            int countOne = 0;
            for (int i = 0; i < sesskey.Length; i++)
            {
                char c =Convert.ToChar(sesskey.Substring(i));
                if (c == '1')
                {
                    countOne++;
                }
            }
            Console.WriteLine("11111111111: " + countOne);
            return countOne;
        }
    }
}
