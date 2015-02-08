#include "Grid.h"

#include <iostream>

using namespace ::std;

void PrintGrid(vector<vector<CellState>>& grid)
{
	for (int i = 0; i < grid.size(); i++)
	{
		for (int j = 0; j < grid[0].size(); j++)
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
	bool exit = false;

	int w;
	cout << "Enter width/height of grid: ";
	cin >> w;

	Grid *game = new Grid(w, w);

	vector<vector<CellState>>& grid = game->GetState();
	cout << "Starting State:" << endl;
	PrintGrid(grid);

	while (!exit)
	{
		cout << "Press s to set a cell alive, n to select number of runs, x to exit: ";
		char x = '0';
		cin >> x;

		if (x == 'n')
		{
			cout << "Number of runs: ";
			int n;
			cin >> n;

			for (int i = 0; i < n; i++)
			{
				game->Run();
				PrintGrid(grid);
				_sleep(500);
			}
		}
		else if (x == 's')
		{
			cout << "X & Y position of live cell: ";
			int r, c;
			cin >> r >> c;
			game->SetCellAlive(r, c);
			cout << "New State:" << endl;
			PrintGrid(grid);
		}
		else if (x == 'x')
		{
			cout << "Exiting";
			exit = true;
		}
	}
}