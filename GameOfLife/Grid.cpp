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

vector<vector<CellState>>& Grid::GetState()
{
	return _grid;
}