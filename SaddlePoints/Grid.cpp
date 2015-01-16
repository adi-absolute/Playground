#include "Grid.h"
#include <algorithm>

using namespace ::std;

string Grid::FindSaddlePoints(vector<vector<int>> &data)
{
	vector<unsigned int> saddlePoints;

	_cols = data[0].size();
	_rows = data.size();

	for (unsigned int row = 0; row < _rows; row++)
	{
		for (unsigned int elementNo = 0; elementNo < data[row].size(); elementNo++)
		{
			if (IsSaddlePoint(elementNo, row, data))
			{
				saddlePoints.push_back(row);
				saddlePoints.push_back(elementNo);
			}
		}
	}

	return FormatOutput(saddlePoints);
}

bool Grid::IsSaddlePoint(unsigned int elementNo, unsigned int row, vector<vector<int>> &data)
{
	bool isSaddlePoint = false;

	if (IsHighestInRow(data[row][elementNo], data[row]))
	{
		vector<int> columnData;
		for (unsigned int i = 0; i < _rows; i++)
			columnData.push_back(data[i][elementNo]);

		if (IsLowestInCol(data[row][elementNo], columnData))
			isSaddlePoint = true;
	}

	return isSaddlePoint;
}

bool Grid::IsHighestInRow(int data, vector<int> rowData)
{
	return (data == *max_element(rowData.begin(), rowData.end()));
}

bool Grid::IsLowestInCol(int data, vector<int> colData)
{
	return (data == *min_element(colData.begin(), colData.end()));
}

string Grid::FormatOutput(vector<unsigned int> saddlePoints)
{
	if (saddlePoints.empty())
		return "No Saddle Points in grid";

	string result;
	if (saddlePoints.size() > SizeOfSaddlePoint)
		result = "Saddle Points at ";
	else
		result = "Saddle Point at ";

	unsigned int i = 0;
	while (i < saddlePoints.size())
	{
		if (i != 0)
			result += ", ";

		result += "(" + to_string(saddlePoints[i])
			+ ", " + to_string(saddlePoints[i + 1])
			+ ")";
		i += SizeOfSaddlePoint;
	}

	return result;
}