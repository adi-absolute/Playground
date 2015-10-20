#include "MaxCombinedNumber.h"
#include <string>
#include <algorithm>
#include <math.h>

MaxCombinedNumber::MaxCombinedNumber(const std::vector<int>& input) :
result(0)
{
   if (!input.empty())
      Analyse(input);
}

bool MaxCombinedNumber::IsGreater(const MaxCombinedNumber::sData& lhs, const MaxCombinedNumber::sData& rhs)
{
   return lhs.value > rhs.value;
}

void MaxCombinedNumber::Analyse(const std::vector<int>& input)
{
   // Find the largest number and its size
   maxOriginal = *std::max_element(input.begin(), input.end());

   // Pad to length for each entry to size of largest number
   auto paddedPairs = PadVectorIntoPairs(input);

   // Sort in descending order
   std::sort(paddedPairs.begin(), paddedPairs.end(), [](const sData& lhs, const sData& rhs) 
   {
      if (lhs.value == rhs.value)
         return lhs.digits < rhs.digits;
      else
         return lhs.value > rhs.value; 
   }
   );

   std::string numberString;
   // string together original list in new order
   for (size_t i = 0; i < paddedPairs.size(); i++)
   {
      numberString += std::to_string(input[paddedPairs[i].pos]);
   }

   result = std::stoi(numberString);
}

int MaxCombinedNumber::NumberOfDigits(int number)
{
   int digits = 1;
   
   while (number / 10 > 0)
   {
      number /= 10;
      digits++;
   }

   return digits;
}

int MaxCombinedNumber::MaxWithSameNumberOfDigits(int number)
{
   return static_cast<int>(pow(10, NumberOfDigits(number)) - 1);
}

std::vector<MaxCombinedNumber::sData> MaxCombinedNumber::PadVectorIntoPairs(const std::vector<int>& input)
{
   std::vector<sData> paddedVector;

   int max = MaxWithSameNumberOfDigits(maxOriginal);

   for (size_t i = 0; i < input.size(); i++)
   {
      sData s;
      s.pos = i;
      s.digits = NumberOfDigits(input[i]);

      int numberToPad = input[i];
      while (numberToPad * 10 <= max)
      {
         numberToPad *= 10;
      }

      s.value = numberToPad;
      paddedVector.push_back(s);
   }

   return paddedVector;
}

int MaxCombinedNumber::MaxNumber()
{
   return result;
}