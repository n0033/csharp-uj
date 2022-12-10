namespace zadanie_05;

public class Zadanie_02
{

    [Test]
    public void TestConcatNullArgument()
    {
        String one = "elo";
        String two = null;
        var exc = Assert.Throws<ArgumentNullException>(() =>
        {
            StringConcat2.concat(one, two);
        });
        StringAssert.Contains("Any of argument cannot be null.", exc.Message.ToString());
    }

}
