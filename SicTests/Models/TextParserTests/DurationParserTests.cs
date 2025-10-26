using Sic.Models.Music;
using Sic.Models.TextParser;

namespace SicTests.Models.TextParserTests;

[TestClass]
public class DurationParserTests
{
    private DurationParser parser = new();

    [TestInitialize]
    public void Init()
    {
        parser = new();
    }

    [TestMethod]
    public void TestNormal()
    {
        Duration duration = parser.TryParse(new StringReader("4"));
        Assert.AreEqual(new Duration(1, 4), duration);
    }

    [TestMethod]
    public void TestTriplets()
    {
        Duration duration = parser.TryParse(new StringReader("8T"));
        Assert.AreEqual(new Duration(1, 12), duration);
    }

    [TestMethod]
    public void TestStopsParsing()
    {
        Duration duration = parser.TryParse(new StringReader("16junkJunk16Junk123TTT"));
        Assert.AreEqual(new Duration(1, 16), duration);
    }
}