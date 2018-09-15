using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Receiver
{
    public class Decrypt
    {
        static void DecryptFile(string sInputFilename,string sOutputFilename,string sKey,string ss)
        {
            //byte[] bytIn = System.Text.ASCIIEncoding.ASCII.GetBytes(ss);


           
           // System.IO.MemoryStream ms=new System.IO.MemoryStream(bytIn,0,bytIn.Length);            

            DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
            //A 64 bit key and IV is required for this provider.
            //Set secret key For DES algorithm.
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //Set initialization vector.
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);

            //Create a file stream to read the encrypted file back.
            FileStream fsread = new FileStream(sInputFilename,FileMode.Open,FileAccess.Read);
            //Create a DES decryptor from the DES instance.
            ICryptoTransform desdecrypt = DES.CreateDecryptor();
            //Create crypto stream set to read and do a 
            //DES decryption transform on incoming bytes.
            CryptoStream cryptostreamDecr = new CryptoStream(fsread,desdecrypt,CryptoStreamMode.Read);
                    
           
            //Print the contents of the decrypted file.           
            //StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
           // cryptostreamDecr.Write(bytIn, 0, bytIn.Length);
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
          }

        public string crypt(string a,string aa,string ss)
        {
            string sSecretKey;
            sSecretKey = a;
            string input = aa;
            string dc = aa + "_decrypt";
            GCHandle gch = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned);
            DecryptFile(@input, @dc, sSecretKey,ss);
            //ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2);
            gch.Free();
            return dc;

        }
    }
}
