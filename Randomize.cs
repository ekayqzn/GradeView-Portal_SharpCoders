using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradesBookApp
{
    public class Randomize
    {
        public string GenerateRandomCode(int length = 8) //default 8 length code when length is not provided
        {
            string result = "";
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random(); //using random class

            for (int i = 0; i < length; i++)
            {
                result += chars[random.Next(chars.Length)].ToString();
            }

            return result;
        }
    }
}
