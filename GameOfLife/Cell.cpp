#include "Cell.h"


Cell::Cell(CellState startingState) :
   m_currentState(startingState),
   m_nextState(CellState::Dead)
{
}

void Cell::SetNextState(CellState state)
{
   m_nextState = state;
}

CellState Cell::GetCurrentState()
{
   return m_currentState;
}
