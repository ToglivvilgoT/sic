using Sic.Models.Music;
using Sic.Models.TextParser;

namespace SicTests.Models.TextParserTests;

[TestClass]
public class NoteParserTests
{
    private NoteParser noteParser = new();

    [TestInitialize]
    public void Init()
    {
        noteParser = new();
    }

    [TestMethod]
    public void TestNormal()
    {
        Note note = noteParser.TryParse(new StringReader("C4:4"));
        Assert.AreEqual(note.NoteTone, new(0));
        Assert.AreEqual(note.NoteDuration, new(1, 4));
    }
}