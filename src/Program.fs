module TicTacToe.App

type Console = System.Console
type Int32 = System.Int32

let readIntInput (message: string) : option<int> =
    try
        printf "%s" message
        let input : int = Int32.Parse(Console.ReadKey().KeyChar.ToString())
        printfn ""
        Some input
    with
        | ex -> None

let readRow () : option<int> =
    readIntInput "Please select a row: "        

let readColumn () : option<int> =
    readIntInput "Please select a column: "

let board (initialValue: char) (size: int) : char[,] =
    Array2D.create size size initialValue

let rows (matrix: 'a[,]) : array<list<'a>> =
    let lastRowIndex = Array2D.length1 matrix - 1
    [| for rowIndex in 0 .. lastRowIndex do yield matrix.[rowIndex, *] |> Array.toList |]

let columns (matrix: 'a[,]) : array<list<'a>> =
    let lastColumnIndex = Array2D.length2 matrix - 1
    [| for columnIndex in 0 .. lastColumnIndex do yield matrix.[*, columnIndex] |> Array.toList |]

let allSame (initialValue: 'a) (coll: list<'a>) =
    match coll with
    | [] | [_] -> true
    | x::lx when lx |> List.forall ((=) x) && x <> initialValue -> true
    | _ -> false
                    

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
