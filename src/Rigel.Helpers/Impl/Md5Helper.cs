using System.Security.Cryptography;
using System.Text;
using Rigel.Helpers.Interfaces;

namespace Rigel.Helpers.Impl
{
    public class Md5Helper : IPasswordHelper
    {
        public string NewSalt(int length)
        {
            byte[] salt = new byte[length];
            Random rand = new Random();
            rand.NextBytes(salt);
            return Convert.ToHexString(salt);
        }
        public string Hash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public bool Compare(string p1, string p2) 
        {
            return p1.SequenceEqual(p2);
        }
    }
}