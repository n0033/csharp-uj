namespace zadanie_05;

public class Zadanie_01
{

    [Test]
    public void TestConcatNormalOrder()
    {
        String one = "hello";
        String two = "world";
        String result = StringConcat.concat(one, two);
        Assert.AreEqual("helloworld", result);
    }

    [Test]
    public void TestConcatReversedOrder()
    {
        String one = "hello";
        String two = "world";
        String result = StringConcat.concat(two, one);
        Assert.AreEqual("worldhello", result);
    }

    [Test]
    public void TestConcatTrailingSpaces()
    {
        String one = "hello       ";
        String two = "world       ";
        String result = StringConcat.concat(one, two);
        Assert.AreEqual("hello       world       ", result);
    }

    [Test]
    public void TestConcatEmptyString()
    {
        String one = "";
        String two = "nonemptystring";
        String result = StringConcat.concat(one, two);
        Assert.AreEqual("nonemptystring", result);
    }

    [Test]
    public void TestConcatFirstArgumentNull()
    {
        String one = null;
        String two = "siemanko";
        String result = StringConcat.concat(one, two);
        Assert.IsNull(result);
    }

    [Test]
    public void TestConcatSecondArgumentNull()
    {
        String one = "random string";
        String two = null;
        String result = StringConcat.concat(one, two);
        Assert.IsNull(result);
    }
}
