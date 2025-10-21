using Sic.Models.Music;

namespace SicTests.Models.MusicTests;

[TestClass]
public class NoteTests
{
    [TestMethod]
    public void TestGetFrequency()
    {
        double twelfthRootTwo = Math.Pow(2.0, 1.0 / 12.0);
        int[] pitches = [0, 5, -7];
        Note[] notes = [.. pitches.Select(pitch => new Note(pitch))];
        double[] frequencies = [.. notes.Select(note => note.GetFrequency())];
        double[] expected = [.. pitches.Select(pitch => 440.0 * Math.Pow(twelfthRootTwo, pitch - 9))];
        foreach (var (got, exp) in frequencies.Zip(expected)) {
            Assert.AreEqual(exp, got, 0.01);
        }
    }
}