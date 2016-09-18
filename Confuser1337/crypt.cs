using Confuser1337;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


    public class crypt
    {
        public static void encrypt(string password, string in_, string out_ , string salt , string iv)
        {
            crypting(password, in_, out_, true, salt, iv);
        }


        public static void crypting(string password, string in_, string out_, bool encrypt, string salt, string iv)
        {

            using (FileStream in_s = new FileStream(in_, FileMode.Open, FileAccess.Read))
            {
                using (FileStream out_s = new FileStream(out_, FileMode.Create, FileAccess.Write))
                {

                    cryptstream(password, in_s, out_s, encrypt , salt, iv);
                }
            }

        }

        public static void cryptstream(string password, Stream in_s, Stream out_s, bool encrypt, string saltx, string ivx)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

            int keysize = 0;
            for (int i = 1024; i > 1; i--)
            {
                if (aes.ValidKeySize(i))
                {
                    keysize = i;
                    break;
                }
            }

            int blocksize = aes.BlockSize;

            byte[] key = null;
            byte[] iv = null;
            byte[] salt = null;
                iv = Encoding.ASCII.GetBytes(ivx);
                salt = Encoding.ASCII.GetBytes(saltx);
            make(password, salt, keysize, blocksize, out key, out iv);
            ICryptoTransform crypto;
            if (encrypt)
            {
                crypto = aes.CreateEncryptor(key, iv);
            }
            else
            {
                crypto = aes.CreateDecryptor(key, iv);
            }

            try
            {
                using (CryptoStream crypto_s = new CryptoStream(out_s, crypto, CryptoStreamMode.Write))
                {

                    const int blocksize2 = 1024;
                    byte[] buffer = new byte[blocksize2];
                    int bytes;
                    while (true)
                    {

                        bytes = in_s.Read(buffer, 0, blocksize);
                        if (bytes == 0) break;


                        crypto_s.Write(buffer, 0, bytes);
                    }


                    
                }
            }
            catch
            {
            }

            crypto.Dispose();
            if (encrypt)
            {



            }

        }

        private static void make(string password, byte[] salt, int key_size, int block_size, out byte[] key, out byte[] iv)
        {
            Rfc2898DeriveBytes b = new Rfc2898DeriveBytes(password, salt, 1000);

            key = b.GetBytes(key_size / 8);
            iv = b.GetBytes(block_size / 8);

        }
      
       
        
    }
public static class class2
{
    public static IEnumerable<byte[]> Szplit(this byte[] value, int bufferLength)
    {
        int countOfArray = value.Length / bufferLength;
        if (value.Length % bufferLength > 0)
            countOfArray++;
        for (int i = 0; i < countOfArray; i++)
        {
            yield return value.Skip(i * bufferLength).Take(bufferLength).ToArray();

        }
    }
}
