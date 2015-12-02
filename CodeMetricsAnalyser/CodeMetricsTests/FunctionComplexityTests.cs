using System;
using CodeMetricsAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestsForCodeMetricsAnalyser
{
    [TestClass]
    public class FunctionComplexityTests
    {
        List<Token> secondPassList; // Function Range is a Shallow Copy
        FunctionComplexityCalculator calculator;

        private List<List<Token>> GenerateFunctionRangeFromString(string input)
        {
            return Generate.FunctionListFromString(input, out secondPassList);
        }

        [TestMethod]
        public void Maximum_cyclomatic_complexity_of_empty_token_list()
        {
            var functionRangeVector = GenerateFunctionRangeFromString("");
            calculator = new FunctionComplexityCalculator(functionRangeVector);

            Assert.AreEqual(0, calculator.MaxComplexity);
        }

        [TestMethod]
        public void Max_complexity_without_functions()
        {
            string ss = @"(#include ""test.h""

        int a = 10; // some comments
        string n = ""blah"";
        /*more comments*/
        ";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator(functionRangeVector);

            Assert.AreEqual(0, calculator.MaxComplexity);
        }

        [TestMethod]
        public void Max_complexity_with_single_empty_function()
        {
            string ss = @"(#include ""test.h""

        void f() { }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(1, calculator.MaxComplexity);
        }

        [TestMethod]
        public void Max_complexity_with_an_if_statement()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) { } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.MaxComplexity);
        }

        [TestMethod]
        public void Max_complexity_with_a_for_statement()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            for (x = 0; x < 10; x++) 
                blah(); 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_if_else_statement()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) { } 
            else { }
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_two_AND_condition_if_statement()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x && y) { } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(3, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_two_OR_condition_if_statement()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x || y) { } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(3, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_one_function_and_two_if_statements()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) { } 
            if(x) { } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(3, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_a_while_statement()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            while(x) { } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_switch_case_statement()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            switch(x) { case 1:break; default:break; } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_switch_and_multiple_case_statements()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            switch(x) 
            { 
                case 1:break; 
                case 2:break; 
                case 3:break; 
                default:break; 
            } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(4, calculator.MaxComplexity);
        }

        [TestMethod]
        public void Max_complexity_with_switch_and_multiple_case_statements_and_no_default()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            switch(x) 
            { 
                case 1:break; 
                case 2:break; 
                case 3:break; 
            } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(4, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_nested_if_statements()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) {if (y) { } } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(3, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_multiple_functions_with_if_statements()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) { } 
        }
        void g() 
        { 
            if(y) { } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Max_complexity_with_multiple_functions_with_different_complexities()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) { } 
        }
        void g() 
        { 
   
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.MaxComplexity);
        }
        
        [TestMethod]
        public void Avg_complexity_with_multiple_functions_with_if_statements()
        {
   

            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) { } 
        }
        void g() 
        { 
            if(y) { } 
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(2, calculator.AvgComplexity);
        }
        
        [TestMethod]
        public void Avg_complexity_with_multiple_functions_with_different_complexities()
        {
            string ss = @"(#include ""test.h""

        void f() 
        { 
            if(x) { } 
        }
        void g() 
        { 
   
        }";

            var functionRangeVector = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionComplexityCalculator (functionRangeVector);

            Assert.AreEqual(1.5m, calculator.AvgComplexity);
        }
    }
}
