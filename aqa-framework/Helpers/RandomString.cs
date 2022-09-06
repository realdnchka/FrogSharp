using System;
using System.Text;

namespace aqaframework.Helpers
{
    public class RandomString
    {
        public string result;
        public RandomString(int length = 10)
        {
            StringBuilder sb = new();
            Random random = new();

            char ch;

            for (int i = 0; i < length; i++)
            {
                int rnd = random.Next(25);
                ch = Convert.ToChar(rnd + 65);
                sb.Append(ch);
            }

            result = sb.ToString();
        }
    }
}

