using System;
namespace zadanie_05
{
    public class StringConcat
    {
        public static String concat(String one, String two)
        {
            if (one == null || two == null)
            {
                return null;
            }
            return one + two;
        }
    }
}

