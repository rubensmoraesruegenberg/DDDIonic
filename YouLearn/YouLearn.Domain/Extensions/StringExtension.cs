using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Extensions
{
    //Tem que se criar com static
    public static class StringExtension
    {
        //Quando utiliza this conforme no exemplo, se cria uma exetensão para a string (this string text) 
        //public static string ConvertToMD5(this string text)
        //{
        //    if (string.IsNullOrEmpty(text)) return "";
        //    var passaword = (text += "|2d331cca-f6c0-40c0-bb43-6e32989c28");
        //    var md5 = System.Security.Cryptography.MD5.Create();
        //    var data = md5.ComputeHash(Encoding.Default.GetBytes(passaword));
        //    var sbString = new StringBuilder();
        //    foreach (var t in data)
        //    {
        //        sbString.Append(t.ToString("x2"));

        //    }

        //    return sbString.ToString();
        //}

        //Quando utiliza this conforme no exemplo, se cria uma exetensão para a string (this string text) 
        public static string ConvertToMD5(this string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

    }
}
