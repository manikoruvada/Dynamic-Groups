using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace qunatumkey
{
   public class encrypt
    {
        //  Call this function to remove the key from memory after use for security
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

       static void EncryptFile(string sInputFilename,
         string sOutputFilename,
         string sKey)
       {
           FileStream fsInput = new FileStream(sInputFilename,
              FileMode.Open,
              FileAccess.Read);

           FileStream fsEncrypted = new FileStream(sOutputFilename,
              FileMode.Create,
              FileAccess.Write);
           DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
           //Assign For Encryption
           DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
           DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
           //Starts to encrypt a file
           ICryptoTransform desencrypt = DES.CreateEncryptor();
           //send the converted stream to Output File 
           CryptoStream cryptostream = new CryptoStream(fsEncrypted,desencrypt,
              CryptoStreamMode.Write);

           byte[] bytearrayinput = new byte[fsInput.Length];
           fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
           cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);
           cryptostream.Close();
           fsInput.Close();
           fsEncrypted.Close();
       }

       public string crypt(string t, string rr)
       {
           // Must be 64 bits, 8 bytes.
           // Distribute this key to the user who will decrypt this file.
           string sSecretKey;

           // Get the Key for the file to Encrypt.
           sSecretKey = t;
           string input = rr;
        
           string enc = rr + "_encrypt";    
                  
           GCHandle gch = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned);

           // Encrypt the file.        
           EncryptFile(@rr, @enc, sSecretKey);         

           // Remove the Key from memory. 
           ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2);
           gch.Free();
           return enc;
       }

    }
}
