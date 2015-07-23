#include "gtest/gtest.h"
#include "Over.h"

using namespace ::std;

namespace CommonTests
{
	class OverTests : public ::testing::Test
	{
	public:

		OverTests()
		{
		}

		~OverTests()
		{
		}

      Over over;
	};

	TEST_F(OverTests, DotBallBowled)
	{
      // Given
      // When
      over.BallBowled(BallType::Legal);

		ASSERT_EQ(1, over.LegalBallsBowled());
   }

   TEST_F(OverTests, MultipleDotBallsBowled)
   {
      // Given
      // When
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::Legal);

      ASSERT_EQ(3, over.LegalBallsBowled());
   }

   TEST_F(OverTests, NonLegalBallBowledDoesNotIncrementCount)
   {
      // Given
      // When
      over.BallBowled(BallType::NoBall);
      over.BallBowled(BallType::Wide);

      ASSERT_EQ(0, over.LegalBallsBowled());
   }

   TEST_F(OverTests, DefaultBowlerIsUnknown)
   {
      // Given
      // When
      // Then
      ASSERT_EQ("Unknown", over.BowlerName());
   }

   TEST_F(OverTests, SetBowlerName)
   {
      // Given
      string bowlerName = "Mitchell Johnson";
      // When
      Over overWithBowler(bowlerName);

      ASSERT_EQ(bowlerName, overWithBowler.BowlerName());
   }

   TEST_F(OverTests, LegalRuns)
   {
      // Given
      // When
      over.BallBowled(BallType::Legal, 1);
      over.BallBowled(BallType::Legal, 4);
      over.BallBowled(BallType::Legal, 2);

      ASSERT_EQ(7, over.RunsOffTheBat());
   }

   TEST_F(OverTests, RunsOffNonLegalBalls)
   {
      // Given
      // When
      over.BallBowled(BallType::Wide, 1);
      over.BallBowled(BallType::NoBall, 4);

      ASSERT_EQ(4, over.RunsOffTheBat());
   }

   TEST_F(OverTests, TotalRunsGiven)
   {
      // Given
      // When
      over.BallBowled(BallType::Legal, 1);
      over.BallBowled(BallType::LegBye, 4);

      ASSERT_EQ(5, over.TotalRunsGiven());
   }

   TEST_F(OverTests, RunsOffByes)
   {
      // Given
      // When
      over.BallBowled(BallType::Bye, 1);
      over.BallBowled(BallType::LegBye, 4);

      ASSERT_EQ(5, over.TotalRunsGiven());
   }

   TEST_F(OverTests, ByeRunsOffTheBat)
   {
      // Given
      // When
      over.BallBowled(BallType::Bye, 1);
      over.BallBowled(BallType::LegBye, 4);

      ASSERT_EQ(0, over.RunsOffTheBat());
   }

   TEST_F(OverTests, Extras)
   {
      // Given
      // When
      over.BallBowled(BallType::Bye, 1);
      over.BallBowled(BallType::LegBye, 4);

      ASSERT_EQ(5, over.TotalExtraRuns());
   }

   TEST_F(OverTests, IsCompletedOverMaiden)
   {
      // Given
      // When
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::LegBye, 4);
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::Bye, 2);

      ASSERT_TRUE(over.IsMaiden());
   }

   TEST_F(OverTests, IncompleteOverIsNotMaiden)
   {
      // Given
      // When
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::LegBye, 4);
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::Legal);
      over.BallBowled(BallType::Bye, 2);

      ASSERT_FALSE(over.IsMaiden());
   }
}
