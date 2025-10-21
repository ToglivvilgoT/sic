using Sic.Models.Music;
using Sic.Models.TextParser;
namespace SicTests.Models.TextParserTests;

[TestClass]
public class NoteParserTests
{
    [TestMethod]
    public void TestSmallLetter()
    {
        Note? note = NoteParser.TryParseNote("a4");
        Assert.IsNotNull(note);
        Assert.AreEqual(440, note.GetFrequency());
    }

}