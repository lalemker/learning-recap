namespace sharedFunctionTests;

public class ValidateWorkingNunitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BasePassTest()
    {
        Assert.Pass();
    }

    [Test]
    public void BaseFakerUsZipCodeTest()
    {
        var zipCode = Faker.Address.ZipCode();
        Assert.Multiple(() =>
        {
            Assert.That(zipCode, Is.Not.Null);
            //Console.WriteLine("US Zip Code: {0}", zipCode.ToString());
            Assert.That(zipCode.Length == 10 || zipCode.Length == 5);
        });
    }

    [Test]
    public void BaseFakerInValidUsZipCodeTest()
    {
        var zipCode = Faker.Address.UkPostCode();
        Assert.Multiple(() =>
        {
            Assert.That(zipCode, Is.Not.Null);
            //Console.WriteLine("non US Zip Code: {0}", zipCode.ToString());
            Assert.That(zipCode.Length != 10 && zipCode.Length != 5);
        });
    }


}