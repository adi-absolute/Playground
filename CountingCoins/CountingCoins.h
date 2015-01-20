#pragma once

#include <vector>

enum class Denominations
{
	Penny,
	Nickel,
	Dime,
	Quarter,
	Dollar
};

std::vector<std::vector<unsigned int>> CountCoins(unsigned int valueInCents);

