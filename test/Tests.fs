module Tests

open TicTacToe.App
open Xunit

// ---------------------------------
// isWinner
// ---------------------------------

[<Fact>]
let ``Test of isWinner function`` () =
    let initialValue : char = ' '
    let board : char[,] = 
        [|
            [|'x';'x';'o'|]
            [|'x';'x';'o'|]
            [|' ';' ';' '|]
        |] |> array2D
    Assert.Equal(false, isWinner initialValue board)

    let board : char[,] = 
        [|
            [|' ';' ';' '|]
            [|' ';' ';' '|]
            [|' ';' ';' '|]
        |] |> array2D
    Assert.Equal(false, isWinner initialValue board)

    let board : char[,] = 
        [|
            [|'x';' ';' '|]
            [|' ';'x';' '|]
            [|' ';' ';'x'|]
        |] |> array2D
    Assert.Equal(true, isWinner initialValue board)

    let board : char[,] = 
        [|
            [|'o';'o';'o'|]
            [|' ';'x';' '|]
            [|' ';' ';'x'|]
        |] |> array2D
    Assert.Equal(true, isWinner initialValue board)

    let board : char[,] = 
        [|
            [|'x';' ';'o'|]
            [|' ';'x';'o'|]
            [|' ';' ';'o'|]
        |] |> array2D
    Assert.Equal(true, isWinner initialValue board)

    let board : char[,] = 
        [|
            [|'x';'o';'x'|]
            [|' ';'x';'o'|]
            [|'x';' ';'o'|]
        |] |> array2D
    Assert.Equal(true, isWinner initialValue board)

// ---------------------------------
// isFull
// ---------------------------------

[<Fact>]
let ``Test of isFull function`` () =
    let initialValue : char = ' '
    let board : char[,] = 
        [|
            [|' ';' ';' '|]
            [|' ';' ';' '|]
            [|' ';' ';' '|]
        |] |> array2D
    Assert.Equal(false, isFull initialValue board)

    let board : char[,] = 
        [|
            [|'x';' ';' '|]
            [|' ';'x';' '|]
            [|' ';' ';'x'|]
        |] |> array2D
    Assert.Equal(false, isFull initialValue board)

    let board : char[,] = 
        [|
            [|'x';'x';'o'|]
            [|'o';'x';'x'|]
            [|'x';'o';'o'|]
        |] |> array2D
    Assert.Equal(true, isFull initialValue board)
    