using Sic.Models.Music;
using Sic.Models.TextParser.ToneParsers;

namespace SicTestsOld.Models.TextParserTests;

[TestClass]
public class ToneParserTests
{
    private ToneParser toneParser = new();
    private static readonly double twelfthRootTwo = Math.Pow(2, (double)1 / 12);

    [TestInitialize]
    public void Init()
    {
        toneParser = new();
    }

    [TestMethod]
    public void TestA4()
    {
        Tone note = toneParser.TryParse(new StringReader("a4"));
        Assert.AreEqual(440, note.GetFrequency());
    }

    [TestMethod]
    public void TestFlat()
    {
        Tone note = toneParser.TryParse(new StringReader("Ab4"));
        Assert.AreEqual(440 / twelfthRootTwo, note.GetFrequency(), 0.001);
    }

    [TestMethod]
    public void TestSharp()
    {
        Tone note = toneParser.TryParse(new StringReader("A#4"));
        Assert.AreEqual(440 * twelfthRootTwo, note.GetFrequency(), 0.001);
    }

    [TestMethod]
    public void TestD4()
    {
        Tone note = toneParser.TryParse(new StringReader("D5"));
        Assert.AreEqual(440 * Math.Pow(twelfthRootTwo, 5), note.GetFrequency(), 0.001);
    }

    [TestMethod]
    public void TestOctaveLower()
    {
        Tone note = toneParser.TryParse(new StringReader("a3"));
        Assert.AreEqual(440 / 2, note.GetFrequency(), 0.001);
    }

    [TestMethod]
    public void TestOctaveHigher()
    {
        Tone note = toneParser.TryParse(new StringReader("a5"));
        Assert.AreEqual(440 * 2, note.GetFrequency(), 0.001);
    }
}