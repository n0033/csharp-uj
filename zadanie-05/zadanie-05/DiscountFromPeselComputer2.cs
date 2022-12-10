using System;
namespace zadanie_05
{
    public class DiscountFromPeselComputer2 : IDiscountFromPeselComputer
    {

        public bool HasDiscount(string pesel)
        {
            if (pesel.Length != 11)
            {
                throw new InvalidPeselException("Length of pesel must be 11.");
            }
            int year = Int32.Parse(pesel.Substring(0, 2));
            int month = Int32.Parse(pesel.Substring(2, 2));
            int day = Int32.Parse(pesel.Substring(4, 2));

            if (month > 80)
            {
                year = Int32.Parse("18" + year.ToString());
                month -= 80;
            } else if (month > 30)
            {
                year = Int32.Parse("20" + year.ToString());
                month -= 20;
            } else
            {
                year = Int32.Parse("19" + year.ToString());
            }

            if (month < 1 || month > 12)
            {
                throw new InvalidPeselException("Invalid month.");
            }

            if (day < 1 || month > 31)
            {
                throw new InvalidPeselException("Invalid day.");
            }
            DateTime now = DateTime.Now;
            int age = now.Year - year;
            if (month == now.Month)
            {
                if (day < now.Day)
                {
                    age -= 1;
                }
            } else if (month < now.Month)
            {
                age -= 1;
            }

            if (age.IsBetween(18, 65))
            {
                return false;
            }
            return true;
        }
    }
}

