#include "CountingCoins.h"

#define DO_NOT_DROP -1

using namespace ::std;

static unsigned int CoinValue[] = { 1, 5, 10, 25 };

vector<vector<unsigned int>> CountCoins(unsigned int valueInCents)
{
	vector<vector<unsigned int>> result;
	bool end = false;
	int dropValueLoop = DO_NOT_DROP;
	unsigned int dropCoinValue = (unsigned int)Denominations::Dollar;
	unsigned int firstCoin = (unsigned int)Denominations::Quarter;
	unsigned int workingCoin = (unsigned int)Denominations::Dollar;
	vector <unsigned int> record;

	while (!end)
	{
		vector<unsigned int> thisRound(4);
		int loopNo = 0;
		
		unsigned int remainingAmount = valueInCents;
		unsigned int currentCoin = firstCoin;
		bool recordSwapped = false;

		while (remainingAmount > 0)
		{				
			if (!recordSwapped)
			{
				vector <unsigned int> temp;
				while ((loopNo < dropValueLoop) && (dropValueLoop != DO_NOT_DROP))
				{
					unsigned int coin = record[loopNo];
					thisRound[coin]++;
					temp.push_back(coin);
					remainingAmount -= CoinValue[coin];
					workingCoin = coin;
					loopNo++;
				}

				temp.swap(record);
				recordSwapped = true;
			}

			if (loopNo == dropValueLoop)
				currentCoin = dropCoinValue;

			if ((loopNo == 0) && (currentCoin == (unsigned int)Denominations::Penny))
				end = true;

			if (remainingAmount >= CoinValue[currentCoin])
			{
				if (loopNo == 0)
					firstCoin = currentCoin;

				if (currentCoin > (unsigned int)Denominations::Penny)
					workingCoin = currentCoin;

				record.push_back(currentCoin);
				remainingAmount -= CoinValue[currentCoin];
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
		{
			dropCoinValue = workingCoin - 1;
			dropValueLoop = loopNo - thisRound[(unsigned int)Denominations::Penny] - 1;
		}
		
		result.push_back(thisRound);
	}

	return result;
}