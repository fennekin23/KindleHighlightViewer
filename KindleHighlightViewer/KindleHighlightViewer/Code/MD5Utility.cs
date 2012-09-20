using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace KindlHighlightViewer.Code
{
    /// <summary>
    /// Logic for checking md5.
    /// </summary>
    public class MD5Utility
    {
        public bool IsNewFile(Stream inputStream)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string newHash = GetMd5Hash(md5Hash, inputStream);
                string oldHash = File.ReadAllText("Hash.txt");
                bool result = !IsSame(newHash, oldHash);
                if (result) // if new file need to parse
                {
                    File.WriteAllText("Hash.txt", newHash);
                }
                return result;
            }
        }

        private string GetMd5Hash(MD5 md5Hash, Stream inputStream)
        {
            byte[] data = md5Hash.ComputeHash(inputStream);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        private bool IsSame(string newHash, string oldHash)
        {
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (comparer.Compare(newHash, oldHash) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
