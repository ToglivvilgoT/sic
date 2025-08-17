class Note
{
    private int Pitch { get; }

    public Note(int pitch) {
        Pitch = pitch;
    }

    public static Note operator +(Note note, AbsoluteInterval interval)
    {
        return new Note(note.Pitch + interval.GetSemitones());
    }
}