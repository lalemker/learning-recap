namespace WebServicesTests;
using Moq;
using WebServices;

public class Tests
{
    IServiceProcessor servProc;

    [SetUp]
    public void Setup()
    {
        var mock = new Mock<IServiceProcessor>();

        // WOW! No record/replay weirdness?! :)
        mock.Setup(servProc => servProc.CallApi("www.abc.com")).ReturnsAsync("test");

        // Use the Object property on the mock to get a reference to the object
        // implementing ILoveThisLibrary, and then exercise it by calling
        // methods on it
        servProc = mock.Object;
        var download = servProc.CallApi("www.abc.com");

        // Verify that the given method was indeed called with the expected value at most once
        mock.Verify(proc => proc.CallApi("www.abc.com"), Times.AtMostOnce());
    }

    [Test]
    public void TestMock()
    {

        var result = servProc.CallApi("www.abc.com").Result;
        Assert.That(result, Is.EqualTo("test"));
    }

    [Test]
    public void TestMockEmptyUri()
    {

        var result = servProc.CallApi("").Result;
        Assert.That(result, Is.EqualTo(null));
    }
}