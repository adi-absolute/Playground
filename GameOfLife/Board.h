#pragma once
#include <vector>

class Board
{
public:
   Board(int rows, int columns, char* board);

   void PrintOutput() {}
   int get_Rows();
   int get_Columns();
   char* get_Board();

   void Run();

private:
   int m_rows;
   int m_columns;
   char *m_board;
};

