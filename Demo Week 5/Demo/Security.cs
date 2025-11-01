using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Week_5
{
    internal class Security
    {
        // AES Encryption & Decryption (Advanced Encryption Standard)
        public static void EncryptDecryptAES()
        {
            string message = "Hello AES!";
            using (Aes aes = Aes.Create())
            {
                byte[] key = aes.Key;
                byte[] iv = aes.IV;

                // Encrypt
                byte[] encrypted = aes.CreateEncryptor(key, iv)
                                      .TransformFinalBlock(Encoding.UTF8.GetBytes(message), 0, message.Length);
                Console.WriteLine("\nAES Encrypted: " + Convert.ToBase64String(encrypted));

                // Decrypt
                byte[] decrypted = aes.CreateDecryptor(key, iv)
                                       .TransformFinalBlock(encrypted, 0, encrypted.Length);
                Console.WriteLine(" AES Decrypted: " + Encoding.UTF8.GetString(decrypted));
            }
        }

        //  RSA Encryption & Decryption (Rivest-Shamir-Adleman)
        public static void EncryptDecryptRSA()
        {
            string message = "Hello RSA!";
            using (RSA rsa = RSA.Create())
            {
                byte[] data = Encoding.UTF8.GetBytes(message);

                // Encrypt with Public Key
                byte[] encrypted = rsa.Encrypt(data, RSAEncryptionPadding.Pkcs1);

                // Decrypt with Private Key
                byte[] decrypted = rsa.Decrypt(encrypted, RSAEncryptionPadding.Pkcs1);
                Console.WriteLine("\n RSA Encrypted: " + Convert.ToBase64String(encrypted));
                Console.WriteLine(" RSA Decrypted: " + Encoding.UTF8.GetString(decrypted));
            }
        }

        //  SHA-256 Hashing
        public static void ComputeSHA256()
        {
            string input = "MyPassword123";
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                Console.WriteLine("\n SHA-256 Hash: " + Convert.ToBase64String(hash));
            }
        }

        //  Digital Signing (RSA)
        public static void DigitalSignAndVerify()
        {
            string message = "Important Message";
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            using (RSA rsa = RSA.Create())
            {
                // Sign the message (private key)
                byte[] signature = rsa.SignData(messageBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                // Verify (public key)
                bool isValid = rsa.VerifyData(messageBytes, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                Console.WriteLine("\n  Digital Signature Valid? " + isValid);
            }
        }

    }
}
