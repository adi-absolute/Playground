#include "CountingCoins.h"

#define DO_NOT_DROP -1

using namespace ::std;

static unsigned int CoinValue[static_cast<unsigned int>(Denominations::NoOfCoins)] = { 1, 5, 10, 25 };

vector<vector<unsigned int>> CountCoins(unsigned int valueInCents)
{
	vector<vector<unsigned int>> result;
	bool end = false;
	int dropCoinValueLoopNo = DO_NOT_DROP;
	unsigned int dropCoinValue = static_cast<unsigned int>(Denominations::NoOfCoins);
	unsigned int workingCoin = static_cast<unsigned int>(Denominations::NoOfCoins);
	vector <unsigned int> record;

	while (!end)
	{
		vector<unsigned int> thisRound(static_cast<unsigned int>(Denominations::NoOfCoins));
		int loopNo = 0;
		
		unsigned int remainingAmount = valueInCents;
		unsigned int currentCoin = static_cast<unsigned int>(Denominations::Quarter);
		bool recordSwapped = false;

		while (remainingAmount > 0)
		{				
			if (!recordSwapped)
			{
				vector <unsigned int> newRecord;
				while (loopNo < dropCoinValueLoopNo)
				{
					unsigned int coin = record[loopNo];
					
					thisRound[coin]++;
					newRecord.push_back(coin);
					remainingAmount -= CoinValue[coin];
					workingCoin = coin;
					loopNo++;
				}

				newRecord.swap(record);
				recordSwapped = true;
			}

			if (loopNo == dropCoinValueLoopNo)
				currentCoin = dropCoinValue;

			if ((loopNo == 0) && (currentCoin == static_cast<unsigned int>(Denominations::Penny)))
				end = true;

			if (remainingAmount >= CoinValue[currentCoin])
			{
				if (currentCoin > static_cast<unsigned int>(Denominations::Penny))
					workingCoin = currentCoin;

				record.push_back(currentCoin);
				remainingAmount -= CoinValue[currentCoin];
				thisRound[currentCoin]++;
				loopNo++;
			}
			else 
			{
				if (currentCoin > static_cast<unsigned int>(Denominations::Penny))
					currentCoin--;
			}
		}

		if (currentCoin != static_cast<unsigned int>(Denominations::Penny))
		{
			dropCoinValueLoopNo = loopNo - 1;
			dropCoinValue = currentCoin - 1;
		}
		else
		{
			dropCoinValue = workingCoin - 1;
			dropCoinValueLoopNo = loopNo - thisRound[static_cast<unsigned int>(Denominations::Penny)] - 1;
		}
		
		result.push_back(thisRound);
	}

	return result;
}