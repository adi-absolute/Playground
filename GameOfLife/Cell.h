#pragma once

#include "CellState.h"

class Cell
{
public:
   Cell(CellState startingState);
   void SetNextState(CellState state);
   CellState GetCurrentState();

private:
   CellState m_currentState;
   CellState m_nextState;
};

