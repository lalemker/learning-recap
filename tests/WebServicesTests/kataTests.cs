namespace WebServicesTests;

  using NUnit.Framework;
  using System;
  using WebServices;

  [TestFixture]
  public class KataTests
  {
    [TestCase("a clash of KINGS", "a an the of", "A Clash of Kings")]
    [TestCase("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
    [TestCase("aBC deF Ghi",null,"Abc Def Ghi")]
    public void MyTest(string sampleTitle, string sampleMinorWords, string expected)
    {
      Assert.AreEqual(expected, Kata.TitleCase(sampleTitle, sampleMinorWords));
    }
    [Test]
    public void MyTest2()
    {
      Assert.AreEqual("", Kata.TitleCase(""));
    }

    [Test]
    public void MyTest3()
    {
      Assert.AreEqual("The Quick Brown Fox", Kata.TitleCase("the quick brown fox"));
    }

    [Test]
    public void MyTest4()
    {
      Assert.AreEqual("", Kata.TitleCase("  "));
    }

  }