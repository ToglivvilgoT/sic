#import "@preview/cheq:0.2.2": checklist

#show: checklist

= The goals and functions of the sick sic™ application program.

== Big picture
Node based musik making tool
Basic data-types like notes, rythms, etc.
Combine basic to creat complex like chords, melodies etc.
Simpel serialization so I can feed it all to AI and make automated music

== Components
- Meat of it all
  - data structures
  - functions for combining new data structures
  - Save file format with load and store
- App interface
  - nodes
    - Start nodes for simple data structures (notes etc)
    - Combining nodes for complex data structs (chords etc)
    - Output node for outputting the final song

== Meet the Meat

=== Data structs
- [x] Atoms
  - [x] Note (absolut)
  - [x] rythm
  - [x] Interval (absolute)
    - [x] based
    - [x] sharp / flat
  - [x] Interval (relative)
    - [x] based
- [x] simple
  - [x] scale
  - [x] chords
    //- [ ] chord function // maybe later alligator?
    - [x] abstract chord
    - [x] rooted chord
  - [x] chord prog
  - [x] Melody

=== MVP is DACOOLEST
- [x] Note
- [x] Basic rhythms down to 16s
- [x] Intervals up to octave
- [x] Major scale
- [x] minor, major, dim chords
- [ ] functions
  - [x] note + intervals + rhythm = Melody
  - [ ] note + intervals + rhythm = Melody tests
  - [x] note + intervals = chord
  - [ ] note + intervals = chord tests
  - [x] chords = chord prog
  - [ ] chords = chord prog tests
  - [ ] chords + melody = song
  - [ ] chords + melody = song tests
- [ ] sound for each reasonable types
- [ ] debugPrint for each type?

=== BOTTOM UP X-TREME DEVELOPMENT SCHEME
- [ ] Note
  - [x] Text
  - [x] sound
  - [ ] Methods
  - [ ] Text parsing
- [ ] 