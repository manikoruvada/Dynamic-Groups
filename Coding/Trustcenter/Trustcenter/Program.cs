using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Trustcenter
{
    public class Program
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
                string sesskey = sesskey1;
                string skb = Convert.ToString(Convert.ToInt32(sesskey, 10), 2);


                Console.WriteLine("SessKey Binary: " + skb);
                //Calling getZero & getOnes Function
                int countZero = getZeros(skb);
                int countOne = getOnes(skb);

                zCount = countZero;
                oCount = countOne;

                //Generate Quantum Key after applying Quantum formula
                int qk = genrateQK(rta, kta, countZero, countOne);
                return qk;
            }

            //Applying Quantum Key Formulae
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

            //Function for Counting Zeros
            public int getZeros(string sesskey)
            {
                int countZero = 0;
                for (int i = 0; i < sesskey.Length; i++)
                {
                    char? c;
                    c = Convert.ToChar(sesskey.Substring((i), 1));

                    if (c == '0')
                    {
                        countZero++;
                    }
                    c = null;
                }
                Console.WriteLine("|0> : " + countZero);
                return countZero;
            }

            //Function for Counting Ones 
            public int getOnes(string sesskey)
            {

                int countOne = 0;
                for (int i = 0; i < sesskey.Length; i++)
                {
                    char c = Convert.ToChar(sesskey.Substring((i), 1));
                    if (c == '1')
                    {
                        countOne++;
                    }
                }
                Console.WriteLine("|1> : " + countOne);
                return countOne;
            }
            
            // Main Program starts
            static void Main(string[] args)
            {
                string st;
                int recv, qkey = 0, recv1,i=0;
                string welcome, input, welcome1, qq, qq1, aa;
                byte[] data = new byte[1024];
                byte[] data1 = new byte[1024];
                NetworkStream ns;
                NetworkStream ns1;

                //For sender
                
                TcpListener newsock = new TcpListener(7000);
                newsock.Start();
                Console.WriteLine("Waiting For Sender Requset...");

                TcpClient Client = newsock.AcceptTcpClient();
                i = 1;
                ns = Client.GetStream();

                TcpListener newsock1 = new TcpListener(6666);
                newsock1.Start();
                Console.WriteLine("Waiting For Recevier Request...");
                TcpClient Client1 = newsock1.AcceptTcpClient();
                i=2;
               ns1 = Client1.GetStream();                
                if (true)
                {
                    recv = ns.Read(data, 0, data.Length);
                    string flagvalue = Encoding.ASCII.GetString(data, 0, recv);
                    int len = flagvalue.Length;
                                     

                    Console.WriteLine("User :" + flagvalue.Substring(12, len - 12));
                    recv1 = ns1.Read(data, 0, data.Length);
                    string flagvalue1 = Encoding.ASCII.GetString(data, 0, recv1);
                    int len1 = flagvalue1.Length;
                    // string uname=flagvalue.Substring(11,
                   // Console.WriteLine("User :" + flagvalue1.Substring(12, len1 - 12));

                    string temp1 = flagvalue1.Substring(0, 4);
                    if (i == 0 || i==1)
                    {
                        Console.WriteLine("Need one More User");
                    }
                    string temp = flagvalue.Substring(0, 4);
                    if (temp == "send" && i==2)
                    {
                        // recv = ns.Read(data, 0, data.Length);
                        //qq = Encoding.ASCII.GetString(data, 0, recv);
                        //string seckey = qq.ToString();

                        string kkey = flagvalue.Substring(4, 8);

                        //recv = ns.Read(data, 0, data.Length);
                        // Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

                        st = Encoding.ASCII.GetString(data, 0, recv);
                        //ns.Flush();


                        Randomkey rk = new Randomkey();
                        string rkey = rk.rand();

                        string rt = Convert.ToString(Convert.ToInt32(rkey, 10), 2);
                        Console.WriteLine("Random BInary :" + rt.ToString());

                        char rta = Convert.ToChar(rt.Substring((rt.Length) - 1));

                        Console.WriteLine("Last Character : " + rta.ToString());

                        SessionKey sk = new SessionKey();
                        string skey = sk.getSessionKey();


                        //  int len = skey.Length;
                        //int rec = recv - 8;
                        // st = st.Substring(0, 7);

                        string kt = Convert.ToString(Convert.ToInt32(kkey, 10), 2);
                        Console.WriteLine("Secret Binary : " + kt.ToString());
                        char kta = Convert.ToChar(kt.Substring((kt.Length) - 1));
                        //char kta=Convert.ToChar(st.Substring(7));
                        Console.WriteLine("Last Character : " + kta.ToString());

                        UpdateKey ukey = new UpdateKey();


                        //string myhex = Convert.ToString(Convert.ToInt32(mybinary, 10), 2);

                        qkey = ukey.getQubit(rta, kta, skey);
                        if (qkey < 0)
                        {
                            qkey = -1 * qkey;
                        }
                        Console.WriteLine("Quantum Key : " + qkey.ToString());

                        aa = qkey.ToString();
                        Int16 kes = Convert.ToInt16(aa);
                        int ss = aa.Length;

                        welcome = qkey.ToString();
                        data = Encoding.ASCII.GetBytes(welcome);
                        ns.Write(data, 0, data.Length);
                        ns1.Write(data, 0, data.Length);
                        Console.ReadLine();
                    }
                }
                
            }

        }
    }
}
    


