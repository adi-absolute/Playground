#pragma once

#include <vector>

enum class Denominations
{
	Penny,
	Nickel,
	Dime,
	Quarter,
	NoOfCoins
};

std::vector<std::vector<unsigned int>> CountCoins(unsigned int valueInCents);

