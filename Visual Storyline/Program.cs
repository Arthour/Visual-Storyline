using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Storyline
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VisualStoryline());
        }

        static byte[] EncryptStringToBytes_Aes(string plainText)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
//            if (Container == null)
//                throw new ArgumentNullException("Container");
            byte[] encrypted;

            using (AesManaged aesAlg = new AesManaged())
            {
//                aesAlg.Key = Key;
//                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

        public static string Encrypt(string plainText, System.Security.Cryptography.X509Certificates.X509Certificate2 certificate)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");

            using (var aesManaged = new AesManaged())
            {
                aesManaged.KeySize = 256;
                aesManaged.BlockSize = 128;
                aesManaged.Mode = CipherMode.CBC;

                // Create the streams used for encryption.
                using (var memoryStream = new MemoryStream())
                {
                    // Generate a Symmetric Key used to actually encrypt the data


                    RSAPKCS1KeyExchangeFormatter keyFormatter = new RSAPKCS1KeyExchangeFormatter((RSACryptoServiceProvider)certificate.PublicKey.Key);
                    byte[] keyEncrypted = keyFormatter.CreateKeyExchange(aesManaged.Key, aesManaged.GetType());

                    //byte[] LenSalt = new byte[_saltSize];

                    // Create byte arrays to contain
                    // the length values of the key and IV.
//                    byte[] LenK = new byte[_keyBytes];
//                    byte[] LenIV = new byte[_keyBytes];

                    // Salt genration : 
                    // default iteration count is 1000 in .NET (this is the same as when using Constructor(string password, int salt))
                    //using (var keyDerivationFunction = new Rfc2898DeriveBytes(keyEncrypted, LenSalt, _iterations))
                    //{
                    //    LenSalt = keyDerivationFunction.Salt;
                    //}

                    int lKey = keyEncrypted.Length;
//                    LenK = BitConverter.GetBytes(lKey);
                    int lIV = aesManaged.IV.Length;
//                    LenIV = BitConverter.GetBytes(lIV);

                    // Write the following to the Stream
                    // for the encrypted file (outFs):
                    // - length of the key
                    // - length of the IV
                    // - encrypted key
                    // - the IV
                    // - the encrypted cipher content
//                    memoryStream.Write(LenK, 0, 4);
//                    memoryStream.Write(LenIV, 0, 4);
                    //memoryStream.Write(LenSalt, 0, 4);
                    memoryStream.Write(keyEncrypted, 0, lKey);
                    memoryStream.Write(aesManaged.IV, 0, lIV);
                    //memoryStream.Write(LenSalt, 0, _saltSize);

                    //using (var encryptor = aesManaged.CreateEncryptor(aesManaged.Key, aesManaged.IV))
                    using (var encryptor = aesManaged.CreateEncryptor())
                    using (var memoryStreamEnc = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(memoryStreamEnc, encryptor, CryptoStreamMode.Write))
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            // Send the data through the StreamWriter, through the CryptoStream, to the underlying MemoryStream
                            streamWriter.Write(plainText);
                        }
                        memoryStream.Write(memoryStreamEnc.ToArray(), 0, memoryStreamEnc.ToArray().Length);
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());

                }
            }
        }
    }

    class Variables
    {
        public static string VSL = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Visual Storyline");
        public static string currentPath, currentFolder, currentFile;
        public static string ProgramInfo = System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString();
    }


}
