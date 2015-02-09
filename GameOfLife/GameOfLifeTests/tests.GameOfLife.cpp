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
		
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
			}
		}		
	}

	TEST_F(TestGameOfLife, SetCellAlive)
	{
		Grid grid(4, 4);

		grid.SetCellAlive(1, 2);

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if ((i == 1) && (j == 2))
					ASSERT_EQ(CellState::Alive, currentGrid[i][j]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
			}
		}
	}

	TEST_F(TestGameOfLife, SetCellAlive_InvalidCell)
	{
		Grid grid(4, 4);

		grid.SetCellAlive(1, 5);

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
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

		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
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

		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
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

		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (((i == 4) && (j==4))
					|| (i == 4) && (j == 5)
					|| (i == 5) && (j == 4)
					|| (i == 5) && (j == 5))
					ASSERT_EQ(CellState::Alive, currentGrid[i][j]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
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

		for (int i = 0; i < 8; i++)
		{
			for (int j = 0; j < 8; j++)
			{
				if (((i == 4) && (j == 4))
					|| (i == 4) && (j == 5)
					|| (i == 5) && (j == 3)
					|| (i == 6) && (j == 4)
					|| (i == 6) && (j == 5))
					ASSERT_EQ(CellState::Alive, currentGrid[i][j]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
			}
		}
	}

	TEST_F(TestGameOfLife, CellWithMoreThanFourNeighboursDies)
	{
		Grid grid(3, 3);

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				grid.SetCellAlive(i, j);
			}
		}

		grid.Run();

		vector<vector<CellState>>& currentGrid = grid.GetState();

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (((i == 0) && (j == 0))
					|| (i == 0) && (j == 2)
					|| (i == 2) && (j == 0)
					|| (i == 2) && (j == 2))
					ASSERT_EQ(CellState::Alive, currentGrid[i][j]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
			}
		}

		grid.Run();

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
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

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (((i == 1) && (j == 0))
					|| (i == 1) && (j == 1)
					|| (i == 1) && (j == 2))
					ASSERT_EQ(CellState::Alive, currentGrid[i][j]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
			}
		}

		grid.Run();

		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (((i == 0) && (j == 1))
					|| (i == 1) && (j == 1)
					|| (i == 2) && (j == 1))
					ASSERT_EQ(CellState::Alive, currentGrid[i][j]);
				else
					ASSERT_EQ(CellState::Dead, currentGrid[i][j]);
			}
		}
	}
}
