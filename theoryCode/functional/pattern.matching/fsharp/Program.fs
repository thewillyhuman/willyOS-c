
// * Definition of the fibonacci function, using pattern matching (sequence pattern)
let rec fibonacci n =
    match n with
    | 1 -> 1
    | 2 -> 1
    | x -> fibonacci(x - 2) + fibonacci(x - 1)
    ;;

printfn "10th term in the Fibonacci sequence: %d" (fibonacci 10)

// * A new Figure type is defined
type Figure =
    | Circle of double
    | Rectangle of double * double
    | Square of double
    | Triangle of double * double
    ;;

// * The area function uses pattern matching (tree pattern)
let area figure = 
    match figure with
    | Circle (radius) -> System.Math.PI * radius * radius
    | Rectangle(width, height) -> width * height
    | Square (side) -> side * side
    | Triangle (theBase, height) -> theBase * height / 2.0
    ;;
   
// * We use the functions defined above
printfn "Area of the circle: %f" (area (Circle 3.4) )
printfn "Area of the rectangle: %f" (area (Rectangle (2.8, 3.4)) )
printfn "Area of the square: %f" ( area (Square 3.4) )
printfn "Area of the triangle: %f" ( area (Triangle (4.3, 3.4)) )

// * Conditional pattern matching with guards (after the "when" keyword)
// * The regular function returns whether all sides in the figure have the same length
let regular figure = 
    match figure with
    | Square (_) -> true // _ is a wildcard character representing any value
    | Rectangle(width, height) when width = height -> true // returns true when width == height
    | Rectangle(_, _) -> false // returns false for the rest of rectangles
    | Triangle (theBase, height) -> height = theBase * System.Math.Sqrt(3.0) / 2.0 // true if it is isosceles
    | _ -> false // false for the rest of figures (the circle)
    ;;

printfn "Is asquare regular? %b" ( regular (Square 2.8) ) 
printfn "Is a rectangle with different sides regular? %b" ( regular( Rectangle(2.8, 3.2) ) )
printfn "Is a rectangle with all sides equal regular? %b" ( regular( Rectangle(3.2, 3.2) ) )
printfn "Is the following triangle regular? %b" ( regular( Triangle(2.8, 3.2) ) )


// * Pattern matching of lists
let rec concatenate list =
  match list with
  // head :: tail represents the following list pattern: 
  // - head is the first element in the list
  // - tail is the resulting list when the first elment is removed
  | head :: tail -> head + " " + concatenate tail
  | [] -> ""
  ;;

// List are built with the following syntax [;...;]
let list = ["hello"; "world"; "welcome"; "to"; "ML"]

printfn "Resulting string after concatenating the elements in the list: %s" (concatenate list)

// * Map with pattern matching
let rec higherOrder list f =
  match list with
  | head :: tail -> f head :: higherOrder tail f
  | [] -> []
  ;;

printfn "%A" (higherOrder [1; 2; 3; 4; 5] ((+) 1))
