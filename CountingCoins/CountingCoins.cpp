#include "CountingCoins.h"

using namespace ::std;

vector<vector<unsigned int>> CountCoins(unsigned int valueInCents)
{
	vector<vector<unsigned int>> result;
	unsigned int lastIndex = 0;
	bool end = false;
	

	while (!end)
	{
		vector<unsigned int> thisRound(4);
		unsigned int amount = valueInCents;
		unsigned int firstCoinValue = (unsigned int)Denominations::Dime;
		
		unsigned int remainingAmount = valueInCents;
		unsigned int currentCoinValue = (unsigned int)Denominations::Dime;

		while (remainingAmount > 0)
		{			
			if (remainingAmount >= currentCoinValue)
			{
				remainingAmount -= currentCoinValue;
				thisRound[currentCoinValue]++;
			}
			else if (currentCoinValue > (unsigned int)Denominations::Penny)
			{
				currentCoinValue--;
			}
		}

		result.push_back(thisRound);
	}

	return result;
}