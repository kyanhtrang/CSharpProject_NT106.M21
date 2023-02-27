using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject
{
    class RSA
    {
        private static int[] publicKey = { 7, 187 };
        private static int[] privateKey = { 23, 187 };

        private byte encode(byte data)
        {
            long dataBase64 = (long)data;
            long newDataBase64 = (long)Math.Pow(dataBase64, publicKey[0]) % publicKey[1];
            byte newData = (byte)newDataBase64;
            return newData;
        }
        public byte[] encrypt(byte[] data)
        {
            byte[] encryptedData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                encryptedData[i] = encode(data[i]);
            }
            return encryptedData;
        }

        private long getModKey(long number)
        {
            //vì key là 23 nên sẽ lấy số^23 rồi lấy dư với 187 nên sẽ chia thành (số^6 số^6 số^6 số^5) % 187
            long du1 = (long)(Math.Pow(number, 6) % privateKey[1]);
            long du2 = (long)(Math.Pow(number, 5) % privateKey[1]);

            long du3 = (du1 * du1) % privateKey[1];
            long du4 = (du1 * du2) % privateKey[1];

            long du5 = (du3 * du4) % privateKey[1];
            return du5;
        }

        private byte decode(byte data)
        {
            long messBase64 = (long)data;
            long Du = getModKey(messBase64);
            byte newData = (byte)Du;
            return newData;
        }

        private byte[] decrypt(byte[] mess)
        {

            byte[] decryptedMess = new byte[mess.Length];
            for (int i = 0; i < mess.Length; i++)
            {
                decryptedMess[i] = decode(mess[i]);
            }
            return decryptedMess;
        }
    }
}
