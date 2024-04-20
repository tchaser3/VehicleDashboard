/* Title:           Show Daily Inspection Notes
 * Date:            7-24-17
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
using InspectionsDLL;

namespace VehicleDashboard
{
    /// <summary>
    /// Interaction logic for ShowDailyInspectionNotes.xaml
    /// </summary>
    public partial class ShowDailyInspectionNotes : Window
    {
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        InspectionsClass TheInspectionClass = new InspectionsClass();

        FindVehicleInspectionProblemsByInspectionIDDataSet TheFindInspectionProblemsByInspectionIDDataSet = new FindVehicleInspectionProblemsByInspectionIDDataSet();

        public ShowDailyInspectionNotes()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TheFindInspectionProblemsByInspectionIDDataSet = TheInspectionClass.FindVehicleInspectionProblemsbyInspectionID(MainWindow.gintInspectionID);

            dgrResults.ItemsSource = TheFindInspectionProblemsByInspectionIDDataSet.FindVehicleInspectionProblemsByInspectionID;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
