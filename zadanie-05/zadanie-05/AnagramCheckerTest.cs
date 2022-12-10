using System;
namespace zadanie_05
{
    public class AnagramAnagramCheckerTest
    {
        string one, two;

        [SetUp]
        public void setUp()
        {
            one = null;
            two = null;
        }
    
        [Test]
        public void testSameWord(){
            one = "test";
            Assert.True(AnagramChecker.IsAnagram(one, one));
        }

        [Test]
        public void testAnagram(){
            one = "test";
            two = "estt";
            Assert.True(AnagramChecker.IsAnagram(one, one));
        }

        [Test]
        public void testNumbers() {
            one = "test123";
            two = "1t2es3t";
        }

        [Test]
        public void testNonAnagram() {
            one = "test";
            two = "teest";
            Assert.False(AnagramChecker.IsAnagram(one, two));
        }

        [Test]
        public void testUpperLowerCase() {
            one = "TEST";
            two = "test";
            Assert.True(AnagramChecker.IsAnagram(one, two));
        }

        [Test]
        public void testMixedCase() {
            one = "tEsT";
            two = "TeST";
            Assert.True(AnagramChecker.IsAnagram(one, two));
        }

        [Test] // test case written during implementation of the AnagramChecker class
        public void testEmptyString() { 
            one = "";
            two = "test";
            Assert.False(AnagramChecker.IsAnagram(one, two));
            Assert.False(AnagramChecker.IsAnagram(two, one));

        }

        [Test]
        public void testNonAlphaNumeric() {
            one = "T~~~~[][]e';';ts";
            two = "e[()=St<t>";
            Assert.True(AnagramChecker.IsAnagram(one, two));
        }

    }
}

