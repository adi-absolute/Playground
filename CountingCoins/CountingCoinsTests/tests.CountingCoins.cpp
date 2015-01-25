#include "gtest/gtest.h"
#include "CountingCoins.h"
#include <memory>

namespace CommonTests
{
	class TestCountingCoins : public ::testing::Test
	{
	public:

		TestCountingCoins()
		{
		}

		~TestCountingCoins()
		{
		}
	};

	TEST_F(TestCountingCoins, One_cent)
	{
		std::vector<std::vector<unsigned int>> result = CountCoins(1);
		
		ASSERT_EQ(1, result.size());
		ASSERT_EQ(1, result[0].at((int)Denominations::Penny));
	}

	TEST_F(TestCountingCoins, Five_cents)
	{
		std::vector<std::vector<unsigned int>> result = CountCoins(5);

		std::vector<std::vector<unsigned int>> expectedResult =
		{
			{ 0, 1, 0, 0 },
			{ 5, 0, 0, 0 }
		};

		ASSERT_EQ(result.size(), expectedResult.size());
		ASSERT_EQ(result[0], expectedResult[0]);
		ASSERT_EQ(result[1], expectedResult[1]);
	}

	TEST_F(TestCountingCoins, Ten_Cents)
	{
		std::vector<std::vector<unsigned int>> result = CountCoins(10);

		std::vector<std::vector<unsigned int>> expectedResult =
		{
			{ 0, 0, 1, 0 },
			{ 0, 2, 0, 0 },
			{ 5, 1, 0, 0 },
			{ 10, 0, 0, 0 },
		};

		ASSERT_EQ(result.size(), expectedResult.size());
		ASSERT_EQ(result[0], expectedResult[0]);
		ASSERT_EQ(result[1], expectedResult[1]);
		ASSERT_EQ(result[2], expectedResult[2]);
		ASSERT_EQ(result[3], expectedResult[3]);
	}

	TEST_F(TestCountingCoins, Eight_Cents)
	{
		std::vector<std::vector<unsigned int>> result = CountCoins(8);

		std::vector<std::vector<unsigned int>> expectedResult =
		{
			{ 3, 1, 0, 0 },
			{ 8, 0, 0, 0 },
		};

		ASSERT_EQ(result.size(), expectedResult.size());
		ASSERT_EQ(result[0], expectedResult[0]);
		ASSERT_EQ(result[1], expectedResult[1]);
	}

	TEST_F(TestCountingCoins, Eighteen_Cents)
	{
		std::vector<std::vector<unsigned int>> result = CountCoins(18);

		std::vector<std::vector<unsigned int>> expectedResult =
		{
			{ 3, 1, 1, 0 },
			{ 8, 0, 1, 0 },
			{ 3, 3, 0, 0 },
			{ 8, 2, 0, 0 },
			{ 13, 1, 0, 0 },
			{ 18, 0, 0, 0 },
		};

		ASSERT_EQ(result.size(), expectedResult.size());
		ASSERT_EQ(result[0], expectedResult[0]);
		ASSERT_EQ(result[5], expectedResult[5]);
	}

	TEST_F(TestCountingCoins, Dollar)
	{
		std::vector<std::vector<unsigned int>> result = CountCoins(100);
		
		ASSERT_EQ(242, result.size());
	}

}
