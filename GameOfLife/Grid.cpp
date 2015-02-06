#include "Grid.h"

using namespace ::std;

Grid::Grid(int rows, int cols)
{
	for (int i = 0; i < rows; i++)
	{
		vector<CellState> vec(cols);
		_grid.push_back(vec);
	}
}

void Grid::Run()
{

}

void Grid::SetCellAlive(int row, int col)
{
	if (row > _grid.size() || col > _grid[0].size())
		return;

	_grid[row][col] = CellState::Alive;
}

vector<vector<CellState>>& Grid::GetState()
{
	return _grid;
}