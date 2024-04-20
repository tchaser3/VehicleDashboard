/* Title:           Vehicle Dashboard
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using VehicleStatusDLL;
using NewEventLogDLL;
using NewEmployeeDLL;

namespace VehicleDashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //setting up the classes
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        VehicleStatusClass TheVehicleStatusClass = new VehicleStatusClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();

        public static int gintSelectedIndex;
        public static int gintInspectionID;
        public static int gintProblemID;
        public static int gintVehicleID;
        public static int gintEmployeeID;

        public static FindFleetVehicleStatusDataSet TheFindFleetVehicleStatusDataSet = new FindFleetVehicleStatusDataSet();
        FindWarehousesDataSet TheFindWarehouseDataSet = new FindWarehousesDataSet();

        //setting up the time
        DispatcherTimer MyTimer = new DispatcherTimer();

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            TheMessagesClass.CloseTheProgram();
        }
        private void LoadControls()
        {
            //setting local variables
            int intCounter;
            int intNumberOfRecords;

            try
            {
                HideControls();

                TheFindFleetVehicleStatusDataSet = TheVehicleStatusClass.FindFleetVehicleStatus();

                intNumberOfRecords = TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus.Rows.Count - 1;

                for (intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    if (intCounter == 0)
                    {
                        btnVehicle1.Visibility = Visibility.Visible;
                        btnVehicle1.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber == 1121)
                        {
                            TheMessagesClass.ErrorMessage("fuck");
                        }

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle1.Background = Brushes.Red;
                            btnVehicle1.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle1.Background = Brushes.Yellow;
                            btnVehicle1.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
                        {
                            btnVehicle1.Background = Brushes.Green;
                            btnVehicle1.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 1)
                    {
                        btnVehicle2.Visibility = Visibility.Visible;
                        btnVehicle2.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle2.Background = Brushes.Red;
                            btnVehicle2.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle2.Background = Brushes.Yellow;
                            btnVehicle2.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle2.Background = Brushes.Green;
                            btnVehicle2.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 2)
                    {
                        btnVehicle3.Visibility = Visibility.Visible;
                        btnVehicle3.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle3.Background = Brushes.Red;
                            btnVehicle3.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle3.Background = Brushes.Yellow;
                            btnVehicle3.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle3.Background = Brushes.Green;
                            btnVehicle3.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 3)
                    {
                        btnVehicle4.Visibility = Visibility.Visible;
                        btnVehicle4.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle4.Background = Brushes.Red;
                            btnVehicle4.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle4.Background = Brushes.Yellow;
                            btnVehicle4.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle4.Background = Brushes.Green;
                            btnVehicle4.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 4)
                    {
                        btnVehicle5.Visibility = Visibility.Visible;
                        btnVehicle5.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle5.Background = Brushes.Red;
                            btnVehicle5.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle5.Background = Brushes.Yellow;
                            btnVehicle5.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle5.Background = Brushes.Green;
                            btnVehicle5.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 5)
                    {
                        btnVehicle6.Visibility = Visibility.Visible;
                        btnVehicle6.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle6.Background = Brushes.Red;
                            btnVehicle6.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle6.Background = Brushes.Yellow;
                            btnVehicle6.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle6.Background = Brushes.Green;
                            btnVehicle6.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 6)
                    {
                        btnVehicle7.Visibility = Visibility.Visible;
                        btnVehicle7.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle7.Background = Brushes.Red;
                            btnVehicle7.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle7.Background = Brushes.Yellow;
                            btnVehicle7.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle7.Background = Brushes.Green;
                            btnVehicle7.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 7)
                    {
                        btnVehicle8.Visibility = Visibility.Visible;
                        btnVehicle8.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle8.Background = Brushes.Red;
                            btnVehicle8.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle8.Background = Brushes.Yellow;
                            btnVehicle8.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle8.Background = Brushes.Green;
                            btnVehicle8.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 8)
                    {
                        btnVehicle9.Visibility = Visibility.Visible;
                        btnVehicle9.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle9.Background = Brushes.Red;
                            btnVehicle9.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle9.Background = Brushes.Yellow;
                            btnVehicle9.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle9.Background = Brushes.Green;
                            btnVehicle9.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 9)
                    {
                        btnVehicle10.Visibility = Visibility.Visible;
                        btnVehicle10.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle10.Background = Brushes.Red;
                            btnVehicle10.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle10.Background = Brushes.Yellow;
                            btnVehicle10.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle10.Background = Brushes.Green;
                            btnVehicle10.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 10)
                    {
                        btnVehicle11.Visibility = Visibility.Visible;
                        btnVehicle11.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle11.Background = Brushes.Red;
                            btnVehicle11.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle11.Background = Brushes.Yellow;
                            btnVehicle11.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle11.Background = Brushes.Green;
                            btnVehicle11.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 11)
                    {
                        btnVehicle12.Visibility = Visibility.Visible;
                        btnVehicle12.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle12.Background = Brushes.Red;
                            btnVehicle12.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle12.Background = Brushes.Yellow;
                            btnVehicle12.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle12.Background = Brushes.Green;
                            btnVehicle12.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 12)
                    {
                        btnVehicle13.Visibility = Visibility.Visible;
                        btnVehicle13.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle13.Background = Brushes.Red;
                            btnVehicle13.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle13.Background = Brushes.Yellow;
                            btnVehicle13.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle13.Background = Brushes.Green;
                            btnVehicle13.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 13)
                    {
                        btnVehicle14.Visibility = Visibility.Visible;
                        btnVehicle14.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle14.Background = Brushes.Red;
                            btnVehicle14.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle14.Background = Brushes.Yellow;
                            btnVehicle14.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle14.Background = Brushes.Green;
                            btnVehicle14.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 14)
                    {
                        btnVehicle15.Visibility = Visibility.Visible;
                        btnVehicle15.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle15.Background = Brushes.Red;
                            btnVehicle15.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle15.Background = Brushes.Yellow;
                            btnVehicle15.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle15.Background = Brushes.Green;
                            btnVehicle15.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 15)
                    {
                        btnVehicle16.Visibility = Visibility.Visible;
                        btnVehicle16.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle16.Background = Brushes.Red;
                            btnVehicle16.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle16.Background = Brushes.Yellow;
                            btnVehicle16.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle16.Background = Brushes.Green;
                            btnVehicle16.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 16)
                    {
                        btnVehicle17.Visibility = Visibility.Visible;
                        btnVehicle17.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle17.Background = Brushes.Red;
                            btnVehicle17.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle17.Background = Brushes.Yellow;
                            btnVehicle17.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle17.Background = Brushes.Green;
                            btnVehicle17.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 17)
                    {
                        btnVehicle18.Visibility = Visibility.Visible;
                        btnVehicle18.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle18.Background = Brushes.Red;
                            btnVehicle18.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle18.Background = Brushes.Yellow;
                            btnVehicle18.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle18.Background = Brushes.Green;
                            btnVehicle18.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 18)
                    {
                        btnVehicle19.Visibility = Visibility.Visible;
                        btnVehicle19.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle19.Background = Brushes.Red;
                            btnVehicle19.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle19.Background = Brushes.Yellow;
                            btnVehicle19.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle19.Background = Brushes.Green;
                            btnVehicle19.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 19)
                    {
                        btnVehicle20.Visibility = Visibility.Visible;
                        btnVehicle20.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle20.Background = Brushes.Red;
                            btnVehicle20.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle20.Background = Brushes.Yellow;
                            btnVehicle20.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle20.Background = Brushes.Green;
                            btnVehicle20.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 20)
                    {
                        btnVehicle21.Visibility = Visibility.Visible;
                        btnVehicle21.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle21.Background = Brushes.Red;
                            btnVehicle21.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle21.Background = Brushes.Yellow;
                            btnVehicle21.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle21.Background = Brushes.Green;
                            btnVehicle21.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 21)
                    {
                        btnVehicle22.Visibility = Visibility.Visible;
                        btnVehicle22.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle22.Background = Brushes.Red;
                            btnVehicle22.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle22.Background = Brushes.Yellow;
                            btnVehicle22.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle22.Background = Brushes.Green;
                            btnVehicle22.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 22)
                    {
                        btnVehicle23.Visibility = Visibility.Visible;
                        btnVehicle23.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle23.Background = Brushes.Red;
                            btnVehicle23.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle23.Background = Brushes.Yellow;
                            btnVehicle23.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle23.Background = Brushes.Green;
                            btnVehicle23.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 23)
                    {
                        btnVehicle24.Visibility = Visibility.Visible;
                        btnVehicle24.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle24.Background = Brushes.Red;
                            btnVehicle24.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle24.Background = Brushes.Yellow;
                            btnVehicle24.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle24.Background = Brushes.Green;
                            btnVehicle24.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 24)
                    {
                        btnVehicle25.Visibility = Visibility.Visible;
                        btnVehicle25.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle25.Background = Brushes.Red;
                            btnVehicle25.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle25.Background = Brushes.Yellow;
                            btnVehicle25.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle25.Background = Brushes.Green;
                            btnVehicle25.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 25)
                    {
                        btnVehicle26.Visibility = Visibility.Visible;
                        btnVehicle26.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle26.Background = Brushes.Red;
                            btnVehicle26.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle26.Background = Brushes.Yellow;
                            btnVehicle26.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle26.Background = Brushes.Green;
                            btnVehicle26.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 26)
                    {
                        btnVehicle27.Visibility = Visibility.Visible;
                        btnVehicle27.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle27.Background = Brushes.Red;
                            btnVehicle27.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle27.Background = Brushes.Yellow;
                            btnVehicle27.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle27.Background = Brushes.Green;
                            btnVehicle27.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 27)
                    {
                        btnVehicle28.Visibility = Visibility.Visible;
                        btnVehicle28.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle28.Background = Brushes.Red;
                            btnVehicle28.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle28.Background = Brushes.Yellow;
                            btnVehicle28.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle28.Background = Brushes.Green;
                            btnVehicle28.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 28)
                    {
                        btnVehicle29.Visibility = Visibility.Visible;
                        btnVehicle29.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle29.Background = Brushes.Red;
                            btnVehicle29.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle29.Background = Brushes.Yellow;
                            btnVehicle29.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle29.Background = Brushes.Green;
                            btnVehicle29.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 29)
                    {
                        btnVehicle30.Visibility = Visibility.Visible;
                        btnVehicle30.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle30.Background = Brushes.Red;
                            btnVehicle30.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle30.Background = Brushes.Yellow;
                            btnVehicle30.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle30.Background = Brushes.Green;
                            btnVehicle30.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 30)
                    {
                        btnVehicle31.Visibility = Visibility.Visible;
                        btnVehicle31.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle31.Background = Brushes.Red;
                            btnVehicle31.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle31.Background = Brushes.Yellow;
                            btnVehicle31.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle31.Background = Brushes.Green;
                            btnVehicle31.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 31)
                    {
                        btnVehicle32.Visibility = Visibility.Visible;
                        btnVehicle32.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle32.Background = Brushes.Red;
                            btnVehicle32.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle32.Background = Brushes.Yellow;
                            btnVehicle32.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle32.Background = Brushes.Green;
                            btnVehicle32.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 32)
                    {
                        btnVehicle33.Visibility = Visibility.Visible;
                        btnVehicle33.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle33.Background = Brushes.Red;
                            btnVehicle33.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle33.Background = Brushes.Yellow;
                            btnVehicle33.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle33.Background = Brushes.Green;
                            btnVehicle33.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 33)
                    {
                        btnVehicle34.Visibility = Visibility.Visible;
                        btnVehicle34.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle34.Background = Brushes.Red;
                            btnVehicle34.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle34.Background = Brushes.Yellow;
                            btnVehicle34.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle34.Background = Brushes.Green;
                            btnVehicle34.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 34)
                    {
                        btnVehicle35.Visibility = Visibility.Visible;
                        btnVehicle35.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle35.Background = Brushes.Red;
                            btnVehicle35.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle35.Background = Brushes.Yellow;
                            btnVehicle35.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle35.Background = Brushes.Green;
                            btnVehicle35.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 35)
                    {
                        btnVehicle36.Visibility = Visibility.Visible;
                        btnVehicle36.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle36.Background = Brushes.Red;
                            btnVehicle36.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle36.Background = Brushes.Yellow;
                            btnVehicle36.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle36.Background = Brushes.Green;
                            btnVehicle36.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 36)
                    {
                        btnVehicle37.Visibility = Visibility.Visible;
                        btnVehicle37.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle37.Background = Brushes.Red;
                            btnVehicle37.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle37.Background = Brushes.Yellow;
                            btnVehicle37.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle37.Background = Brushes.Green;
                            btnVehicle37.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 37)
                    {
                        btnVehicle38.Visibility = Visibility.Visible;
                        btnVehicle38.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle38.Background = Brushes.Red;
                            btnVehicle38.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle38.Background = Brushes.Yellow;
                            btnVehicle38.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle38.Background = Brushes.Green;
                            btnVehicle38.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 38)
                    {
                        btnVehicle39.Visibility = Visibility.Visible;
                        btnVehicle39.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle39.Background = Brushes.Red;
                            btnVehicle39.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle39.Background = Brushes.Yellow;
                            btnVehicle39.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle39.Background = Brushes.Green;
                            btnVehicle39.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 39)
                    {
                        btnVehicle40.Visibility = Visibility.Visible;
                        btnVehicle40.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle40.Background = Brushes.Red;
                            btnVehicle40.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle40.Background = Brushes.Yellow;
                            btnVehicle40.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle40.Background = Brushes.Green;
                            btnVehicle40.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 40)
                    {
                        btnVehicle41.Visibility = Visibility.Visible;
                        btnVehicle41.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle41.Background = Brushes.Red;
                            btnVehicle41.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle41.Background = Brushes.Yellow;
                            btnVehicle41.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle41.Background = Brushes.Green;
                            btnVehicle41.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 41)
                    {
                        btnVehicle42.Visibility = Visibility.Visible;
                        btnVehicle42.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle42.Background = Brushes.Red;
                            btnVehicle42.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle42.Background = Brushes.Yellow;
                            btnVehicle42.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle42.Background = Brushes.Green;
                            btnVehicle42.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 42)
                    {
                        btnVehicle43.Visibility = Visibility.Visible;
                        btnVehicle43.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle43.Background = Brushes.Red;
                            btnVehicle43.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle43.Background = Brushes.Yellow;
                            btnVehicle43.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle43.Background = Brushes.Green;
                            btnVehicle43.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 43)
                    {
                        btnVehicle44.Visibility = Visibility.Visible;
                        btnVehicle44.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle44.Background = Brushes.Red;
                            btnVehicle44.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle44.Background = Brushes.Yellow;
                            btnVehicle44.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle44.Background = Brushes.Green;
                            btnVehicle44.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 44)
                    {
                        btnVehicle45.Visibility = Visibility.Visible;
                        btnVehicle45.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle45.Background = Brushes.Red;
                            btnVehicle45.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle45.Background = Brushes.Yellow;
                            btnVehicle45.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle45.Background = Brushes.Green;
                            btnVehicle45.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 45)
                    {
                        btnVehicle46.Visibility = Visibility.Visible;
                        btnVehicle46.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle46.Background = Brushes.Red;
                            btnVehicle46.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle46.Background = Brushes.Yellow;
                            btnVehicle46.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle46.Background = Brushes.Green;
                            btnVehicle46.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 46)
                    {
                        btnVehicle47.Visibility = Visibility.Visible;
                        btnVehicle47.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle47.Background = Brushes.Red;
                            btnVehicle47.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle47.Background = Brushes.Yellow;
                            btnVehicle47.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle47.Background = Brushes.Green;
                            btnVehicle47.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 47)
                    {
                        btnVehicle48.Visibility = Visibility.Visible;
                        btnVehicle48.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle48.Background = Brushes.Red;
                            btnVehicle48.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle48.Background = Brushes.Yellow;
                            btnVehicle48.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle48.Background = Brushes.Green;
                            btnVehicle48.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 48)
                    {
                        btnVehicle49.Visibility = Visibility.Visible;
                        btnVehicle49.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle49.Background = Brushes.Red;
                            btnVehicle49.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle49.Background = Brushes.Yellow;
                            btnVehicle49.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle49.Background = Brushes.Green;
                            btnVehicle49.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 49)
                    {
                        btnVehicle50.Visibility = Visibility.Visible;
                        btnVehicle50.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle50.Background = Brushes.Red;
                            btnVehicle50.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle50.Background = Brushes.Yellow;
                            btnVehicle50.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle50.Background = Brushes.Green;
                            btnVehicle50.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 50)
                    {
                        btnVehicle51.Visibility = Visibility.Visible;
                        btnVehicle51.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle51.Background = Brushes.Red;
                            btnVehicle51.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle51.Background = Brushes.Yellow;
                            btnVehicle51.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle51.Background = Brushes.Green;
                            btnVehicle51.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 51)
                    {
                        btnVehicle52.Visibility = Visibility.Visible;
                        btnVehicle52.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle52.Background = Brushes.Red;
                            btnVehicle52.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle52.Background = Brushes.Yellow;
                            btnVehicle52.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle52.Background = Brushes.Green;
                            btnVehicle52.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 52)
                    {
                        btnVehicle53.Visibility = Visibility.Visible;
                        btnVehicle53.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle53.Background = Brushes.Red;
                            btnVehicle53.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle53.Background = Brushes.Yellow;
                            btnVehicle53.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle53.Background = Brushes.Green;
                            btnVehicle53.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 53)
                    {
                        btnVehicle54.Visibility = Visibility.Visible;
                        btnVehicle54.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle54.Background = Brushes.Red;
                            btnVehicle54.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle54.Background = Brushes.Yellow;
                            btnVehicle54.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle54.Background = Brushes.Green;
                            btnVehicle54.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 54)
                    {
                        btnVehicle55.Visibility = Visibility.Visible;
                        btnVehicle55.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle55.Background = Brushes.Red;
                            btnVehicle55.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle55.Background = Brushes.Yellow;
                            btnVehicle55.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle55.Background = Brushes.Green;
                            btnVehicle55.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 55)
                    {
                        btnVehicle56.Visibility = Visibility.Visible;
                        btnVehicle56.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle56.Background = Brushes.Red;
                            btnVehicle56.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle56.Background = Brushes.Yellow;
                            btnVehicle56.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle56.Background = Brushes.Green;
                            btnVehicle56.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 56)
                    {
                        btnVehicle57.Visibility = Visibility.Visible;
                        btnVehicle57.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle57.Background = Brushes.Red;
                            btnVehicle57.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle57.Background = Brushes.Yellow;
                            btnVehicle57.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle57.Background = Brushes.Green;
                            btnVehicle57.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 57)
                    {
                        btnVehicle58.Visibility = Visibility.Visible;
                        btnVehicle58.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle58.Background = Brushes.Red;
                            btnVehicle58.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle58.Background = Brushes.Yellow;
                            btnVehicle58.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle58.Background = Brushes.Green;
                            btnVehicle58.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 58)
                    {
                        btnVehicle59.Visibility = Visibility.Visible;
                        btnVehicle59.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle59.Background = Brushes.Red;
                            btnVehicle59.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle59.Background = Brushes.Yellow;
                            btnVehicle59.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle59.Background = Brushes.Green;
                            btnVehicle59.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 59)
                    {
                        btnVehicle60.Visibility = Visibility.Visible;
                        btnVehicle60.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle60.Background = Brushes.Red;
                            btnVehicle60.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle60.Background = Brushes.Yellow;
                            btnVehicle60.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle60.Background = Brushes.Green;
                            btnVehicle60.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 60)
                    {
                        btnVehicle61.Visibility = Visibility.Visible;
                        btnVehicle61.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle61.Background = Brushes.Red;
                            btnVehicle61.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle61.Background = Brushes.Yellow;
                            btnVehicle61.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle61.Background = Brushes.Green;
                            btnVehicle61.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 61)
                    {
                        btnVehicle62.Visibility = Visibility.Visible;
                        btnVehicle62.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle62.Background = Brushes.Red;
                            btnVehicle62.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle62.Background = Brushes.Yellow;
                            btnVehicle62.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle62.Background = Brushes.Green;
                            btnVehicle62.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 62)
                    {
                        btnVehicle63.Visibility = Visibility.Visible;
                        btnVehicle63.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle63.Background = Brushes.Red;
                            btnVehicle63.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle63.Background = Brushes.Yellow;
                            btnVehicle63.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle63.Background = Brushes.Green;
                            btnVehicle63.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 63)
                    {
                        btnVehicle64.Visibility = Visibility.Visible;
                        btnVehicle64.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle64.Background = Brushes.Red;
                            btnVehicle64.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle64.Background = Brushes.Yellow;
                            btnVehicle64.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle64.Background = Brushes.Green;
                            btnVehicle64.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 64)
                    {
                        btnVehicle65.Visibility = Visibility.Visible;
                        btnVehicle65.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle65.Background = Brushes.Red;
                            btnVehicle65.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle65.Background = Brushes.Yellow;
                            btnVehicle65.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle65.Background = Brushes.Green;
                            btnVehicle65.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 65)
                    {
                        btnVehicle66.Visibility = Visibility.Visible;
                        btnVehicle66.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle66.Background = Brushes.Red;
                            btnVehicle66.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle66.Background = Brushes.Yellow;
                            btnVehicle66.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle66.Background = Brushes.Green;
                            btnVehicle66.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 66)
                    {
                        btnVehicle67.Visibility = Visibility.Visible;
                        btnVehicle67.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle67.Background = Brushes.Red;
                            btnVehicle67.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle67.Background = Brushes.Yellow;
                            btnVehicle67.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle67.Background = Brushes.Green;
                            btnVehicle67.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 67)
                    {
                        btnVehicle68.Visibility = Visibility.Visible;
                        btnVehicle68.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle68.Background = Brushes.Red;
                            btnVehicle68.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle68.Background = Brushes.Yellow;
                            btnVehicle68.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle68.Background = Brushes.Green;
                            btnVehicle68.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 68)
                    {
                        btnVehicle69.Visibility = Visibility.Visible;
                        btnVehicle69.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle69.Background = Brushes.Red;
                            btnVehicle69.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle69.Background = Brushes.Yellow;
                            btnVehicle69.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle69.Background = Brushes.Green;
                            btnVehicle69.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 69)
                    {
                        btnVehicle70.Visibility = Visibility.Visible;
                        btnVehicle70.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle70.Background = Brushes.Red;
                            btnVehicle70.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle70.Background = Brushes.Yellow;
                            btnVehicle70.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle70.Background = Brushes.Green;
                            btnVehicle70.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 70)
                    {
                        btnVehicle71.Visibility = Visibility.Visible;
                        btnVehicle71.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle71.Background = Brushes.Red;
                            btnVehicle71.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle71.Background = Brushes.Yellow;
                            btnVehicle71.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle71.Background = Brushes.Green;
                            btnVehicle71.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 71)
                    {
                        btnVehicle72.Visibility = Visibility.Visible;
                        btnVehicle72.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle72.Background = Brushes.Red;
                            btnVehicle72.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle72.Background = Brushes.Yellow;
                            btnVehicle72.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle72.Background = Brushes.Green;
                            btnVehicle72.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 72)
                    {
                        btnVehicle73.Visibility = Visibility.Visible;
                        btnVehicle73.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle73.Background = Brushes.Red;
                            btnVehicle73.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle73.Background = Brushes.Yellow;
                            btnVehicle73.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle73.Background = Brushes.Green;
                            btnVehicle73.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 73)
                    {
                        btnVehicle74.Visibility = Visibility.Visible;
                        btnVehicle74.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle74.Background = Brushes.Red;
                            btnVehicle74.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle74.Background = Brushes.Yellow;
                            btnVehicle74.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle74.Background = Brushes.Green;
                            btnVehicle74.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 74)
                    {
                        btnVehicle75.Visibility = Visibility.Visible;
                        btnVehicle75.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle75.Background = Brushes.Red;
                            btnVehicle75.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle75.Background = Brushes.Yellow;
                            btnVehicle75.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle75.Background = Brushes.Green;
                            btnVehicle75.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 75)
                    {
                        btnVehicle76.Visibility = Visibility.Visible;
                        btnVehicle76.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle76.Background = Brushes.Red;
                            btnVehicle76.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle76.Background = Brushes.Yellow;
                            btnVehicle76.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle76.Background = Brushes.Green;
                            btnVehicle76.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 76)
                    {
                        btnVehicle77.Visibility = Visibility.Visible;
                        btnVehicle77.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle77.Background = Brushes.Red;
                            btnVehicle77.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle77.Background = Brushes.Yellow;
                            btnVehicle77.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle77.Background = Brushes.Green;
                            btnVehicle77.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 77)
                    {
                        btnVehicle78.Visibility = Visibility.Visible;
                        btnVehicle78.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle78.Background = Brushes.Red;
                            btnVehicle78.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle78.Background = Brushes.Yellow;
                            btnVehicle78.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle78.Background = Brushes.Green;
                            btnVehicle78.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 78)
                    {
                        btnVehicle79.Visibility = Visibility.Visible;
                        btnVehicle79.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle79.Background = Brushes.Red;
                            btnVehicle79.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle79.Background = Brushes.Yellow;
                            btnVehicle79.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle79.Background = Brushes.Green;
                            btnVehicle79.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 79)
                    {
                        btnVehicle80.Visibility = Visibility.Visible;
                        btnVehicle80.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle80.Background = Brushes.Red;
                            btnVehicle80.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle80.Background = Brushes.Yellow;
                            btnVehicle80.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle80.Background = Brushes.Green;
                            btnVehicle80.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 80)
                    {
                        btnVehicle81.Visibility = Visibility.Visible;
                        btnVehicle81.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle81.Background = Brushes.Red;
                            btnVehicle81.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle81.Background = Brushes.Yellow;
                            btnVehicle81.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle81.Background = Brushes.Green;
                            btnVehicle81.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 81)
                    {
                        btnVehicle82.Visibility = Visibility.Visible;
                        btnVehicle82.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle82.Background = Brushes.Red;
                            btnVehicle82.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle82.Background = Brushes.Yellow;
                            btnVehicle82.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle82.Background = Brushes.Green;
                            btnVehicle82.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 82)
                    {
                        btnVehicle83.Visibility = Visibility.Visible;
                        btnVehicle83.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle83.Background = Brushes.Red;
                            btnVehicle83.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle83.Background = Brushes.Yellow;
                            btnVehicle83.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle83.Background = Brushes.Green;
                            btnVehicle83.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 83)
                    {
                        btnVehicle84.Visibility = Visibility.Visible;
                        btnVehicle84.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle84.Background = Brushes.Red;
                            btnVehicle84.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle84.Background = Brushes.Yellow;
                            btnVehicle84.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle84.Background = Brushes.Green;
                            btnVehicle84.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 84)
                    {
                        btnVehicle85.Visibility = Visibility.Visible;
                        btnVehicle85.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle85.Background = Brushes.Red;
                            btnVehicle85.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle85.Background = Brushes.Yellow;
                            btnVehicle85.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle85.Background = Brushes.Green;
                            btnVehicle85.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 85)
                    {
                        btnVehicle86.Visibility = Visibility.Visible;
                        btnVehicle86.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle86.Background = Brushes.Red;
                            btnVehicle86.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle86.Background = Brushes.Yellow;
                            btnVehicle86.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle86.Background = Brushes.Green;
                            btnVehicle86.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 86)
                    {
                        btnVehicle87.Visibility = Visibility.Visible;
                        btnVehicle87.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle87.Background = Brushes.Red;
                            btnVehicle87.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle87.Background = Brushes.Yellow;
                            btnVehicle87.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle87.Background = Brushes.Green;
                            btnVehicle87.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 87)
                    {
                        btnVehicle88.Visibility = Visibility.Visible;
                        btnVehicle88.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle88.Background = Brushes.Red;
                            btnVehicle88.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle88.Background = Brushes.Yellow;
                            btnVehicle88.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle88.Background = Brushes.Green;
                            btnVehicle88.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 88)
                    {
                        btnVehicle89.Visibility = Visibility.Visible;
                        btnVehicle89.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle89.Background = Brushes.Red;
                            btnVehicle89.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle89.Background = Brushes.Yellow;
                            btnVehicle89.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle89.Background = Brushes.Green;
                            btnVehicle89.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 89)
                    {
                        btnVehicle90.Visibility = Visibility.Visible;
                        btnVehicle90.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle90.Background = Brushes.Red;
                            btnVehicle90.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle90.Background = Brushes.Yellow;
                            btnVehicle90.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle90.Background = Brushes.Green;
                            btnVehicle90.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 90)
                    {
                        btnVehicle91.Visibility = Visibility.Visible;
                        btnVehicle91.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle91.Background = Brushes.Red;
                            btnVehicle91.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle91.Background = Brushes.Yellow;
                            btnVehicle91.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle91.Background = Brushes.Green;
                            btnVehicle91.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 91)
                    {
                        btnVehicle92.Visibility = Visibility.Visible;
                        btnVehicle92.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle92.Background = Brushes.Red;
                            btnVehicle92.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle92.Background = Brushes.Yellow;
                            btnVehicle92.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle92.Background = Brushes.Green;
                            btnVehicle92.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 92)
                    {
                        btnVehicle93.Visibility = Visibility.Visible;
                        btnVehicle93.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle93.Background = Brushes.Red;
                            btnVehicle93.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle93.Background = Brushes.Yellow;
                            btnVehicle93.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle93.Background = Brushes.Green;
                            btnVehicle93.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 93)
                    {
                        btnVehicle94.Visibility = Visibility.Visible;
                        btnVehicle94.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle94.Background = Brushes.Red;
                            btnVehicle94.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle94.Background = Brushes.Yellow;
                            btnVehicle94.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle94.Background = Brushes.Green;
                            btnVehicle94.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 94)
                    {
                        btnVehicle95.Visibility = Visibility.Visible;
                        btnVehicle95.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle95.Background = Brushes.Red;
                            btnVehicle95.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle95.Background = Brushes.Yellow;
                            btnVehicle95.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle95.Background = Brushes.Green;
                            btnVehicle95.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 95)
                    {
                        btnVehicle96.Visibility = Visibility.Visible;
                        btnVehicle96.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle96.Background = Brushes.Red;
                            btnVehicle96.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle96.Background = Brushes.Yellow;
                            btnVehicle96.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle96.Background = Brushes.Green;
                            btnVehicle96.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 96)
                    {
                        btnVehicle97.Visibility = Visibility.Visible;
                        btnVehicle97.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle97.Background = Brushes.Red;
                            btnVehicle97.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle97.Background = Brushes.Yellow;
                            btnVehicle97.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle97.Background = Brushes.Green;
                            btnVehicle97.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 97)
                    {
                        btnVehicle98.Visibility = Visibility.Visible;
                        btnVehicle98.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle98.Background = Brushes.Red;
                            btnVehicle98.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle98.Background = Brushes.Yellow;
                            btnVehicle98.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle98.Background = Brushes.Green;
                            btnVehicle98.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 98)
                    {
                        btnVehicle99.Visibility = Visibility.Visible;
                        btnVehicle99.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle99.Background = Brushes.Red;
                            btnVehicle99.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle99.Background = Brushes.Yellow;
                            btnVehicle99.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle99.Background = Brushes.Green;
                            btnVehicle99.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 99)
                    {
                        btnVehicle100.Visibility = Visibility.Visible;
                        btnVehicle100.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle100.Background = Brushes.Red;
                            btnVehicle100.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle100.Background = Brushes.Yellow;
                            btnVehicle100.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle100.Background = Brushes.Green;
                            btnVehicle100.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 100)
                    {
                        btnVehicle101.Visibility = Visibility.Visible;
                        btnVehicle101.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle101.Background = Brushes.Red;
                            btnVehicle101.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle101.Background = Brushes.Yellow;
                            btnVehicle101.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle101.Background = Brushes.Green;
                            btnVehicle101.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 101)
                    {
                        btnVehicle102.Visibility = Visibility.Visible;
                        btnVehicle102.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle102.Background = Brushes.Red;
                            btnVehicle102.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle102.Background = Brushes.Yellow;
                            btnVehicle102.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle102.Background = Brushes.Green;
                            btnVehicle102.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 102)
                    {
                        btnVehicle103.Visibility = Visibility.Visible;
                        btnVehicle103.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle103.Background = Brushes.Red;
                            btnVehicle103.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle103.Background = Brushes.Yellow;
                            btnVehicle103.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle103.Background = Brushes.Green;
                            btnVehicle103.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 103)
                    {
                        btnVehicle104.Visibility = Visibility.Visible;
                        btnVehicle104.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle104.Background = Brushes.Red;
                            btnVehicle104.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle104.Background = Brushes.Yellow;
                            btnVehicle104.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "AVAILABLE")
                        {
                            btnVehicle104.Background = Brushes.Green;
                            btnVehicle104.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 104)
                    {
                        btnVehicle105.Visibility = Visibility.Visible;
                        btnVehicle105.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle105.Background = Brushes.Red;
                            btnVehicle105.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle105.Background = Brushes.Yellow;
                            btnVehicle105.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle105.Background = Brushes.Green;
                            btnVehicle105.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 105)
                    {
                        btnVehicle106.Visibility = Visibility.Visible;
                        btnVehicle106.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle106.Background = Brushes.Red;
                            btnVehicle106.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle106.Background = Brushes.Yellow;
                            btnVehicle106.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle106.Background = Brushes.Green;
                            btnVehicle106.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 106)
                    {
                        btnVehicle107.Visibility = Visibility.Visible;
                        btnVehicle107.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle107.Background = Brushes.Red;
                            btnVehicle107.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle107.Background = Brushes.Yellow;
                            btnVehicle107.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle107.Background = Brushes.Green;
                            btnVehicle107.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 107)
                    {
                        btnVehicle108.Visibility = Visibility.Visible;
                        btnVehicle108.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle108.Background = Brushes.Red;
                            btnVehicle108.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle108.Background = Brushes.Yellow;
                            btnVehicle108.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle108.Background = Brushes.Green;
                            btnVehicle108.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 108)
                    {
                        btnVehicle109.Visibility = Visibility.Visible;
                        btnVehicle109.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle109.Background = Brushes.Red;
                            btnVehicle109.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle109.Background = Brushes.Yellow;
                            btnVehicle109.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle109.Background = Brushes.Green;
                            btnVehicle109.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 109)
                    {
                        btnVehicle110.Visibility = Visibility.Visible;
                        btnVehicle110.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle110.Background = Brushes.Red;
                            btnVehicle110.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle110.Background = Brushes.Yellow;
                            btnVehicle110.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle110.Background = Brushes.Green;
                            btnVehicle110.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 110)
                    {
                        btnVehicle111.Visibility = Visibility.Visible;
                        btnVehicle111.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle111.Background = Brushes.Red;
                            btnVehicle111.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle111.Background = Brushes.Yellow;
                            btnVehicle111.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle111.Background = Brushes.Green;
                            btnVehicle111.Foreground = Brushes.White;
                        }
                    }
                    else if (intCounter == 111)
                    {
                        btnVehicle112.Visibility = Visibility.Visible;
                        btnVehicle112.Content = Convert.ToString(TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].BJCNumber);

                        if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "DOWN")
                        {
                            btnVehicle112.Background = Brushes.Red;
                            btnVehicle112.Foreground = Brushes.White;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NEEDS WORK")
                        {
                            btnVehicle112.Background = Brushes.Yellow;
                            btnVehicle112.Foreground = Brushes.Black;
                        }
                        else if (TheFindFleetVehicleStatusDataSet.FindFleetVehicleStatus[intCounter].VehicleStatus == "NO PROBLEM")
                        {
                            btnVehicle112.Background = Brushes.Green;
                            btnVehicle112.Foreground = Brushes.White;
                        }
                    }
                }

            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Vehicle Dashboard // Main Window // Load Controls " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HideControls();

            LoadControls();

            MyTimer.Tick += new EventHandler(BeginTheProcess);
            MyTimer.Interval = new TimeSpan(0, 0, 10);
            MyTimer.Start();
        }
        private void LoadComboBox()
        {

        }
        private void HideControls()
        {
            btnVehicle1.Visibility = Visibility.Hidden;
            btnVehicle2.Visibility = Visibility.Hidden;
            btnVehicle3.Visibility = Visibility.Hidden;
            btnVehicle4.Visibility = Visibility.Hidden;
            btnVehicle5.Visibility = Visibility.Hidden;
            btnVehicle6.Visibility = Visibility.Hidden;
            btnVehicle7.Visibility = Visibility.Hidden;
            btnVehicle8.Visibility = Visibility.Hidden;
            btnVehicle9.Visibility = Visibility.Hidden;
            btnVehicle10.Visibility = Visibility.Hidden;
            btnVehicle11.Visibility = Visibility.Hidden;
            btnVehicle12.Visibility = Visibility.Hidden;
            btnVehicle13.Visibility = Visibility.Hidden;
            btnVehicle14.Visibility = Visibility.Hidden;
            btnVehicle15.Visibility = Visibility.Hidden;
            btnVehicle16.Visibility = Visibility.Hidden;
            btnVehicle17.Visibility = Visibility.Hidden;
            btnVehicle18.Visibility = Visibility.Hidden;
            btnVehicle19.Visibility = Visibility.Hidden;
            btnVehicle20.Visibility = Visibility.Hidden;
            btnVehicle21.Visibility = Visibility.Hidden;
            btnVehicle22.Visibility = Visibility.Hidden;
            btnVehicle23.Visibility = Visibility.Hidden;
            btnVehicle24.Visibility = Visibility.Hidden;
            btnVehicle25.Visibility = Visibility.Hidden;
            btnVehicle26.Visibility = Visibility.Hidden;
            btnVehicle27.Visibility = Visibility.Hidden;
            btnVehicle28.Visibility = Visibility.Hidden;
            btnVehicle29.Visibility = Visibility.Hidden;
            btnVehicle30.Visibility = Visibility.Hidden;
            btnVehicle31.Visibility = Visibility.Hidden;
            btnVehicle32.Visibility = Visibility.Hidden;
            btnVehicle33.Visibility = Visibility.Hidden;
            btnVehicle34.Visibility = Visibility.Hidden;
            btnVehicle35.Visibility = Visibility.Hidden;
            btnVehicle36.Visibility = Visibility.Hidden;
            btnVehicle37.Visibility = Visibility.Hidden;
            btnVehicle38.Visibility = Visibility.Hidden;
            btnVehicle39.Visibility = Visibility.Hidden;
            btnVehicle40.Visibility = Visibility.Hidden;
            btnVehicle41.Visibility = Visibility.Hidden;
            btnVehicle42.Visibility = Visibility.Hidden;
            btnVehicle43.Visibility = Visibility.Hidden;
            btnVehicle44.Visibility = Visibility.Hidden;
            btnVehicle45.Visibility = Visibility.Hidden;
            btnVehicle46.Visibility = Visibility.Hidden;
            btnVehicle47.Visibility = Visibility.Hidden;
            btnVehicle48.Visibility = Visibility.Hidden;
            btnVehicle49.Visibility = Visibility.Hidden;
            btnVehicle50.Visibility = Visibility.Hidden;
            btnVehicle51.Visibility = Visibility.Hidden;
            btnVehicle52.Visibility = Visibility.Hidden;
            btnVehicle53.Visibility = Visibility.Hidden;
            btnVehicle54.Visibility = Visibility.Hidden;
            btnVehicle55.Visibility = Visibility.Hidden;
            btnVehicle56.Visibility = Visibility.Hidden;
            btnVehicle57.Visibility = Visibility.Hidden;
            btnVehicle58.Visibility = Visibility.Hidden;
            btnVehicle59.Visibility = Visibility.Hidden;
            btnVehicle60.Visibility = Visibility.Hidden;
            btnVehicle61.Visibility = Visibility.Hidden;
            btnVehicle62.Visibility = Visibility.Hidden;
            btnVehicle63.Visibility = Visibility.Hidden;
            btnVehicle64.Visibility = Visibility.Hidden;
            btnVehicle65.Visibility = Visibility.Hidden;
            btnVehicle66.Visibility = Visibility.Hidden;
            btnVehicle67.Visibility = Visibility.Hidden;
            btnVehicle68.Visibility = Visibility.Hidden;
            btnVehicle69.Visibility = Visibility.Hidden;
            btnVehicle70.Visibility = Visibility.Hidden;
            btnVehicle71.Visibility = Visibility.Hidden;
            btnVehicle72.Visibility = Visibility.Hidden;
            btnVehicle73.Visibility = Visibility.Hidden;
            btnVehicle74.Visibility = Visibility.Hidden;
            btnVehicle75.Visibility = Visibility.Hidden;
            btnVehicle76.Visibility = Visibility.Hidden;
            btnVehicle77.Visibility = Visibility.Hidden;
            btnVehicle78.Visibility = Visibility.Hidden;
            btnVehicle79.Visibility = Visibility.Hidden;
            btnVehicle80.Visibility = Visibility.Hidden;
            btnVehicle81.Visibility = Visibility.Hidden;
            btnVehicle82.Visibility = Visibility.Hidden;
            btnVehicle83.Visibility = Visibility.Hidden;
            btnVehicle84.Visibility = Visibility.Hidden;
            btnVehicle85.Visibility = Visibility.Hidden;
            btnVehicle86.Visibility = Visibility.Hidden;
            btnVehicle87.Visibility = Visibility.Hidden;
            btnVehicle88.Visibility = Visibility.Hidden;
            btnVehicle89.Visibility = Visibility.Hidden;
            btnVehicle90.Visibility = Visibility.Hidden;
            btnVehicle91.Visibility = Visibility.Hidden;
            btnVehicle92.Visibility = Visibility.Hidden;
            btnVehicle93.Visibility = Visibility.Hidden;
            btnVehicle94.Visibility = Visibility.Hidden;
            btnVehicle95.Visibility = Visibility.Hidden;
            btnVehicle96.Visibility = Visibility.Hidden;
            btnVehicle97.Visibility = Visibility.Hidden;
            btnVehicle98.Visibility = Visibility.Hidden;
            btnVehicle99.Visibility = Visibility.Hidden;
            btnVehicle100.Visibility = Visibility.Hidden;
            btnVehicle101.Visibility = Visibility.Hidden;
            btnVehicle102.Visibility = Visibility.Hidden;
            btnVehicle103.Visibility = Visibility.Hidden;
            btnVehicle104.Visibility = Visibility.Hidden;
            btnVehicle105.Visibility = Visibility.Hidden;
            btnVehicle106.Visibility = Visibility.Hidden;
            btnVehicle107.Visibility = Visibility.Hidden;
            btnVehicle108.Visibility = Visibility.Hidden;
            btnVehicle109.Visibility = Visibility.Hidden;
            btnVehicle110.Visibility = Visibility.Hidden;
            btnVehicle111.Visibility = Visibility.Hidden;
            btnVehicle112.Visibility = Visibility.Hidden;



        }
        private void ChangeStatus()
        {

        }
        private void BeginTheProcess(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void btnVehicle1_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 0;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle2_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 1;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle3_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 2;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle4_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 3;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle5_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 4;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle6_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 5;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle7_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 6;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle8_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 7;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle9_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 8;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle10_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 9;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle11_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 10;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle12_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 11;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle13_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 12;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle14_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 13;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle15_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 14;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle16_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 15;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle17_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 16;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle18_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 17;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle19_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 18;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle20_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 19;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle21_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 20;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle22_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 21;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle23_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 22;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle24_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 23;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle25_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 24;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle26_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 25;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle27_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 26;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle28_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 27;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle29_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 28;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle30_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 29;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle31_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 30;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle32_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 31;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle33_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 32;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle34_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 33;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle35_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 34;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle36_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 35;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle37_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 36;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle38_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 37;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle39_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 38;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle40_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 39;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle41_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 40;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle42_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 41;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle43_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 42;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle44_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 43;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle45_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 44;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle46_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 45;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle47_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 46;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle48_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 47;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle49_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 48;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle50_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 49;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle51_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 50;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle52_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 51;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle53_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 52;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle54_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 53;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle55_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 54;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle56_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 55;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle57_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 56;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();

        }

        private void btnVehicle58_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 57;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle59_Click(object sender, RoutedEventArgs e)
        {

            gintSelectedIndex = 58;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle60_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 59;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle61_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 60;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle62_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 61;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle63_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 62;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle64_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 63;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle65_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 64;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle66_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 65;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle67_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 66;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle68_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 67;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle69_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 68;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle70_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 69;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle71_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 70;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle72_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 71;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle73_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 72;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle74_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 73;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle75_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 74;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle76_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 75;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle77_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 76;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle78_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 77;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle79_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 78;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle80_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 79;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle81_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 80;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle82_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 81;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle83_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 82;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle84_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 83;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle85_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 84;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle86_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 85;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle87_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 86;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle88_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 87;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle89_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 88;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle90_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 89;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle91_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 90;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle92_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 91;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle93_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 92;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle94_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 93;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle95_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 94;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle96_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 95;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle97_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 96;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle98_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 97;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle99_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 98;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle100_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 99;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle101_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 100;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle102_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 101;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle103_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 102;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle104_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 103;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle105_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 104;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle106_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 105;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle107_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 106;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle108_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 107;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle109_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 108;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle110_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 109;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle111_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 110;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnVehicle112_Click(object sender, RoutedEventArgs e)
        {
            gintSelectedIndex = 111;

            DisplayVehicleInformation DisplayVehicleInformation = new DisplayVehicleInformation();
            DisplayVehicleInformation.ShowDialog();
        }

        private void btnEmployeeDashboard_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard EmployeeDashboard = new EmployeeDashboard();
            EmployeeDashboard.Show();
        }
    }
}
