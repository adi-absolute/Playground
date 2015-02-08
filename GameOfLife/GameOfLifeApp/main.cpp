#include "Grid.h"

#include <iostream>

using namespace ::std;

#define ROWS 8
#define COLS 8

void PrintGrid(vector<vector<CellState>>& grid)
{
	for (int i = 0; i < ROWS; i++)
	{
		for (int j = 0; j < COLS; j++)
		{
			if (grid[i][j] == CellState::Alive)
				cout << "O";
			else
				cout << ".";
		}
		cout << endl;
	}
	cout << endl;
}

void main()
{
	Grid game(ROWS, COLS);
	bool exit = false;

	game.SetCellAlive(4, 4);
	game.SetCellAlive(5, 4);
	game.SetCellAlive(3, 4);

	vector<vector<CellState>>& grid = game.GetState();
	cout << "Starting State:" << endl;
	PrintGrid(grid);

	while (!exit)
	{
		cout << "Press n to select number of runs, x to exit: ";
		char x = '0';
		cin >> x;

		if (x == 'n')
		{
			cout << "Number of runs: ";
			int n;
			cin >> n;

			for (int i = 0; i < n; i++)
			{
				game.Run();
				PrintGrid(grid);
				_sleep(500);
			}
		}
		else if (x == 'x')
		{
			cout << "Exiting";
			exit = true;
		}
	}
}