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

	TEST_F(OverTests, DotAddBall)
	{
      // Given
      Ball ball(BallType::Legal);

      // When
      over.AddBall(&ball);

		ASSERT_EQ(1, over.LegalBallsBowled());
   }

   
   TEST_F(OverTests, MultipleDotBallsBowled)
   {
      // Given
      Ball ball(BallType::Legal);

      // When
      over.AddBall(&ball);
      over.AddBall(&ball);
      over.AddBall(&ball);

      ASSERT_EQ(3, over.LegalBallsBowled());
   }
   
   TEST_F(OverTests, NonLegalAddBallDoesNotIncrementCount)
   {
      // Given
      // When
      Ball ball1(BallType::Wide);
      Ball ball2(BallType::NoBall);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

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
      Ball ball1(BallType::Legal, 3);
      Ball ball2(BallType::Legal, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

      ASSERT_EQ(7, over.RunsOffTheBat());
   }

   TEST_F(OverTests, RunsOffNonLegalBalls)
   {
      // Given
      Ball ball1(BallType::Wide, 3);
      Ball ball2(BallType::NoBall, 1);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

      ASSERT_EQ(1, over.RunsOffTheBat());
   }

   TEST_F(OverTests, TotalRunsGiven)
   {
      // Given
      Ball ball1(BallType::Legal, 1);
      Ball ball2(BallType::Bye, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

      ASSERT_EQ(5, over.TotalRunsGiven());
   }

   TEST_F(OverTests, RunsOffByes)
   {
      // Given
      Ball ball1(BallType::LegBye, 1);
      Ball ball2(BallType::Bye, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

      ASSERT_EQ(5, over.TotalRunsGiven());
   }

   TEST_F(OverTests, ByeRunsOffTheBat)
   {
      // Given
      Ball ball1(BallType::LegBye, 1);
      Ball ball2(BallType::Bye, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

      ASSERT_EQ(0, over.RunsOffTheBat());
   }

   TEST_F(OverTests, ExtrasWithByes)
   {
      // Given
      Ball ball1(BallType::Legal, 1);
      Ball ball2(BallType::Bye, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

      ASSERT_EQ(4, over.TotalExtraRuns());
   }

   TEST_F(OverTests, ExtrasWithWides)
   {
      // Given
      Ball ball1(BallType::Legal, 4);
      Ball ball2(BallType::Wide, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);

      ASSERT_EQ(5, over.TotalExtraRuns());
   }

   TEST_F(OverTests, IsCompletedOverMaiden)
   {
      // Given
      Ball ball1(BallType::Legal);
      Ball ball2(BallType::Bye, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);
      over.AddBall(&ball1);
      over.AddBall(&ball1);
      over.AddBall(&ball1);
      over.AddBall(&ball1);

      ASSERT_TRUE(over.IsMaiden());
   }

   TEST_F(OverTests, IncompleteOverIsNotMaiden)
   {
      // Given
      Ball ball1(BallType::Legal);
      Ball ball2(BallType::Bye, 4);

      // When
      over.AddBall(&ball1);
      over.AddBall(&ball2);
      over.AddBall(&ball1);
      over.AddBall(&ball1);
      over.AddBall(&ball1);

      ASSERT_FALSE(over.IsMaiden());
   }
}
