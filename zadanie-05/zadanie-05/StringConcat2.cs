using System;
namespace zadanie_05
{
    public class StringConcat2
    {
        public static String concat(String one, String two)
        {
            if (one == null || two == null)
            {
                throw new ArgumentNullException("Any of argument cannot be null.");
            }
            return one + two;
        }
    }
}

