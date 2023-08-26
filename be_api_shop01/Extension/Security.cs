using System.Security.Cryptography;
using System.Text;

namespace be_api_shop01.Extension
{
    public class Security
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //Tính toán hash từ các byte
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //Lấy kêt quả sau khi tính toán
            byte[] result = md5.Hash;

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //Chuyển đổi
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
