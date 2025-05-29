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
- Atoms
  - Note (relative)
  - rythm
  - Interval (absolut)
    - based
    - sharp / flat
  - Interval (relative)
    - based
- simple
  - scale
  - chords
  - chord prog
  - Melody

=== MVP is DACOOLEST
- [x] Note
- [x] Basic rytms down to 16s
- [ ] Intervals up to octave
- [ ] Major scale
- [ ] minor, major, dim chords
- [ ] functions
  - [ ] note + intervals + rythm = Melody
  - [ ] note + intervals = chord
  - [ ] chords = chord prog
  - [ ] chords + melody = song
- [ ] sound for each reasonable types
- [ ] debugprint for each type?