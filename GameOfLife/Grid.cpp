#include "Grid.h"

using namespace ::std;

Grid::Grid(int rows, int cols)
	: _noOfRows(rows), _noOfCols(cols)
{
	for (int i = 0; i < _noOfRows; i++)
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
			IncrementIfCellIsAlive(_grid[row - 1][col - 1], &noOfNeighbours);

		IncrementIfCellIsAlive(_grid[row - 1][col], &noOfNeighbours);

		if (col < (_noOfCols - 1))
			IncrementIfCellIsAlive(_grid[row - 1][col + 1], &noOfNeighbours);
	}

	if (col > 0)
		IncrementIfCellIsAlive(_grid[row][col - 1], &noOfNeighbours);

	if (col < (_noOfCols - 1))
		IncrementIfCellIsAlive(_grid[row][col + 1], &noOfNeighbours);

	if (row < (_noOfRows - 1))
	{
		if (col > 0)
			IncrementIfCellIsAlive(_grid[row + 1][col - 1], &noOfNeighbours);

		IncrementIfCellIsAlive(_grid[row + 1][col], &noOfNeighbours);

		if (col < (_noOfCols - 1))
			IncrementIfCellIsAlive(_grid[row + 1][col + 1], &noOfNeighbours);
	}

	return noOfNeighbours;
}

void Grid::Run()
{
	vector<vector<CellState>> newGrid;
	
	for (int i = 0; i < _noOfRows; i++)
	{
		vector<CellState> vec(_noOfCols);
		newGrid.push_back(vec);
	}

	for (int i = 0; i < _noOfRows; i++)
	{
		for (int j = 0; j < _noOfCols; j++)
		{
			switch (CalculateNeighbours(i, j))
			{
			case 2:
				newGrid[i][j] = _grid[i][j];
				break;

			case 3:
				newGrid[i][j] = CellState::Alive;
				break;

			default:
				newGrid[i][j] = CellState::Dead;
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