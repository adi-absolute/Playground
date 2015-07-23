#pragma once

#include "BallType.h"
#include <string>

class Over
{
public:
	Over();
   Over(std::string bowlerName);

   void BallBowled(BallType ballType, int runsScored = 0);
   
   int LegalBallsBowled();
   int RunsOffTheBat();
   int TotalRunsGiven();
   int TotalExtraRuns();
   bool IsMaiden();
   std::string BowlerName();

private:
   int m_legalBalls;
   int m_runsOffTheBat;
   int m_extraRuns;
   std::string m_bowlerName;
};

