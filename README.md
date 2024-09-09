
# Game of Fifteen

This project is a classic game of Fifteen, implemented in the C# programming language. The player moves tiles on the playing field with the goal of collecting them in ascending order, starting from 1 and ending with an empty tile.


## Game Rules

The game board consists of tiles, each of which is numbered.
The tiles are arranged in random order, one cell is left empty.
The goal of the game is to arrange all tiles in ascending order, starting from 1. The empty tile must end up in the bottom right corner.
On even-numbered boards (e.g., 4x4 or 6x6), the game adjusts the order of tiles by swapping 1 and 2 to guarantee solvability.

## Functionality

- Drawing the board: the current board configuration is displayed in the console.
- Moving tiles: the player can select a tile to move in place of an empty square.
- Win check: the game checks if the player has won by placing all tiles in order.
- Support for different board sizes: minimum board size is 3x3, maximum board size is 9x9.
- Board initialization: the game automatically adjusts the playing field depending on the size, and also swaps tiles 1 and 2 on even-numbered boards (4x4, 6x6, etc.).


## Installation

Clone the repository to your local machine:
```bash
  git clone https://github.com/Jorge-S13/Fifteen.git
```
Navigate to the project folder:
```bash
  cd Fifteen
```
Build the project and run it through the command line:
```bash
  dotnet run <board size>
```
Example launch for a 4x4 board:
```bash
  dotnet run 4
```
## How to play

- After starting the program, the console will display the current state of the board.
- Enter the number of the tile you want to move to the empty cell.
- The game will check if the move is possible, and if the move is possible, move the tile.
- Continue moving tiles until you have them in ascending order.
- When all tiles are in place, the game will congratulate you on your victory.

## Technologies
- Programming Language: C#
- Platform: .NET 8