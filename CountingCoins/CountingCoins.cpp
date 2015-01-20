#include "CountingCoins.h"

using namespace ::std;

static unsigned int CoinValues[] = { 1, 5, 10, 25 };

vector<vector<unsigned int>> CountCoins(unsigned int valueInCents)
{
	vector<vector<unsigned int>> result;
	unsigned int lastIndex = 0;
	bool end = false;
	unsigned int dropValueLoop = 500;
	unsigned int dropCoinValue = (unsigned int)Denominations::Dollar;
	unsigned int firstCoinValue = (unsigned int)Denominations::Dime;
	

	while (!end)
	{
		vector<unsigned int> thisRound(4);
		unsigned int amount = valueInCents;
		unsigned int loopNo = 0;
		
		unsigned int remainingAmount = valueInCents;
		unsigned int currentCoin = firstCoinValue;

		while (remainingAmount > 0)
		{		
			if (loopNo == dropValueLoop)
				currentCoin = dropCoinValue;

			if ((loopNo == 0) && (currentCoin == (unsigned int)Denominations::Penny))
				end = true;

			if (remainingAmount >= CoinValues[currentCoin])
			{
				if (loopNo == 0)
					firstCoinValue = currentCoin;

				remainingAmount -= CoinValues[currentCoin];
				thisRound[currentCoin]++;
				loopNo++;
			}
			else 
			{
				if (currentCoin > (unsigned int)Denominations::Penny)
					currentCoin--;
			}

			
		}

		if (currentCoin != (unsigned int)Denominations::Penny)
		{
			dropValueLoop = loopNo - 1;
			dropCoinValue = currentCoin - 1;
		}
		else
			dropValueLoop = loopNo - 6;
		
		result.push_back(thisRound);
	}

	return result;
}