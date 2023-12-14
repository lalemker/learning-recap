namespace sharedFunctionTests;
using sharedFunctions;

public class SharedTests
{
    DoTheMath doTheMathRunner = new DoTheMath();

    [SetUp]
    public void Setup()
    {
      
    }
  
    [Test]
    public void ValueIsNotEven() 
    {
        var result = doTheMathRunner.AmIEven(decimal.Parse("2.124003"));
        Assert.That(result, Is.False);
    }

    [Test]
    public void ValueIsEven() 
    {
        var result = doTheMathRunner.AmIEven(decimal.Parse("1.21290318"));
        Assert.That(result, Is.False);
    }

    [Test]
    public void ValueIsZero() 
    {
        var result = doTheMathRunner.AmIEven(0);
        Assert.That(result, Is.False);
    }

    
}
