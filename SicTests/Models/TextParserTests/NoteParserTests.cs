using Sic.Models.Music;
using Sic.Models.TextParser;
namespace SicTests.Models.TextParserTests;

[TestClass]
public class NoteParserTests
{
    [TestMethod]
    public void TestSmallLetter()
    {
        Tone? note = ToneParser.TryParseNote("a4");
        Assert.IsNotNull(note);
        Assert.AreEqual(440, note.GetFrequency());
    }

}