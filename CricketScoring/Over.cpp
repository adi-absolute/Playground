#include "Over.h"

using namespace ::std;

Over::Over() :
m_legalBalls(0), m_runsOffTheBat(0), m_bowlerName("Unknown"), m_extraRuns(0)
{
}

Over::Over(string bowlerName) :
m_legalBalls(0), m_runsOffTheBat(0), m_bowlerName(bowlerName), m_extraRuns(0)
{
}

void Over::AddBall(Ball* ball)
{
   BallType ballType = ball->ballType;
   int runsScored = ball->runsScored;

   switch (ballType)
   {
   case BallType::NoBall:
      m_runsOffTheBat += runsScored;
      m_extraRuns++;
      break;

   case BallType::Wide:
      m_extraRuns += (runsScored + 1);
      break;

   case BallType::Bye:
   case BallType::LegBye:
      m_legalBalls++;
      m_extraRuns += runsScored;
      break;

   default:
      m_legalBalls++;
      m_runsOffTheBat += runsScored;
      break;
   }   
}

int Over::LegalBallsBowled()
{
   return m_legalBalls;
}

int Over::RunsOffTheBat()
{
   return m_runsOffTheBat;
}

int Over::TotalRunsGiven()
{
   return (m_runsOffTheBat + m_extraRuns);
}

int Over::TotalExtraRuns()
{
   return m_extraRuns;
}

bool Over::IsMaiden()
{
   return ((m_legalBalls == 6) && (m_runsOffTheBat == 0));
}

string Over::BowlerName()
{
   return m_bowlerName;
}
