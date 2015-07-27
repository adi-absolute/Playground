#pragma once

#include "Ball.h"
#include <string>
#include <vector>

class Over
{
public:
	Over();
   Over(std::string bowlerName);

   void AddBall(Ball* ball);
   
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

