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
  - [x] Interval (absolut)
    - [x] based
    - [x] sharp / flat
  - [x] Interval (relative)
    - [x] based
- [ ] simple
  - [x] scale
  - [x] chords
    - [ ] abstract chord
    - [ ] rooted chord
  - [ ] chord prog
  - [ ] Melody

=== MVP is DACOOLEST
- [x] Note
- [x] Basic rytms down to 16s
- [x] Intervals up to octave
- [x] Major scale
- [x] minor, major, dim chords
- [ ] functions
  - [ ] note + intervals + rythm = Melody
  - [ ] note + intervals + rythm = Melody tests
  - [ ] note + intervals = chord
  - [ ] note + intervals = chord tests
  - [ ] chords = chord prog
  - [ ] chords = chord prog tests
  - [ ] chords + melody = song
  - [ ] chords + melody = song tests
- [ ] sound for each reasonable types
- [ ] debugprint for each type?