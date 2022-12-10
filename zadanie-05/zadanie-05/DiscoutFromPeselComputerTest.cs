using System;
namespace zadanie_05
{
    public class DiscoutFromPeselComputerTest
    {
        private string generatePesel(DateTime timestamp, string gender = "0")
        { // gender: odd - male, even - female

            string year = timestamp.Year.ToString().Substring(timestamp.Year.ToString().Length - 2);
            string month;
            if (timestamp.Year >= 2000)
            {
                month = (timestamp.Month + 20).ToString();
            }
            else if (timestamp.Year < 1900)
            {
                month = (timestamp.Month + 80).ToString();
            }
            else
            {
                month = timestamp.Month.ToString();
                if (month.Length == 1)
                {
                    month = "0" + month;
                }
            }
            string day = timestamp.Day.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }

            string sequenceNumber = "";
            Random rand = new Random();
            for(int i = 0; i < 4; i++)
            {
                sequenceNumber += rand.Next(0, 10).ToString();
            }
            string controlNumber = rand.Next(0, 10).ToString();

            return year + month + day + sequenceNumber + controlNumber;
        }

        IDiscountFromPeselComputer discountCalc;
        string pesel;

        [SetUp]
        public void SetUp()
        {
            discountCalc = new DiscountFromPeselComputer();
            pesel = null;
        }

        [Test]
        public void TestNoDiscount()
        {
            pesel = generatePesel(DateTime.Now.AddYears(-50));
            Assert.False(discountCalc.HasDiscount(pesel));
        }

        [Test]
        public void TestDiscountUnder18()
        {
            pesel = generatePesel(DateTime.Now.AddYears(-17));
            Assert.True(discountCalc.HasDiscount(pesel));
        }

        [Test]
        public void TestDiscountAbove65()
        {
            pesel = generatePesel(DateTime.Now.AddYears(-66));
            Assert.True(discountCalc.HasDiscount(pesel));
        }

        [Test]
        public void TestNoDiscountLeftCornerValue()
        {
            pesel = generatePesel(DateTime.Now.AddYears(-18).AddDays(1));

            Assert.False(discountCalc.HasDiscount(pesel));
        }

        [Test]
        public void TestNoDiscountRightCornerValue()
        {
            pesel = generatePesel(DateTime.Now.AddYears(-65).AddDays(1));
            Assert.False(discountCalc.HasDiscount(pesel));
        }

        [Test]
        public void TestDiscountLeftCornerValue()
        {
            pesel = generatePesel(DateTime.Now.AddYears(-65));
            Assert.True(discountCalc.HasDiscount(pesel));
        }

        [Test]
        public void TestDiscountRightCornerValue()
        {
            pesel = generatePesel(DateTime.Now.AddYears(-18));
            Assert.True(discountCalc.HasDiscount(pesel));
        }

        [Test]
        public void TestEmptyString()
        {
            pesel = "";
            Assert.Throws<InvalidPeselException>(() =>
            {
                discountCalc.HasDiscount(pesel);
            });
        }

        [Test]
        public void TestTooLongString()
        {
            pesel = "991111111111";
            Assert.Throws<InvalidPeselException>(() =>
            {
                discountCalc.HasDiscount(pesel);
            });
        }
    }
}

