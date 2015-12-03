using System;
using CodeMetricsAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestsForCodeMetricsAnalyser
{
    [TestClass]
    public class FunctionDepthTests
    {
        List<Token> secondPassList; // Function Range is a Shallow Copy
        FunctionDepthCalculator calculator;

        private List<List<Token>> GenerateFunctionRangeFromString(string input)
        {
            return Generate.FunctionListFromString(input, out secondPassList);
        }

        [TestMethod]
        public void Max_depth_of_empty_token_list()
        {
            calculator = new FunctionDepthCalculator(new List<List<Token>>());
   
            Assert.AreEqual(0, calculator.MaxDepth);
        }
        
        [TestMethod]
        public void Max_depth_of_file_without_functions()
        {
            string ss = @"(#include ""test.h""

        int a = 10; // some comments
        string n = ""blah"";
        /*more comments*/
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(0, calculator.MaxDepth);
        }

        [TestMethod]
        public void Max_depth_of_file_with_single_empty_function()
        {
            string ss = @"#include ""test.h""

        void f() { })";
   
            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(1, calculator.MaxDepth);
        }

        [TestMethod]
        public void Max_depth_of_file_with_nested_braces_in_single_function()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        {
            if(true)
            {
                break;
            }
        })";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }


        [TestMethod]
        public void Max_depth_of_file_with_nested_braces_in_single_function_2()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        {
            if(true)
            {
                break;
            }
        })";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }
    
        [TestMethod]
        public void Multiple_simple_functions_in_file()
        {
            string ss = @"
        #include ""test.h""

        void f() { }
        void g() { }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(1, calculator.MaxDepth);
        }

        [TestMethod]
        public void One_function_has_more_depth_than_other()
        {
            string ss = @"
        #include ""test.h""

        void f() { if (true) { break; } }
        void g() { }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }
        
        [TestMethod]
        public void Ignore_braces_in_strings()
        {
            string ss = @"
        #include ""test.h""

        void f() { string s = ""{""; }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(1, calculator.MaxDepth);
        }
    
        [TestMethod]
        public void Max_depth_with_unbraced_if_statement()
        {
            string ss = @"
        #include ""test.h""

        void f() { if (true) break; }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }

        [TestMethod]
        public void Max_depth_with_two_nested_if_statements()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        { 
            if (true) 
                if (true)
                {
                    break; 
                }
        }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(3, calculator.MaxDepth);
        }
        
        [TestMethod]
        public void Max_depth_with_two_successive_if_statements_without_braces()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        { 
            if (x) 
                blah();
            if (y) 
                blah2();
        }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }
    
        [TestMethod]
        public void Max_depth_with_if_else_statements()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        { 
            if (true) 
                break;
            else
                continue;
        }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }

        [TestMethod]
        public void Max_depth_with_if_without_brace_and_else_with_brace()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        { 
            if (true) 
                break;
            else
            {
                continue;
            }
        }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }
        
        [TestMethod]
        public void Max_depth_with_if_without_brace_and_elseif_with_brace()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        { 
            if (true) 
                break;
            else if (x)
            {
                continue;
            }
        }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }
    
        [TestMethod]
        public void Max_depth_with_if_without_brace_and_complex_else()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        { 
            if (true) 
                break;
            else if (x)
            {
                if (true)
                {
                    continue;
                }
            }
        }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(3, calculator.MaxDepth);
        }

        [TestMethod]
        public void Max_depth_of_file_with_While_statement_in_single_function()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        {
            while (true) break; 
        })";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }
        
        [TestMethod]
        public void Max_depth_of_file_with_For_loop_in_single_function()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        {
            for (;;) break; 
        })";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }
    
        [TestMethod]
        public void Max_depth_of_file_with_DoWhile_loop_in_single_function()
        {   
            string ss = @"
        #include ""test.h""

        void f() 
        {
            do break; while (1);
        })";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(2, calculator.MaxDepth);
        }

        [TestMethod]
        public void Complex_condition_after_unbraced_condition()
        {
            string ss = @"
        #include ""test.h""

        void f() 
        { 
            if (true) 
                while (a)
                {
                    blah();
                }
   
            if (true) 
                while (a)
                {
                    blah();
                }
        }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(3, calculator.MaxDepth);
        }
        
        [TestMethod]
        public void Average_Depth_with_Multiple_simple_functions_in_file()
        {
            string ss = @"
        #include ""test.h""

        void f() { }
        void g() { }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(1, calculator.AvgDepth);
        }
    
        [TestMethod]
        public void Average_depth_with_one_function_having_more_depth_than_other()
        {
            string ss = @"
        #include ""test.h""

        void f() { if (true) { break; } }
        void g() { }
        )";

            var functionRangeSet = GenerateFunctionRangeFromString(ss);
            calculator = new FunctionDepthCalculator(functionRangeSet);

            Assert.AreEqual(1.5m, calculator.AvgDepth);
        }
    }
}
