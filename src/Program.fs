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

// Right direction of diagonal, like '\' where either `x` and `y` are incremented.
let diagonalRightPath (step: int) (x: int, y: int) : seq<int * int> =
    let minValue = min (x / step) (y / step)
    let mutable mutX = x - (minValue * step)
    let mutable mutY = y - (minValue * step)
    seq {
        while true do
            yield (mutX, mutY)
            mutX <- mutX + step
            mutY <- mutY + step
    }

// Left direction of diagonal, like '/' where `x` is incremented but `y` is decremented.
let diagonalLeftPath (step: int)  (x: int, y: int) : seq<int * int> =
    let mutable mutX = x % step
    let mutable mutY = y + x - mutX
    seq {
        while true do
            yield (mutX, mutY)
            mutX <- mutX + step
            mutY <- mutY - step
    } 

// Right diagonal: '\'
let diagonalRight (row: int, col: int) (arr: 'a[,]) : seq<'a> =
    let countRow = Array2D.length1 arr 
    let countCol = Array2D.length2 arr
    diagonalRightPath 1 (row, col) 
    |> Seq.takeWhile (fun (row', col') -> row' < countRow && col' < countCol)
    |> Seq.map (fun (row', col') -> arr.[row', col'])

// Left diagonal: '/'
let diagonalLeft (row: int, col: int) (arr: 'a[,]) : seq<'a> =
    let countRow = Array2D.length1 arr
    let countCol = Array2D.length2 arr
    diagonalLeftPath 1 (row, col)
    |> Seq.filter (fun (row', col') -> 
        (row' >= 0 && row' < countRow && col' < countCol && col' >= 0) ||
            ((row' < 0 || row' >= countRow) && (col' < 0 || col' >= countCol)))
    |> Seq.takeWhile (fun (row', col') ->
        row' >= 0 && row' < countRow && col' < countCol && col' >= 0)
    |> Seq.map (fun (row', col') -> arr.[row', col']) 
                                    

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
