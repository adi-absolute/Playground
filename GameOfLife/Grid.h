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

	std::vector<std::vector<CellState>>& GetState();

private:
	std::vector<std::vector<CellState>> _grid;
};

