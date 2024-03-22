using System.Security.Cryptography;
using System.Text;

namespace Escuela.Models
{
    public class cEncriptar
    {
        //Encriptar datos con SHA256
        public static string ToSHA256(string dato)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(dato));

            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static string ToMD5(string dato)
        {
            string hash = "B:e_r'e.l{a^p}p";
            byte[] datoencriptado = UTF8Encoding.UTF8.GetBytes(dato);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(datoencriptado, 0, dato.Length);

            return Convert.ToBase64String(result);
        }


        public static string DecriptMD5(string datoencriptado)
        {
            string hash = "B:e_r'e.l{a^p}p";
            byte[] dato = Convert.FromBase64String(datoencriptado);

            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            tripledes.Mode = CipherMode.ECB;

            ICryptoTransform transform = tripledes.CreateDecryptor();
            byte[] result = transform.TransformFinalBlock(dato, 0, dato.Length);

            return UTF8Encoding.UTF8.GetString(result);
        }
    }
}
