/* Title:           Display Vehicle Information
 * Date:            7-20-17
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
using VehicleProblemsDLL;
using VehiclesInShopDLL;
using InspectionsDLL;
using WeeklyInspectionsDLL;
using NewEventLogDLL;
using NewEmployeeDLL;
using VehicleAssignmentDLL;
using DateSearchDLL;
using VehicleHistoryDLL;
using KeyWordDLL;

namespace VehicleDashboard
{
    /// <summary>
    /// Interaction logic for DisplayVehicleInformation.xaml
    /// </summary>
    public partial class DisplayVehicleInformation : Window
    {
        //setting up the classes
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        VehicleProblemClass TheVehicleProblemClass = new VehicleProblemClass();
        VehiclesInShopClass TheVehiclesInShopClass = new VehiclesInShopClass();
        InspectionsClass TheInspectionClass = new InspectionsClass();
        WeeklyInspectionClass TheWeeklyInspectionsClass = new WeeklyInspectionClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        VehicleAssignmentClass TheVehicleAssignmentClass = new VehicleAssignmentClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();

        FindCurrentAssignedVehicleByVehicleIDDataSet TheFindCurrentAssignedVehicleByVehicleIDDataSet = new FindCurrentAssignedVehicleByVehicleIDDataSet();
        FindDailyVehicleInspectionByVehicleIDAndDateRangeDataSet TheLastWeeksDailyInspectionsDataSet = new FindDailyVehicleInspectionByVehicleIDAndDateRangeDataSet();
        FindVehicleHistoryByVehicleIDAndDateRangeDataSet TheFindVehicleHistoryByVehicleIDAndDateRangeDateSet = new FindVehicleHistoryByVehicleIDAndDateRangeDataSet();
        FindVehicleProblemUpdateByVehicleIDDataSet TheFindVehicleproblemUpdateByVehicleIDDataSet = new FindVehicleProblemUpdateByVehicleIDDataSet();
        OpenProblemsDataSet TheOpenProblemsDataSet = new OpenProblemsDataSet();
        FindOpenVehicleProblemsByVehicleIDDataSet TheFindOpenVehicleProblemsByVehicleIDDataSet = new FindOpenVehicleProblemsByVehicleIDDataSet();

        int gintUpdateCounter;
        int gintUpdateNumberOfRecords;

        //setting global variables
        string gstrErrorMessage;

        public DisplayVehicleInformation()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool blnFatalError = false;

            try
            {
                MainWindow.gintVehicleID = MainWindow.TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[MainWindow.gintSelectedIndex].VehicleID;

                blnFatalError = CurrentVehicleAssignment(MainWindow.gintVehicleID);
                if (blnFatalError == false)
                    blnFatalError = FindLastSevenDaysInspection(MainWindow.gintVehicleID);
                if (blnFatalError == false)
                    blnFatalError = ShowVehicleProblems(MainWindow.gintVehicleID);
                if (blnFatalError == false)
                    blnFatalError = LoadVehicleHistory(MainWindow.gintVehicleID);

                if(blnFatalError == true)
                {
                    TheMessagesClass.ErrorMessage(gstrErrorMessage);
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Display Vehicle Information // Window Loaded " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
        private bool LoadVehicleHistory(int intVehicleID)
        {
            bool blnFatalError = false;
            DateTime datStartDate;
            DateTime datEndDate;
           

            try
            {
                datStartDate = TheDateSearchClass.RemoveTime(DateTime.Now);
                datEndDate = TheDateSearchClass.AddingDays(datStartDate, 1);
                datStartDate = TheDateSearchClass.SubtractingDays(datStartDate, 180);

                TheFindVehicleHistoryByVehicleIDAndDateRangeDateSet = TheVehicleHistoryClass.FindVehicleHistoryByVehicleIDAndDateRange(intVehicleID, datStartDate, datEndDate);

                dgrVehicleHistory.ItemsSource = TheFindVehicleHistoryByVehicleIDAndDateRangeDateSet.FindVehicleHistoryByVehicleIDAndDateRange;

            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Display Vehicle Information // Load Vehicle History " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = false;
            }


            return blnFatalError;
        }
        private bool ShowVehicleProblems(int intVehicleID)
        {
            bool blnFatalError = false;
            DateTime datStartDate;
            DateTime datEndDate;
            int intCounter;
            int intNumberOfRecords;
            int intUpdateCounter;
            bool blnItemFound = false;
            bool blnKeyWorkNotFound = true;
            string strProblemUpdate;
            string strVendor = "";
            int intRecordsReturned;
            int intStatusLength;

            try
            {
                TheOpenProblemsDataSet.problems.Rows.Clear();

                datStartDate = TheDateSearchClass.RemoveTime(DateTime.Now);
                datEndDate = TheDateSearchClass.AddingDays(datStartDate, 1);
                datStartDate = TheDateSearchClass.SubtractingDays(datStartDate, 180);

                TheFindOpenVehicleProblemsByVehicleIDDataSet = TheVehicleProblemClass.FindOpenVehicleProblemsbyVehicleID(MainWindow.gintVehicleID);

                intRecordsReturned = TheFindOpenVehicleProblemsByVehicleIDDataSet.FindOpenVehicleProblemsByVehicleID.Rows.Count;

                if(intRecordsReturned > 0)
                {
                    strVendor = TheFindOpenVehicleProblemsByVehicleIDDataSet.FindOpenVehicleProblemsByVehicleID[0].VendorName;
                    txtVendor.Text = strVendor;
                }
                else
                {
                    txtVendor.Visibility = Visibility.Hidden;
                }

                dgrVehicleProblems.ItemsSource = TheFindOpenVehicleProblemsByVehicleIDDataSet.FindOpenVehicleProblemsByVehicleID;
                
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Display Vehicle Information // Show Vehicle Problems " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                TheMessagesClass.ErrorMessage(gstrErrorMessage);

                blnFatalError = false;
            }

            return blnFatalError;
        }
        private bool FindLastSevenDaysInspection(int intVehicleID)
        {
            bool blnFatalError = false;
            DateTime datStartDate;
            DateTime datEndDate;

            try
            {
                datStartDate = TheDateSearchClass.RemoveTime(DateTime.Now);
                datEndDate = TheDateSearchClass.AddingDays(datStartDate, 1);
                datStartDate = TheDateSearchClass.SubtractingDays(datStartDate, 7);

                TheLastWeeksDailyInspectionsDataSet = TheInspectionClass.FindDailyVehicleInspectionByVehicleIDAndDateRange(intVehicleID, datStartDate, datEndDate);

                dgrDailyInspectionResults.ItemsSource = TheLastWeeksDailyInspectionsDataSet.FindDailyVehicleInspectionsByVehicleIDAndDateRange;
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Display Vehicle Information // Find Last Seven Days Inspection " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = false;
            }

            return blnFatalError;
        }
       
        private bool CurrentVehicleAssignment(int intVehicleID)
        {
            bool blnFatalError = false;
            int intRecordsReturned;

            try
            {
                TheFindCurrentAssignedVehicleByVehicleIDDataSet = TheVehicleAssignmentClass.FindCurrentAssignedVehicleByVehicleID(intVehicleID);

                intRecordsReturned = TheFindCurrentAssignedVehicleByVehicleIDDataSet.FindCurrentAssignedVehicleByVehicleID.Rows.Count;

                if(intRecordsReturned == 0)
                {
                    txtAssignmentFirstName.Text = "NOT ASSIGNED";
                    txtAssignmentLastName.Text = "NOT ASSIGNED";
                }
                else
                {
                    txtAssignmentFirstName.Text = TheFindCurrentAssignedVehicleByVehicleIDDataSet.FindCurrentAssignedVehicleByVehicleID[0].FirstName;
                    txtAssignmentLastName.Text = TheFindCurrentAssignedVehicleByVehicleIDDataSet.FindCurrentAssignedVehicleByVehicleID[0].LastName;
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle DashBoard // Display Vehicle Information // Current Vehicle Assignment " + Ex.Message);

                gstrErrorMessage = Ex.ToString();

                blnFatalError = true;
            }


            return blnFatalError;
        }

        private void dgrDailyInspectionResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //setting up the local variables
            string strInspectionStatus;
            int intInspectionID;
            DataGrid dataGrid;
            DataGridRow Row;
            DataGridCell InspectionID;
            DataGridCell InspectionStatus;
            int intSelectedIndex;

            try
            {
                intSelectedIndex = dgrDailyInspectionResults.SelectedIndex;

                if(intSelectedIndex > -1)
                {
                    dataGrid = dgrDailyInspectionResults;
                    Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                    InspectionID = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
                    InspectionStatus = (DataGridCell)dataGrid.Columns[5].GetCellContent(Row).Parent;
                    intInspectionID = Convert.ToInt32(((TextBlock)InspectionID.Content).Text);
                    strInspectionStatus = ((TextBlock)InspectionStatus.Content).Text;
                    
                    if (strInspectionStatus != "PASSED")
                    {
                        MainWindow.gintInspectionID = intInspectionID;

                        ShowDailyInspectionNotes ShowDailyInspectionNotes = new ShowDailyInspectionNotes();
                        ShowDailyInspectionNotes.ShowDialog();
                    }
                    else
                    {
                        TheMessagesClass.InformationMessage("The Inspection Passed with no Entries");
                    }
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Display Vehicle Information // Daily Inspection Grid Selection " + Ex.Message);

                TheMessagesClass.InformationMessage(Ex.ToString());
            }
        }

        private void dgrVehicleProblems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //setting up the local variables
            int intSelectedIndex;
            DataGrid OpenOrderGrid;
            DataGridRow OpenOrderRow;
            DataGridCell ProblemID;
            string strProblemID;

            try
            {
                intSelectedIndex = dgrVehicleProblems.SelectedIndex;

                if (intSelectedIndex > -1)
                {
                    OpenOrderGrid = dgrVehicleProblems;
                    OpenOrderRow = (DataGridRow)OpenOrderGrid.ItemContainerGenerator.ContainerFromIndex(OpenOrderGrid.SelectedIndex);
                    ProblemID = (DataGridCell)OpenOrderGrid.Columns[0].GetCellContent(OpenOrderRow).Parent;
                    strProblemID = ((TextBlock)ProblemID.Content).Text;

                    MainWindow.gintProblemID = Convert.ToInt32(strProblemID);

                    ShowVehicleProblemsNotes ShowVehicleProblemsNotes = new ShowVehicleProblemsNotes();
                    ShowVehicleProblemsNotes.ShowDialog();
                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Display Vehicle Information // Daily Inspection Grid Selection " + Ex.Message);

                TheMessagesClass.InformationMessage(Ex.ToString());
            }
        }
    }
}
