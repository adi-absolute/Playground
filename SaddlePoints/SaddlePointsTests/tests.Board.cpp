#include "gtest/gtest.h"
#include "Grid.h"

namespace CommonTests
{
	class TestSaddlePointLocator : public ::testing::Test
	{
	public:

		TestSaddlePointLocator()
		{
		}

		~TestSaddlePointLocator()
		{
		}		

		Grid grid;
	};

	TEST_F(TestSaddlePointLocator, Single_saddle_point_in_small_grid)
	{
		std::vector<std::vector<int>> data =
		{
			{ 6, 6, 6 },
			{ 1, 2, 3 },
			{ 6, 6, 6 }
		};

		std::string result = grid.FindSaddlePoints(data);

		ASSERT_EQ("Saddle Point at (1, 2)", result);
	}

	TEST_F(TestSaddlePointLocator, Single_saddle_point_in_large_grid)
	{
		std::vector<std::vector<int>> data =
		{
			{ 6, 6, 6, 1, 1, 1 },
			{ 6, 6, 6, 1, 1, 1 },
			{ 1, 2, 3, 1, 1, 1 },
			{ 6, 6, 6, 1, 1, 1 },
			{ 6, 6, 6, 1, 1, 1 },
			{ 6, 6, 6, 1, 1, 1 }
		};

		std::string result = grid.FindSaddlePoints(data);

		ASSERT_EQ("Saddle Point at (2, 2)", result);
	}

	TEST_F(TestSaddlePointLocator, Two_saddle_points_in_large_grid)
	{
		std::vector<std::vector<int>> data =
		{
			{ 6, 6, 6, 6, 6, 6 },
			{ 6, 6, 6, 6, 6, 6 },
			{ 3, 3, 5, 3, 3, 3 },
			{ 8, 8, 8, 8, 8, 8 },
			{ 3, 3, 5, 3, 3, 3 },
			{ 6, 6, 6, 6, 6, 6 },
		};

		std::string result = grid.FindSaddlePoints(data);

		ASSERT_EQ("Saddle Points at (2, 2), (4, 2)", result);
	}

	TEST_F(TestSaddlePointLocator, Two_saddle_points_in_the_same_line)
	{
		std::vector<std::vector<int>> data =
		{
			{ 6, 6, 6, 6, 6, 6 },
			{ 6, 6, 6, 6, 6, 6 },
			{ 3, 3, 5, 3, 5, 3 },
			{ 8, 8, 8, 8, 8, 8 },
			{ 6, 6, 6, 6, 6, 6 },
			{ 6, 6, 6, 6, 6, 6 },
		};

		std::string result = grid.FindSaddlePoints(data);

		ASSERT_EQ("Saddle Points at (2, 2), (2, 4)", result);
	}

	TEST_F(TestSaddlePointLocator, Two_saddle_points_in_asymmetrical_grid)
	{
		std::vector<std::vector<int>> data =
		{
			{ 6, 6, 6, 6, 6, 6 },
			{ 6, 6, 6, 6, 6, 6 },
			{ 3, 3, 5, 3, 5, 3 },
			{ 8, 8, 8, 8, 8, 8 },
			{ 6, 6, 6, 6, 6, 6 },
		};

		std::string result = grid.FindSaddlePoints(data);

		ASSERT_EQ("Saddle Points at (2, 2), (2, 4)", result);
	}

	TEST_F(TestSaddlePointLocator, Two_saddle_points_in_the_same_column)
	{
		std::vector<std::vector<int>> data =
		{
			{ 6, 6, 6, 6, 6, 6 },
			{ 6, 6, 6, 6, 6, 6 },
			{ 3, 3, 5, 3, 3, 3 },
			{ 8, 8, 8, 8, 8, 8 },
			{ 5, 5, 5, 5, 5, 5 },
		};

		std::string result = grid.FindSaddlePoints(data);

		ASSERT_EQ("Saddle Points at (2, 2), (4, 2)", result);
	}

	TEST_F(TestSaddlePointLocator, No_saddle_points_in_grid)
	{
		std::vector<std::vector<int>> data =
		{
			{ 1, 2, 3, 4 },
			{ 5, 6, 7, 3 },
			{ 5, 6, 7, 3 },
		};

		std::string result = grid.FindSaddlePoints(data);

		ASSERT_EQ("No Saddle Points in grid", result);
	}

}
