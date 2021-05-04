using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TesteCriptografia
{
    class Program
    {
        static void Main(string[] args)
        {
            EncriptSimetrica("abc");
            DecriptSimetrica();

            //  EncriptAssimetrica("senha1");

            //DescriptAssimetrica("senha1");
            Console.ReadLine();
        }

        private static void DecriptSimetrica()
        {
            try
            {
                using (FileStream fileStream = new FileStream(@"C:\Fapen\TestData.txt", FileMode.Open))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] iv = new byte[aes.IV.Length];
                        int numBytesToRead = aes.IV.Length;
                        int numBytesRead = 0;
                        while (numBytesToRead > 0)
                        {
                            int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
                            if (n == 0) break;

                            numBytesRead += n;
                            numBytesToRead -= n;
                        }

                        byte[] key =
                        {
                            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                        };

                        using (CryptoStream cryptoStream = new CryptoStream(
                           fileStream,
                           aes.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read))
                        {
                            using (StreamReader decryptReader = new StreamReader(cryptoStream))
                            {
                                string decryptedMessage =  decryptReader.ReadToEnd();
                                Console.WriteLine($"The decrypted original message: {decryptedMessage}");
                            }
                        }
                        fileStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The decryption failed. {ex}");
            }
        }

        private static void EncriptSimetrica(string texto)
        {
            try
            {
                using (FileStream fileStream = new FileStream(@"C:\Fapen\TestData.txt", FileMode.OpenOrCreate))
                {
                    using (Aes aes = Aes.Create())
                    {
                        byte[] key =
                        {
                            0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                            0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                         };
                        aes.Key = key;

                        byte[] iv = aes.IV;
                        fileStream.Write(iv, 0, iv.Length);

                        using (CryptoStream cryptoStream = new CryptoStream(
                            fileStream,
                            aes.CreateEncryptor(),
                            CryptoStreamMode.Write))
                        {
                            using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
                            {
                                encryptWriter.Write(texto);
                            }
                        }
                        fileStream.Close();
                    }
                }

                Console.WriteLine("The file was encrypted.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The encryption failed. {ex}");
            }
        }


        private static void EncriptAssimetrica(string texto)
        {

            //Initialize the byte arrays to the public key information.
            byte[] modulus = Encoding.ASCII.GetBytes(texto);
            //{

            //214,46,220,83,160,73,40,39,201,155,19,202,3,11,191,178,56,
            //74,90,36,248,103,18,144,170,163,145,87,54,61,34,220,222,
            //207,137,149,173,14,92,120,206,222,158,28,40,24,30,16,175,
            //108,128,35,230,118,40,121,113,125,216,130,11,24,90,48,194,
            //240,105,44,76,34,57,249,228,125,80,38,9,136,29,117,207,139,
            //168,181,85,137,126,10,126,242,120,247,121,8,100,12,201,171,
            //38,226,193,180,190,117,177,87,143,242,213,11,44,180,113,93,
            //106,99,179,68,175,211,164,116,64,148,226,254,172,147
            // };

            byte[] exponent = { 1, 0, 1 };

            //Create values to store encrypted symmetric keys.
            byte[] encryptedSymmetricKey;
            byte[] encryptedSymmetricIV;

            //Create a new instance of the RSA class.
            RSA rsa = RSA.Create();

            //Create a new instance of the RSAParameters structure.
            RSAParameters rsaKeyInfo = new RSAParameters();

            //Set rsaKeyInfo to the public key values.
            rsaKeyInfo.Modulus = modulus;
            rsaKeyInfo.Exponent = exponent;

            //Import key parameters into rsa.
            // rsa.ImportParameters(rsaKeyInfo);

            //Create a new instance of the default Aes implementation class.
            Aes aes = Aes.Create();

            //Encrypt the symmetric key and IV.
            encryptedSymmetricKey = rsa.Encrypt(aes.Key, RSAEncryptionPadding.Pkcs1);
            encryptedSymmetricIV = rsa.Encrypt(aes.IV, RSAEncryptionPadding.Pkcs1);
        }

        private static void DescriptAssimetrica(string texto)
        {
            //Initialize the byte arrays to the public key information.
            byte[] modulus = Encoding.ASCII.GetBytes(texto);
            //    {
            //    214,46,220,83,160,73,40,39,201,155,19,202,3,11,191,178,56,
            //    74,90,36,248,103,18,144,170,163,145,87,54,61,34,220,222,
            //    207,137,149,173,14,92,120,206,222,158,28,40,24,30,16,175,
            //    108,128,35,230,118,40,121,113,125,216,130,11,24,90,48,194,
            //    240,105,44,76,34,57,249,228,125,80,38,9,136,29,117,207,139,
            //    168,181,85,137,126,10,126,242,120,247,121,8,100,12,201,171,
            //    38,226,193,180,190,117,177,87,143,242,213,11,44,180,113,93,
            //    106,99,179,68,175,211,164,116,64,148,226,254,172,147
            //};

            byte[] exponent = { 1, 0, 1 };

            //Create values to store encrypted symmetric keys.
            byte[] encryptedSymmetricKey;
            byte[] encryptedSymmetricIV;

            //Create a new instance of the RSA class.
            RSA rsa = RSA.Create();

            //Create a new instance of the RSAParameters structure.
            RSAParameters rsaKeyInfo = new RSAParameters();

            //Set rsaKeyInfo to the public key values.
            rsaKeyInfo.Modulus = modulus;
            rsaKeyInfo.Exponent = exponent;

            //Import key parameters into rsa.
            rsa.ImportParameters(rsaKeyInfo);

            //Create a new instance of the default Aes implementation class.
            Aes aes = Aes.Create();

            //Encrypt the symmetric key and IV.
            encryptedSymmetricKey = rsa.Encrypt(aes.Key, RSAEncryptionPadding.Pkcs1);
            encryptedSymmetricIV = rsa.Encrypt(aes.IV, RSAEncryptionPadding.Pkcs1);

            // Export the public key information and send it to a third party.
            // Wait for the third party to encrypt some data and send it back.

            RSA rsa1 = RSA.Create();
            //Decrypt the symmetric key and IV.
            var symmetricKey = rsa1.Decrypt(encryptedSymmetricKey, RSAEncryptionPadding.Pkcs1);
            var symmetricIV = rsa1.Decrypt(encryptedSymmetricIV, RSAEncryptionPadding.Pkcs1);
        }
    }
}
