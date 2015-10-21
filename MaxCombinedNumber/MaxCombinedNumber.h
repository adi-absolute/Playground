#pragma once

#include <vector>

class MaxCombinedNumber
{
public:
   MaxCombinedNumber(const std::vector<int>& input);

   int MaxNumber();

private:
   void Analyse(const std::vector<int>& input);

   int result;
};

