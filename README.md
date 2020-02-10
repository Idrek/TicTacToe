# Project Title

The Tic-Tac-Toe console game in a 3x3 board for two human players.

## Getting Started

Download from Github and play one game:

```
$ git clone https://github.com/Idrek/TicTacToe && cd TicTacToe
$ dotnet run --project src/TicTacToe.fsproj
"-------
| | | |
-------
| | | |
-------
| | | |
-------"
Os turn:
Please select a row: 1
Please select a column: 1
"-------
| | | |
-------
| |O| |
-------
| | | |
-------"
Xs turn:
Please select a row: 1
Please select a column: 2
"-------
| | | |
-------
| |O|X|
-------
| | | |
-------"
Os turn:
Please select a row: 0
Please select a column: 0
"-------
|O| | |
-------
| |O|X|
-------
| | | |
-------"
Xs turn:
Please select a row: 0
Please select a column: 2
"-------
|O| |X|
-------
| |O|X|
-------
| | | |
-------"
Os turn:
Please select a row: 2
Please select a column: 2
"-------
|O| |X|
-------
| |O|X|
-------
| | |O|
-------"
O wins!
```

## Running the tests

```
$ git clone https://github.com/Idrek/TicTacToe && cd TicTacToe
$ dotnet test
Test Run Successful.
Total tests: 2
     Passed: 2
 Total time: 1.1540 Seconds
```
