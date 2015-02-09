#pragma once

#include <vector>

enum class CellState
{
	Dead,
	Alive
};

class Grid
{
public:
	Grid(int rows, int cols);

	void Run();
	void SetCellAlive(int row, int col);
	std::vector<std::vector<CellState>>& GetState();

private:
	void IncrementIfCellIsAlive(CellState state, int* count);
	int CalculateNeighbours(int row, int col);

	std::vector<std::vector<CellState>> _grid;
	int _noOfRows;
	int _noOfCols;
};

