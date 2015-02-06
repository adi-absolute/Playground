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
}
