#ifndef GRID_INCLUDED
#define GRID_INCLUDED

#include <string>
#include <vector>


class Grid
{
public:
	const unsigned int SizeOfSaddlePoint = 2;

	std::string FindSaddlePoints(int* data);
	std::string FindSaddlePoints(std::vector<std::vector<int>> &data);

private:
	bool IsHighestInRow(int data, std::vector<int> rowData);
	bool IsLowestInCol(int data, std::vector<int> colData);
	bool IsSaddlePoint(unsigned int elementNo, unsigned int row, std::vector<std::vector<int>> &data);
	std::string FormatOutput(std::vector<unsigned int> saddlePoints);

	unsigned int _rows;
	unsigned int _cols;
};

#endif
