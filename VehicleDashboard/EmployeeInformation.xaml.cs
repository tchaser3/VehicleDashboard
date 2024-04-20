/* Title:           Employee Information
 * Date:            8-23-17
 * Author:          Terry Holmes */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NewEventLogDLL;
using NewEmployeeDLL;
using VehicleHistoryDLL;
using NewVehicleDLL;
using DateSearchDLL;
using InspectionsDLL;

namespace VehicleDashboard
{
    /// <summary>
    /// Interaction logic for EmployeeInformation.xaml
    /// </summary>
    public partial class EmployeeInformation : Window
    {
        //setting up the classes
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        DateSearchClass TheDataSearchClass = new DateSearchClass();
        InspectionsClass TheInspectionsClass = new InspectionsClass();

        //setting up the data
        FindEmployeeByEmployeeIDDataSet TheFindEmployeeByEmployeeIDDataSet = new FindEmployeeByEmployeeIDDataSet();
        FindVehicleHistoryByEmployeeIDAndDateRangeDataSet TheCurrentVehicleDataSet = new FindVehicleHistoryByEmployeeIDAndDateRangeDataSet();
        FindVehicleHistoryByEmployeeIDAndDateRangeDataSet TheFindVehicleHistoryByEmployeeIDDataSet = new FindVehicleHistoryByEmployeeIDAndDateRangeDataSet();
        FindDailyVehicleInspectionsByEmployeeIDAndDateRangeDataSet TheFindDailyVehicleInspectionByEmployeeIDDataSet = new FindDailyVehicleInspectionsByEmployeeIDAndDateRangeDataSet();
        FindDailyVehicleInspectionDateMatchDataSet TheFindDailyVehicleInspectionDateMatchDataSet = new FindDailyVehicleInspectionDateMatchDataSet();
        ReportedVehicleProblemsDataSet TheReportedVehicleProblemsDataSet = new ReportedVehicleProblemsDataSet();
        FindVehicleInspectionProblemsByInspectionIDDataSet TheFindVehicleInspectionProblemByIDDataSet = new FindVehicleInspectionProblemsByInspectionIDDataSet();

        //setting up variables
        string gstrErrorMessage;

        public EmployeeInformation()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool blnFatalError = false;

            PleaseWait PleaseWait = new PleaseWait();
            PleaseWait.Show();

            //work goes here
            blnFatalError = LoadEmployeeInformation();
            if (blnFatalError == false)
                blnFatalError = FindCurrentVehicle();
            if (blnFatalError == false)
                blnFatalError = LoadVehicleHistory();
            if (blnFatalError == false)
                blnFatalError = LoadDailyVehicleInspection();

            PleaseWait.Close();

            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(gstrErrorMessage);
            }
        }
        private bool LoadDailyVehicleInspection()
        {
            bool blnFatalError = false;
            DateTime datEndDate = DateTime.Now;
            DateTime datStartDate = DateTime.Now;
            int intCounter;
            int intNumberOfRecords;
            string strInspectionResults;
            DateTime datInspectionDate;
            int intInspectionID;

            try
            {
                datEndDate = TheDataSearchClass.RemoveTime(datEndDate);
                datEndDate = TheDataSearchClass.AddingDays(datEndDate, 1);
                datStartDate = TheDataSearchClass.SubtractingDays(datEndDate, 180);

                TheFindDailyVehicleInspectionByEmployeeIDDataSet = TheInspectionsClass.FindDailyVehicleInspectionByEmployeeIDAndDateRange(MainWindow.gintEmployeeID, datStartDate, datEndDate);

                intNumberOfRecords = TheFindDailyVehicleInspectionByEmployeeIDDataSet.FindDailyVehicleInspectionsByEmployeeIDAndDateRange.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    strInspectionResults = TheFindDailyVehicleInspectionByEmployeeIDDataSet.FindDailyVehicleInspectionsByEmployeeIDAndDateRange[intCounter].InspectionStatus;

                    if((strInspectionResults == "PASSED SERVICE REQUIRED") || (strInspectionResults == "FAILED"))
                    {
                        datInspectionDate = TheFindDailyVehicleInspectionByEmployeeIDDataSet.FindDailyVehicleInspectionsByEmployeeIDAndDateRange[intCounter].InspectionDate;

                        TheFindDailyVehicleInspectionDateMatchDataSet = TheInspectionsClass.FindDailyVehicleInspectionDateMatch(datInspectionDate);

                        intInspectionID = TheFindDailyVehicleInspectionDateMatchDataSet.FindDailyVehicleInspectionByDateMatch[0].TransactionID;

                        FindReportedProblem(intInspectionID, datInspectionDate);
                    }
                }

                dgrInspectionResults.ItemsSource = TheFindDailyVehicleInspectionByEmployeeIDDataSet.FindDailyVehicleInspectionsByEmployeeIDAndDateRange;

                dgrProblemReported.ItemsSource = TheReportedVehicleProblemsDataSet.problems;
            }
            catch(Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard \\ Employee Information \\ Load Daily Vehicle Inspection " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private void FindReportedProblem(int intInspectionID, DateTime datInspectionDate)
        {
            int intRecordsReturned;

            try
            {
                TheFindVehicleInspectionProblemByIDDataSet = TheInspectionsClass.FindVehicleInspectionProblemsbyInspectionID(intInspectionID);

                intRecordsReturned = TheFindVehicleInspectionProblemByIDDataSet.FindVehicleInspectionProblemsByInspectionID.Rows.Count;

                if(intRecordsReturned > 0)
                {

                    ReportedVehicleProblemsDataSet.problemsRow NewProblemRow = TheReportedVehicleProblemsDataSet.problems.NewproblemsRow();

                    NewProblemRow.TransactionDate = datInspectionDate;
                    NewProblemRow.BJCNumber = TheFindVehicleInspectionProblemByIDDataSet.FindVehicleInspectionProblemsByInspectionID[0].BJCNumber;
                    NewProblemRow.Problem = TheFindVehicleInspectionProblemByIDDataSet.FindVehicleInspectionProblemsByInspectionID[0].VehicleProblem;

                    TheReportedVehicleProblemsDataSet.problems.Rows.Add(NewProblemRow);
                }

            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle DashBoard // Employee Information // Find Reported Problem " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
        private bool LoadVehicleHistory()
        {
            bool blnFatalError = false;
            DateTime datStartDate = DateTime.Now;
            DateTime datEndDate = DateTime.Now;
           
            try
            {

                datEndDate = TheDataSearchClass.RemoveTime(datEndDate);
                datEndDate = TheDataSearchClass.AddingDays(datEndDate, 1);
                datStartDate = TheDataSearchClass.SubtractingDays(datEndDate, 180);

                TheFindVehicleHistoryByEmployeeIDDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(MainWindow.gintEmployeeID, datStartDate, datEndDate);

                dgrVehicleHistory.ItemsSource = TheFindVehicleHistoryByEmployeeIDDataSet.FindVehicleHistoryByEmployeeIDAndDateRange;
                
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard \\ Employee Information \\ Load Vehicle History " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool FindCurrentVehicle()
        {
            bool blnFatalError = false;
            DateTime datStartDate = DateTime.Now;
            DateTime datEndDate = DateTime.Now;
            int intRecordsReturned;
            string strBJCNumber;

            try
            {
                datStartDate = TheDataSearchClass.RemoveTime(datStartDate);
                datEndDate = TheDataSearchClass.AddingDays(datStartDate, 1);

                TheCurrentVehicleDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(MainWindow.gintEmployeeID, datStartDate, datEndDate);

                intRecordsReturned = TheCurrentVehicleDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                if(intRecordsReturned == 0)
                {
                    strBJCNumber = "No Vehicle Signed Out";
                }
                else
                {
                    strBJCNumber = Convert.ToString(TheCurrentVehicleDataSet.FindVehicleHistoryByEmployeeIDAndDateRange[0].BJCNumber);
                }

                txtCurrentBJCNumber.Text = strBJCNumber;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard \\ Employee Information \\ Find Current Vehicle " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private bool LoadEmployeeInformation()
        {
            bool blnFatalError = false;

            try
            {
                TheFindEmployeeByEmployeeIDDataSet = TheEmployeeClass.FindEmployeeByEmployeeID(MainWindow.gintEmployeeID);

                txtFirstName.Text = TheFindEmployeeByEmployeeIDDataSet.FindEmployeeByEmployeeID[0].FirstName;
                txtLastName.Text = TheFindEmployeeByEmployeeIDDataSet.FindEmployeeByEmployeeID[0].LastName;
                txtPhoneNumber.Text = TheFindEmployeeByEmployeeIDDataSet.FindEmployeeByEmployeeID[0].PhoneNumber;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Employee Information // Load Employee Information " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }

            return blnFatalError;
        }
    }
}
