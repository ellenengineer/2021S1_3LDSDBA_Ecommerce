using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.library
{
    public class Security
    {

        private string _txtDesc;
        private string _txtEncr;

        private string FilePAth = @"C:\Fapen\TestData.txt";

        public string DecriptSimetrica()
        {
            //EscreveTextoArquivo(texto);
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
                                string decryptedMessage = decryptReader.ReadToEnd();
                                _txtDesc = decryptedMessage;
                            }
                        }
                        fileStream.Close();
                        File.Delete(FilePAth);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The decryption failed. {ex}");
            }
            return _txtDesc;
        }
        public string EncriptSimetrica(string texto)
        {
            try
            {
                using (FileStream fileStream = new FileStream(FilePAth, FileMode.OpenOrCreate))
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
                                encryptWriter.WriteLine(texto);
                            }
                        }
                    }
                    fileStream.Close();

                    _txtEncr = LerArquivo();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"The encryption failed. {ex}");
            }
            return _txtEncr;
        }

        public string LerArquivo()
        {
            ;
            StringBuilder sb = new StringBuilder();
            if (File.Exists(FilePAth))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(FilePAth))
                    {
                        String linha;
                        // Lê linha por linha até o final do arquivo
                        while ((linha = sr.ReadLine()) != null)
                        {
                            sb.AppendLine(linha);
                        }
                        return sb.ToString();

                        sr.Close();
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            else
            {
                return "nao localizado";
            }
        }

        public void EscreveTextoArquivo(string texto)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePAth))
                {
                    writer.Write(texto);

                    writer.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "  " + ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finalizou a execução");
            }
        }
    }
}
