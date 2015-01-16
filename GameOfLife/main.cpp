#include <iostream>
#include "Board.h"

using namespace std;

char startingBoard[10][10] =
{
   { 'A', '.', '.', '.', '.', '.', '.', '.', '.', 'B' },
   { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
   { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
   { '.', '.', '.', '.', '*', '.', '.', '.', '.', '.' },
   { '.', '.', '.', '.', '*', '.', '.', '.', '.', '.' },
   { '.', '.', '.', '.', '*', '.', '.', '.', '.', '.' },
   { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
   { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
   { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' },
   { 'C', '.', '.', '.', '.', '.', '.', '.', '.', 'D' }
};

void main()
{
   //Board board(100, 50);
   Board board2(10, 10, &startingBoard[0][0]);
      
   //board.PrintOutput();
   char x;
   do
   {
      board2.PrintOutput();

      cin >> x;
   } while (x != 'n');
}