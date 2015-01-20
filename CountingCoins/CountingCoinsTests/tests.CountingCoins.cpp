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
			{ 5, 0, 0, 0 },
			{ 0, 1, 0, 0 }
		};

		ASSERT_EQ(0, memcmp(&result, &expectedResult, sizeof(expectedResult)));
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

		ASSERT_EQ(0, memcmp(&result, &expectedResult, sizeof(expectedResult)));
	}

}
