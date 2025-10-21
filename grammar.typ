Letter -> A | B | ... | G | a | b | ... | g
Digit  -> 0 | 1 | ... | 9
Space = " "

List[T] -> "[" ListContent "]" | "[]"
ListContent[T] -> T | T ", " ListContent[T]

Song -> List[Note]

Note -> Letter Digit | Letter 'b' Digit | Letter '\#' Digit