#pragma once

#include <vector>

class MaxCombinedNumber
{
public:
	MaxCombinedNumber(const std::vector<int>& input);

   int MaxNumber();

private:
   struct sData
   {
      int pos;
      int value;
      int digits;
   };

   void Analyse(const std::vector<int>& input);
   std::vector<sData> PadVectorIntoPairs(const std::vector<int>& input);
   int MaxWithSameNumberOfDigits(int number);
   bool IsGreater(const sData& lhs, const sData& rhs);
   int NumberOfDigits(int number);

   int result;
   int maxOriginal;
};

