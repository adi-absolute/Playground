#include "gtest/gtest.h"

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

	TEST_F(TestGameOfLife, First)
	{
		ASSERT_FALSE(true);
	}

}
