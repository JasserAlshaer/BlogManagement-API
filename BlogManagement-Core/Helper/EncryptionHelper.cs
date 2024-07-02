using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement_Core.Helper
{
    public static class EncryptionHelper
    {
        public static string GetEncryptedString(string input, byte[] key, byte[] Iv)
        {
            byte[] encryptedBytes = null;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = Iv;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Create a CryptoStream object to perform the encryption.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Encrypt the plaintext.
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(input);
                        }

                        encryptedBytes = memoryStream.ToArray();

                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }
        public static string DecryptedString(string input, byte[] key, byte[] Iv)
        {
            string output = null;
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = Iv;
                using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(input)))
                {
                    // Create a CryptoStream object to perform the encryption.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // Encrypt the plaintext.
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            output = streamReader.ReadToEnd();
                        }

                       
                    }
                }
            }
            return output;
        }
    }
}
