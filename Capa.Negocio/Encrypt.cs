using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa.Datos;
using System.Security.Cryptography;

namespace Capa.Negocio
{
    public class Encrypt
    {
        public string SHA1(string str)
        {
            string hash;
            byte[] temp;
            SHA1 sha = new SHA1CryptoServiceProvider();

            temp = sha.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                sb.Append(temp[i].ToString("x2"));
            }
            hash = sb.ToString();
            return hash;
        }
    }
}
