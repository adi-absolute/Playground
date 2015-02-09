#include "gtest/gtest.h"

#include "Grid.h"

using namespace ::std;

namespace CommonTests
{
	class TestGameOfLife : public ::testing::Test
	{
	public:

		TestGameOfLife()
		{
		}

		~TestGameOfLife()
		{
		}
	};

	TEST_F(TestGameOfLife, EmptyGrid)
	{
		Grid grid(4, 4);

		vector<vector<CellState>>& currentGrid = grid.GetState();
		
		for (int row = 0; row < 4; row++)
		{
			for (int col = 0; col < 4; col++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}		
	}

	TEST_F(TestGameOfLife, SetCellAlive)
	{
		Grid grid(4, 4);

		grid.SetCellAlive(1, 2);

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 4; row++)
		{
			for (int col = 0; col < 4; col++)
			{
				if ((row == 1) && (col == 2))
					ASSERT_EQ(CellState::Alive, currentGrid[row][col]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}

	TEST_F(TestGameOfLife, SetCellAlive_InvalidCell)
	{
		Grid grid(4, 4);

		grid.SetCellAlive(1, 5);

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 4; row++)
		{
			for (int col = 0; col < 4; col++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}

	TEST_F(TestGameOfLife, LoneCellsDieOnRun)
	{
		Grid grid(8, 8);

		grid.SetCellAlive(1, 0);
		grid.SetCellAlive(0, 4);
		grid.SetCellAlive(5, 7);
		grid.SetCellAlive(7, 3);

		grid.Run();

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}

	TEST_F(TestGameOfLife, TwoCellGroupsDieOnRun)
	{
		Grid grid(8, 8);

		grid.SetCellAlive(1, 0);
		grid.SetCellAlive(1, 1);
		grid.SetCellAlive(4, 4);
		grid.SetCellAlive(5, 5);

		grid.Run();

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}

	TEST_F(TestGameOfLife, ThreeCellGroupsBecomeFourCellGroup)
	{
		Grid grid(8, 8);

		grid.SetCellAlive(4, 4);
		grid.SetCellAlive(5, 4);
		grid.SetCellAlive(5, 5);

		grid.Run();

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				if (((row == 4) && (col==4))
					|| (row == 4) && (col == 5)
					|| (row == 5) && (col == 4)
					|| (row == 5) && (col == 5))
					ASSERT_EQ(CellState::Alive, currentGrid[row][col]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}
	
	TEST_F(TestGameOfLife, CellWithFourNeighboursDies)
	{
		Grid grid(8, 8);

		/*
		.**		.**
		.**	=>	*..
		.*.		.**
		*/

		grid.SetCellAlive(4, 4);
		grid.SetCellAlive(4, 5);
		grid.SetCellAlive(5, 4);
		grid.SetCellAlive(5, 5);
		grid.SetCellAlive(6, 4);

		grid.Run();

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				if (((row == 4) && (col == 4))
					|| (row == 4) && (col == 5)
					|| (row == 5) && (col == 3)
					|| (row == 6) && (col == 4)
					|| (row == 6) && (col == 5))
					ASSERT_EQ(CellState::Alive, currentGrid[row][col]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}

	TEST_F(TestGameOfLife, CellWithMoreThanFourNeighboursDies)
	{
		Grid grid(3, 3);

		for (int row = 0; row < 3; row++)
		{
			for (int col = 0; col < 3; col++)
			{
				grid.SetCellAlive(row, col);
			}
		}

		grid.Run();

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 3; row++)
		{
			for (int col = 0; col < 3; col++)
			{
				if (((row == 0) && (col == 0))
					|| (row == 0) && (col == 2)
					|| (row == 2) && (col == 0)
					|| (row == 2) && (col == 2))
					ASSERT_EQ(CellState::Alive, currentGrid[row][col]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}

		grid.Run();

		for (int row = 0; row < 3; row++)
		{
			for (int col = 0; col < 3; col++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}
	
	TEST_F(TestGameOfLife, Oscillator)
	{
		Grid grid(3, 3);

		grid.SetCellAlive(0, 1);
		grid.SetCellAlive(1, 1);
		grid.SetCellAlive(2, 1);

		grid.Run();

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int row = 0; row < 3; row++)
		{
			for (int col = 0; col < 3; col++)
			{
				if (((row == 1) && (col == 0))
					|| (row == 1) && (col == 1)
					|| (row == 1) && (col == 2))
					ASSERT_EQ(CellState::Alive, currentGrid[row][col]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}

		grid.Run();

		for (int row = 0; row < 3; row++)
		{
			for (int col = 0; col < 3; col++)
			{
				if (((row == 0) && (col == 1))
					|| (row == 1) && (col == 1)
					|| (row == 2) && (col == 1))
					ASSERT_EQ(CellState::Alive, currentGrid[row][col]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[row][col]);
			}
		}
	}
}
