using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Helper
{
    public class TextEncryption
    {
        public static string Encrypt(string plaintextString)
        {
            return Encrypt(plaintextString, "LM+RYb8I");
        }

        private static string Encrypt(string plaintextString, string encryptionSalt)
        {
            if (String.IsNullOrEmpty(plaintextString))
            {
                return string.Empty;
            }
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(encryptionSalt);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            //AesCryptoServiceProvider cryptoProvider = new AesCryptoServiceProvider();


            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(plaintextString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

        }

        public static string Decrypt(string encryptedText)
        {
            try
            {
                return Decrypt(encryptedText, "LM+RYb8I");
            }
            catch(Exception e)
            {
                var x = e.Message;
                return string.Empty;
            }
        }

        private static string Decrypt(string encryptedText, string encryptionSalt)
        {
            if (String.IsNullOrEmpty(encryptedText))
            {
                return string.Empty;
            }
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(encryptionSalt);
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();

        }
    }
}
