#include "MaxCombinedNumber.h"
#include "gtest/gtest.h"
#include <vector>

class TestMaxCombinedNumber : public ::testing::Test
{
};

/*
Write a function accepting a list of non negative integers, 
and returning their largest possible combined number
as a string. For example

given [50, 2, 1, 9] it returns "95021"    (9 + 50 + 2 + 1)
given [5, 50, 56]   it returns "56550"    (56 + 5 + 50)
given 420, 42, 423] it returns "42423420" (42 + 423 + 420)

Source [https://blog.svpino.com/about]
*/

TEST_F(TestMaxCombinedNumber, Zero_is_combined_number_for_empty_set)
{
   std::vector<int> input;
   MaxCombinedNumber combiner(input);

   ASSERT_EQ(0, combiner.MaxNumber());
}

TEST_F(TestMaxCombinedNumber, Single_number_input_returns_same_number)
{
   std::vector<int> input;
   input.push_back(4);

   MaxCombinedNumber combiner(input);

   ASSERT_EQ(4, combiner.MaxNumber());
}

TEST_F(TestMaxCombinedNumber, Two_indentical_numbers_in_input)
{
   std::vector<int> input = { 4, 4 };

   MaxCombinedNumber combiner(input);

   ASSERT_EQ(44, combiner.MaxNumber());
}

TEST_F(TestMaxCombinedNumber, Actual_array)
{
   std::vector<int> input = { 50, 2, 1, 9 };

   MaxCombinedNumber combiner(input);

   ASSERT_EQ(95021, combiner.MaxNumber());
}

TEST_F(TestMaxCombinedNumber, Input_with_one_number_ten_times_other)
{
   std::vector<int> input = { 50, 5 };

   MaxCombinedNumber combiner(input);

   ASSERT_EQ(550, combiner.MaxNumber());
}
