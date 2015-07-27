#pragma once

#include "Player.h"
#include "BallType.h"

class Ball
{
public:
   Ball(BallType type, int runs = 0);

   BallType ballType;
   int runsScored;
};

