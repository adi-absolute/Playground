using System;
using CodeMetricsAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace TestsForCodeMetricsAnalyser
{
    [TestClass]
    public class FunctionLengthTests
    {
        FunctionLengthCalculator calculator;

        public FunctionLengthTests()
        {
        }

        [TestMethod]
        public void Maximum_function_length_of_empty_token_list()
        {
            calculator = new FunctionLengthCalculator(new List<Token>());
            Assert.AreEqual(0, calculator.MaxLength);
        }

        [TestMethod]
        public void Maximum_function_length_without_functions()
        {
            string ss = @"#include ""test.h""

        int a = 10; // some comments
        string n = ""blah"";
        /*more comments*/
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(0, calculator.MaxLength);
        }

        [TestMethod]
        public void Max_length_of_empty_function()
        {
           string ss = @"#include ""test.h""

        void f() {  }
        )";

           var lexedOutput = Generate.SecondPassListFromString(ss);
           calculator = new FunctionLengthCalculator(lexedOutput);

           Assert.AreEqual(0, calculator.MaxLength);
        }

        [TestMethod]
        public void Max_length_of_single_line_function()
        {
            string ss = @"#include ""test.h""

        void f() { blah(); }
        )";

           var lexedOutput = Generate.SecondPassListFromString(ss);
           calculator = new FunctionLengthCalculator(lexedOutput);

           Assert.AreEqual(1, calculator.MaxLength);
        }

        [TestMethod]
        public void Max_length_with_statements_on_different_lines()
        {
            string ss = @"#include ""test.h""

        void f() { blah();
        blah2(); }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(2, calculator.MaxLength);
        }

        [TestMethod]
        public void Max_length_with_two_functions_in_file()
        {
            string ss = @"#include ""test.h""

        void f() { blah();
        blah2(); }

        void g() 
        { 
            blah3();
        }

        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(2, calculator.MaxLength);
        }

        [TestMethod]
        public void Max_length_with_nested_braces()
        {
            string ss = @"#include ""test.h""

        void f() 
        { 
            if (x) 
            { 
                blah(); 
            } 

            blah2();
        }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(6, calculator.MaxLength);
        }

        [TestMethod]
        public void Ignore_curly_braces_not_start_of_function()
        {
            string ss = @"#include ""test.h""

        int someArray[] = { 1, 2, 3 };
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(0, calculator.MaxLength);
        }

        [TestMethod]
        public void Const_at_end_of_definition()
        {
            string ss = @"#include ""test.h""

        void f() const
        { 
            blah2();
        }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(1, calculator.MaxLength);
        }
        
        [TestMethod]
        public void Forward_declaration_does_not_mislead_calculations()
        {
            string ss = @"#include ""test.h""

        void f()  const;
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(0, calculator.MaxLength);
        }
    
        [TestMethod]
        public void Avg_length_with_two_functions_in_file()
        {
            string ss = @"#include ""test.h""

        void f() { blah();
        blah2(); }

        void g() 
        { 
            blah3();
        }

        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(1.5m, calculator.AverageLength);
        }

        [TestMethod]
        public void Max_length_with_namespaced_function()
        {
            string ss = @"#include ""test.h""

        namespace n 
        {
            void f() 
            { 
                blah();
            }
        }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(1, calculator.MaxLength);
        }

        [TestMethod]
        public void Max_length_with_double_namespaced_function()
        {
            string ss = @"#include ""test.h""
        namespace N1
        {
            namespace N2 
            {
                void f() 
                { 
                    blah();
                }
            }
        }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(1, calculator.MaxLength);
        }
        
        [TestMethod]
        public void Max_length_with_function_defined_in_class_definition()
        {
            string ss = @"#include ""test.h""

        class C 
        {
        public:
            void f() 
            { 
                blah();
            }
        }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(1, calculator.MaxLength);
        }
    
        [TestMethod]
        public void using_namespace_directive_in_file()
        {
            string ss = @"#include ""test.h""

        using namespace n;

        void f() 
        { 
            blah();
        }

        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(1, calculator.MaxLength);
        }
        
        [TestMethod]
        public void Number_Of_Functions_with_two_functions_in_file()
        {
   

            string ss = @"#include ""test.h""

        void f() {  }

        void g() 
        { 
   
        }

        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            calculator = new FunctionLengthCalculator(lexedOutput);

            Assert.AreEqual(2, calculator.NumberOfFunctions);
        }

        private List<Token> CreateFunctionRange(List<Token> input, 
            string first, string last,
            int start, out int end)
        {
            var index1 = input.FindIndex(start, t => t.Text == first);
            var index2 = input.FindIndex(index1, t => t.Text == last);
            end = index2;
            
            return input.GetRange(index1, (index2 - index1));
        }

        [TestMethod]
        public void Save_function_tokens()
        {   
            string ss = @"
        #include ""test.h""

        void f() { blah(); }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);

            int endSearch;
            var functionTokens = CreateFunctionRange(lexedOutput, "{", "}", 0, out endSearch);
            var expFunctionRangeSet = new List<List<Token>>();
            expFunctionRangeSet.Add(functionTokens);

            calculator = new FunctionLengthCalculator(lexedOutput);

            var actualRangeSet = calculator.FunctionRangeSet();

            Assert.AreEqual(1, actualRangeSet.Count);
            Assert.AreEqual(expFunctionRangeSet[0][0].Text, actualRangeSet[0][0].Text);

        }

        [TestMethod]
        public void Save_tokens_from_multiple_functions()
        {
   
            string ss = @"
        #include ""test.h""

        void f() { blah(); }
        void g() { blah2(); }
        )";

            var lexedOutput = Generate.SecondPassListFromString(ss);
            
            var expFunctionRangeSet = new List<List<Token>>();

            int endSearch;
            var functionTokens = CreateFunctionRange(lexedOutput, "{", "}", 0, out endSearch);
            expFunctionRangeSet.Add(functionTokens);
            functionTokens = CreateFunctionRange(lexedOutput, "{", "}", endSearch, out endSearch);
            expFunctionRangeSet.Add(functionTokens);

            calculator = new FunctionLengthCalculator(lexedOutput);

            var actualRangeSet = calculator.FunctionRangeSet();

            Assert.AreEqual(2, actualRangeSet.Count);
            
            Assert.AreEqual(expFunctionRangeSet[0][0].Text, actualRangeSet[0][0].Text);
            Assert.AreEqual(expFunctionRangeSet[1][0].Text, actualRangeSet[1][0].Text);
        }
    }
}
