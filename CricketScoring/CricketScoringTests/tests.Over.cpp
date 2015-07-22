#include "gtest/gtest.h"

namespace CommonTests
{
	class TestTemplate : public ::testing::Test
	{
	public:

		TestTemplate()
		{
		}

		~TestTemplate()
		{
		}
	};

	TEST_F(TestTemplate, First)
	{
		ASSERT_FALSE(true);
	}

}
