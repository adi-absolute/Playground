using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;

namespace TSW
{
    class Program
    {
        static void Delay(Window window, int ms = 500)
        {
            window.WaitWhileBusy();
            System.Threading.Thread.Sleep(ms);
        }

        static void Main(string[] args)
        {
            TestStack.White.Application app = TestStack.White.Application.Launch("C:/Windows/system32/calc.exe");
            Window window = app.GetWindow(SearchCriteria.ByText("Calculator"), TestStack.White.Factory.InitializeOption.WithCache);
            window.WaitWhileBusy();
            
            var cName = window.Get<TestStack.White.UIItems.RadioButton>(SearchCriteria.ByText("Grads"));
            cName.Click();
            Delay(window);

            var c1 = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByText("1"));
            c1.Click();
            Delay(window);
                        
            var cplus = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByText("Add"));
            cplus.Click();
            Delay(window);

            var c2 = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByText("2"));
            c2.Click(); 
            Delay(window);

            var ceq = window.Get<TestStack.White.UIItems.Button>("Equals");
            ceq.Click();
            Delay(window);

            /*
            //inputs the Client into the Client dropdown
            var cName = window.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByAutomationId("cbClient"));
            cName.Click();
            window.WaitWhileBusy();
            cName.Select(dt1.Rows[i][client].ToString());
            window.WaitWhileBusy();

            //inputs the Query into the Query dropdown
            var cQuery = window.Get<TestStack.White.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByAutomationId("cbQueryfile"));
            cQuery.Click();
            window.WaitWhileBusy();
            cQuery.Select(dt1.Rows[i][query].ToString());
            window.WaitWhileBusy();

            //checks the suppress error checkbox
            var sError = window.Get<TestStack.White.UIItems.CheckBox>(SearchCriteria.ByAutomationId("cb_Suppress"));
            window.WaitWhileBusy();
            sError.Checked = true;
            window.WaitWhileBusy();

            //inputs the start date
            var sDate = window.Get<TestStack.White.UIItems.DateTimePicker>(SearchCriteria.ByAutomationId("datePicker1"));
            var st = Convert.ToDateTime(dt1.Rows[i][start]);
            window.WaitWhileBusy();
            sDate.SetDate(st, DateFormat.monthDayYear);
            window.WaitWhileBusy();

            //inputs the end date
            var eDate = window.Get<TestStack.White.UIItems.DateTimePicker>(SearchCriteria.ByAutomationId("datePicker2"));
            var et = Convert.ToDateTime(dt1.Rows[i][end]);
            window.WaitWhileBusy();
            eDate.SetDate(et, DateFormat.monthDayYear);
            window.WaitWhileBusy();

            //clicks the Run button
            var rQuery = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnRun"));
            window.WaitWhileBusy();
            rQuery.Click();
            window.WaitWhileBusy();

            var label = window.Get<TestStack.White.UIItems.Label>(SearchCriteria.ByAutomationId("label2"));
            do
            {
                Thread.Sleep(5000);
            } while (label.Text == "Running Query...");


            //clicks the Retrieve button
            var Retrieve = window.Get<TestStack.White.UIItems.Button>(SearchCriteria.ByAutomationId("btnRetrieve"));
            window.WaitWhileBusy();
            Retrieve.Click();
            window.WaitWhileBusy();

            var pBar = window.Get<TestStack.White.UIItems.ProgressBar>(SearchCriteria.ByAutomationId("progressBar1"));
            do
            {
                Thread.Sleep(5000);
            } while (pBar.Value != pBar.Maximum);

            dataGridViewCAMList[colStatus, i].Value = complete;
            UpdateLog(i, dataGridViewCAMList);

            currentCount++;
            i++;
*/
            while (!window.IsClosed)
            {
            }

            app.Close();
            app.Dispose();


        }
    }
}
