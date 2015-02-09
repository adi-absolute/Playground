#include "Grid.h"

using namespace ::std;

Grid::Grid(int rows, int cols)
	: _noOfRows(rows), _noOfCols(cols)
{
	for (int row = 0; row < _noOfRows; row++)
	{
		vector<CellState> vec(_noOfCols);
		_grid.push_back(vec);
	}
}

void Grid::IncrementIfCellIsAlive(CellState state, int* count)
{
	if (state == CellState::Alive)
		(*count)++;
}

int Grid::CalculateNeighbours(int row, int col)
{
	int noOfNeighbours = 0;

	if (row > 0)
	{
		if (col > 0)
			IncrementIfCellIsAlive(_grid[row - 1][col - 1], &noOfNeighbours);		// Above Left

		IncrementIfCellIsAlive(_grid[row - 1][col], &noOfNeighbours);				// Above

		if (col < (_noOfCols - 1))
			IncrementIfCellIsAlive(_grid[row - 1][col + 1], &noOfNeighbours);		// Above Right
	}

	if (col > 0)
		IncrementIfCellIsAlive(_grid[row][col - 1], &noOfNeighbours);				// Left

	if (col < (_noOfCols - 1))
		IncrementIfCellIsAlive(_grid[row][col + 1], &noOfNeighbours);				// Right

	if (row < (_noOfRows - 1))
	{
		if (col > 0)
			IncrementIfCellIsAlive(_grid[row + 1][col - 1], &noOfNeighbours);		// Below Left

		IncrementIfCellIsAlive(_grid[row + 1][col], &noOfNeighbours);				// Below

		if (col < (_noOfCols - 1))
			IncrementIfCellIsAlive(_grid[row + 1][col + 1], &noOfNeighbours);		// Below Right
	}

	return noOfNeighbours;
}

void Grid::Run()
{
	vector<vector<CellState>> newGrid;
	
	for (int row = 0; row < _noOfRows; row++)
	{
		vector<CellState> vec(_noOfCols);
		newGrid.push_back(vec);
	}

	for (int row = 0; row < _noOfRows; row++)
	{
		for (int col = 0; col < _noOfCols; col++)
		{
			switch (CalculateNeighbours(row, col))
			{
			case 2:
				newGrid[row][col] = _grid[row][col];		// Rule 2: http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life#Rules
				break;

			case 3:
				newGrid[row][col] = CellState::Alive;	// Rule 2 & 4
				break;

			default:
				newGrid[row][col] = CellState::Dead;	// Rule 1 & 3
				break;
			}
		}
	}

	newGrid.swap(_grid);
}

void Grid::SetCellAlive(int row, int col)
{
	if (row > _noOfRows || col > _noOfCols)
		return;

	_grid[row][col] = CellState::Alive;
}

vector<vector<CellState>>& Grid::GetState()
{
	return _grid;
}