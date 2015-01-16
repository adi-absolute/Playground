#include "Board.h"
#include <iostream>

using namespace std;

Board::Board(int rows, int columns, char* board) :
   m_rows(rows),
   m_columns(columns),
   m_board(board)
{
}

int Board::get_Rows()
{
   return m_rows;
}

int Board::get_Columns()
{
   return m_columns;
}

char* Board::get_Board()
{
   return m_board;
}

void Board::Run()
{

}

//void Board::PrintOutput()
//{
//   for (int i = 0; i < m_rows; i++)
//   {
//      for (int j = 0; j < m_columns; j++)
//      {
//         cout << m_board[i*10 + j];
//      }
//      cout << endl;
//   }
//}
