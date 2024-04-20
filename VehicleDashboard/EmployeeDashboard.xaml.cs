/* Title:           Employee Dashboard
 * Date:            8-22-17
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
using NewEmployeeDLL;
using NewEventLogDLL;
using VehicleHistoryDLL;
using NewVehicleDLL;
using DateSearchDLL;
using System.Windows.Threading;
using System.Reflection;

namespace VehicleDashboard
{
    /// <summary>
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        //setting classes
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        VehicleHistoryClass TheVehicleHistoryClass = new VehicleHistoryClass();
        VehicleClass TheVehicleClass = new VehicleClass();
        DateSearchClass TheDateSearchClass = new DateSearchClass();

        FindActiveEmployeesDataSet TheFindActiveEmployeesDataSet = new FindActiveEmployeesDataSet();
        FindVehicleHistoryByEmployeeIDAndDateRangeDataSet TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = new FindVehicleHistoryByEmployeeIDAndDateRangeDataSet();

        int gintStartingCounter;
        int gintEmployeeNumberOfRecords;
        int gintNumberOfButtons = 36;

        Button Buttons = new Button();

        int[] gintEmployeeID = new int[36];

        //setting up the time
        DispatcherTimer MyTimer = new DispatcherTimer();

        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            TheMessagesClass.CloseTheProgram();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HideControls();

            try
            {
                gintStartingCounter = 0;

                TheFindActiveEmployeesDataSet = TheEmployeeClass.FindActiveEmployees();

                gintEmployeeNumberOfRecords = TheFindActiveEmployeesDataSet.FindActiveEmployees.Rows.Count - 1;

                LoadControls();

                MyTimer.Tick += new EventHandler(BeginTheProcess);
                MyTimer.Interval = new TimeSpan(0, 0, 20);
                MyTimer.Start();
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Employee Dashboard " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
        private void BeginTheProcess(object sender, EventArgs e)
        {
            LoadControls();
        }
        private void LoadControls()
        {
            //setting local variables
            DateTime datStartDate;
            DateTime datEndDate;
            int intRecordsReturned;

            int intButtonCounter;

            try
            {
                HideControls();
                datStartDate = TheDateSearchClass.RemoveTime(DateTime.Now);
                datEndDate = TheDateSearchClass.AddingDays(datStartDate, 1);

                for(intButtonCounter = 1; intButtonCounter <= gintNumberOfButtons; intButtonCounter++)
                {
                    if(intButtonCounter == 1)
                    {
                        btnEmployee1.Visibility = Visibility.Visible;
                        tblEmployee1.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if(intRecordsReturned == 0)
                        {
                            btnEmployee1.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee1.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 2)
                    {
                        btnEmployee2.Visibility = Visibility.Visible;
                        tblEmployee2.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee2.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee2.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 3)
                    {
                        btnEmployee3.Visibility = Visibility.Visible;
                        tblEmployee3.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee3.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee3.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 4)
                    {
                        btnEmployee4.Visibility = Visibility.Visible;
                        tblEmployee4.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee4.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee4.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 5)
                    {
                        btnEmployee5.Visibility = Visibility.Visible;
                        tblEmployee5.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee5.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee5.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 6)
                    {
                        btnEmployee6.Visibility = Visibility.Visible;
                        tblEmployee6.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee6.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee6.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 7)
                    {
                        btnEmployee7.Visibility = Visibility.Visible;
                        tblEmployee7.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee7.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee7.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 8)
                    {
                        btnEmployee8.Visibility = Visibility.Visible;
                        tblEmployee8.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee8.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee8.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 9)
                    {
                        btnEmployee9.Visibility = Visibility.Visible;
                        tblEmployee9.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee9.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee9.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 10)
                    {
                        btnEmployee10.Visibility = Visibility.Visible;
                        tblEmployee10.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee10.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee10.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 11)
                    {
                        btnEmployee11.Visibility = Visibility.Visible;
                        tblEmployee11.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee11.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee11.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 12)
                    {
                        btnEmployee12.Visibility = Visibility.Visible;
                        tblEmployee12.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee12.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee12.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 13)
                    {
                        btnEmployee13.Visibility = Visibility.Visible;
                        tblEmployee13.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee13.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee13.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 14)
                    {
                        btnEmployee14.Visibility = Visibility.Visible;
                        tblEmployee14.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee14.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee14.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 15)
                    {
                        btnEmployee15.Visibility = Visibility.Visible;
                        tblEmployee15.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee15.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee15.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 16)
                    {
                        btnEmployee16.Visibility = Visibility.Visible;
                        tblEmployee16.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee16.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee16.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 17)
                    {
                        btnEmployee17.Visibility = Visibility.Visible;
                        tblEmployee17.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee17.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee17.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 18)
                    {
                        btnEmployee18.Visibility = Visibility.Visible;
                        tblEmployee18.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;
                            
                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee18.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee18.Background = Brushes.Blue;
                        }


                    }
                    if (intButtonCounter == 19)
                    {
                        btnEmployee19.Visibility = Visibility.Visible;
                        tblEmployee19.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee19.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee19.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 20)
                    {
                        btnEmployee20.Visibility = Visibility.Visible;
                        tblEmployee20.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee20.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee20.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 21)
                    {
                        btnEmployee21.Visibility = Visibility.Visible;
                        tblEmployee21.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee21.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee21.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 22)
                    {
                        btnEmployee22.Visibility = Visibility.Visible;
                        tblEmployee22.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee22.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee22.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 23)
                    {
                        btnEmployee23.Visibility = Visibility.Visible;
                        tblEmployee23.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee23.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee23.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 24)
                    {
                        btnEmployee24.Visibility = Visibility.Visible;
                        tblEmployee24.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee24.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee24.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 25)
                    {
                        btnEmployee25.Visibility = Visibility.Visible;
                        tblEmployee25.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee25.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee25.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 26)
                    {
                        btnEmployee26.Visibility = Visibility.Visible;
                        tblEmployee26.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee26.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee26.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 27)
                    {
                        btnEmployee27.Visibility = Visibility.Visible;
                        tblEmployee27.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee27.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee27.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 28)
                    {
                        btnEmployee28.Visibility = Visibility.Visible;
                        tblEmployee28.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee28.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee28.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 29)
                    {
                        btnEmployee29.Visibility = Visibility.Visible;
                        tblEmployee29.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee29.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee29.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 30)
                    {
                        btnEmployee30.Visibility = Visibility.Visible;
                        tblEmployee30.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee30.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee30.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 31)
                    {
                        btnEmployee31.Visibility = Visibility.Visible;
                        tblEmployee31.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee31.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee31.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 32)
                    {
                        btnEmployee32.Visibility = Visibility.Visible;
                        tblEmployee32.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee32.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee32.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 33)
                    {
                        btnEmployee33.Visibility = Visibility.Visible;
                        tblEmployee33.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee33.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee33.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 34)
                    {
                        btnEmployee34.Visibility = Visibility.Visible;
                        tblEmployee34.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee34.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee34.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 35)
                    {
                        btnEmployee35.Visibility = Visibility.Visible;
                        tblEmployee35.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee35.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee35.Background = Brushes.Blue;
                        }
                    }
                    if (intButtonCounter == 36)
                    {
                        btnEmployee36.Visibility = Visibility.Visible;
                        tblEmployee36.Text = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].FirstName + " " + TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].LastName;
                        gintEmployeeID[intButtonCounter - 1] = TheFindActiveEmployeesDataSet.FindActiveEmployees[gintStartingCounter].EmployeeID;

                        TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet = TheVehicleHistoryClass.FindVehicleHistoryByEmployeeIDAndDateRange(gintEmployeeID[intButtonCounter - 1], datStartDate, datEndDate);

                        intRecordsReturned = TheFindVehicleHistoryByEmployeeIDAndDateRangeDataSet.FindVehicleHistoryByEmployeeIDAndDateRange.Rows.Count;

                        if (intRecordsReturned == 0)
                        {
                            btnEmployee36.Background = Brushes.Green;
                        }
                        else
                        {
                            btnEmployee36.Background = Brushes.Blue;
                        }
                    }

                    if (gintStartingCounter == gintEmployeeNumberOfRecords)
                    {
                        intButtonCounter = gintNumberOfButtons;
                        gintStartingCounter = 0;
                        TheFindActiveEmployeesDataSet = TheEmployeeClass.FindActiveEmployees();
                        gintEmployeeNumberOfRecords = TheFindActiveEmployeesDataSet.FindActiveEmployees.Rows.Count - 1;
                    }
                    else
                    {
                        gintStartingCounter++;
                    }

                }
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Employee Dashboard // Load Controls " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
        private void HideControls()
        {
            btnEmployee1.Visibility = Visibility.Hidden;
            btnEmployee2.Visibility = Visibility.Hidden;
            btnEmployee3.Visibility = Visibility.Hidden;
            btnEmployee4.Visibility = Visibility.Hidden;
            btnEmployee5.Visibility = Visibility.Hidden;
            btnEmployee6.Visibility = Visibility.Hidden;
            btnEmployee7.Visibility = Visibility.Hidden;
            btnEmployee8.Visibility = Visibility.Hidden;
            btnEmployee9.Visibility = Visibility.Hidden;
            btnEmployee10.Visibility = Visibility.Hidden;
            btnEmployee11.Visibility = Visibility.Hidden;
            btnEmployee12.Visibility = Visibility.Hidden;
            btnEmployee13.Visibility = Visibility.Hidden;
            btnEmployee14.Visibility = Visibility.Hidden;
            btnEmployee15.Visibility = Visibility.Hidden;
            btnEmployee16.Visibility = Visibility.Hidden;
            btnEmployee17.Visibility = Visibility.Hidden;
            btnEmployee18.Visibility = Visibility.Hidden;
            btnEmployee19.Visibility = Visibility.Hidden;
            btnEmployee20.Visibility = Visibility.Hidden;
            btnEmployee21.Visibility = Visibility.Hidden;
            btnEmployee22.Visibility = Visibility.Hidden;
            btnEmployee23.Visibility = Visibility.Hidden;
            btnEmployee24.Visibility = Visibility.Hidden;
            btnEmployee25.Visibility = Visibility.Hidden;
            btnEmployee26.Visibility = Visibility.Hidden;
            btnEmployee27.Visibility = Visibility.Hidden;
            btnEmployee28.Visibility = Visibility.Hidden;
            btnEmployee29.Visibility = Visibility.Hidden;
            btnEmployee30.Visibility = Visibility.Hidden;
            btnEmployee31.Visibility = Visibility.Hidden;
            btnEmployee32.Visibility = Visibility.Hidden;
            btnEmployee33.Visibility = Visibility.Hidden;
            btnEmployee34.Visibility = Visibility.Hidden;
            btnEmployee35.Visibility = Visibility.Hidden;
            btnEmployee36.Visibility = Visibility.Hidden;
        }

        private void btnEmployee1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[0];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee2_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[1];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[2];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee4_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[3];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee5_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[4];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee6_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[5];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee7_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[6];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee8_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[7];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee9_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[8];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee10_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[9];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee11_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[10];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee12_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[11];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee13_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[12];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee14_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[13];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee15_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[14];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee16_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[15];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee17_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[16];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee18_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[17];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee19_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[18];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee20_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[19];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee21_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[20];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee22_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[21];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee23_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[22];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee24_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[23];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee25_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[24];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee26_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[25];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee27_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[26];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee28_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[27];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee29_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[28];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee30_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[29];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee31_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[30];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee32_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[31];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee33_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[32];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee34_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[33];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee35_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[34];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }

        private void btnEmployee36_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.gintEmployeeID = gintEmployeeID[35];

            EmployeeInformation EmployeeInformation = new EmployeeInformation();
            EmployeeInformation.ShowDialog();
        }
    }
}
