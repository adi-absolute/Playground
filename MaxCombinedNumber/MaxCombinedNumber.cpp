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

void MaxCombinedNumber::Analyse(const std::vector<int>& input)
{
   std::vector<int> sortableVector = input;

   std::sort(sortableVector.begin(), sortableVector.end(), [](const int& lhs, const int& rhs) 
   {
      std::string leftNumberFirst = std::to_string(lhs) + std::to_string(rhs);
      std::string rightNumberFirst = std::to_string(rhs) + std::to_string(lhs);
      
      return (std::stoi(leftNumberFirst) > std::stoi(rightNumberFirst));
   }
   );

   std::string numberString;
   for (size_t i = 0; i < sortableVector.size(); i++)
   {
      numberString += std::to_string(sortableVector[i]);
   }

   result = std::stoi(numberString);
}

int MaxCombinedNumber::MaxNumber()
{
   return result;
}