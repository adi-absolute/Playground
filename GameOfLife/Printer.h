#pragma once

#include "Board.h"

class Printer
{
public:
   Printer(Board &board);
   ~Printer();

   void Print();

private:
   Board &m_board;
};

