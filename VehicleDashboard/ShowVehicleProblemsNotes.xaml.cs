/* Title:           Show Vehicle Problem Notes
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
using VehicleProblemsDLL;

namespace VehicleDashboard
{
    /// <summary>
    /// Interaction logic for ShowVehicleProblemsNotes.xaml
    /// </summary>
    public partial class ShowVehicleProblemsNotes : Window
    {
        VehicleProblemClass TheVehicleProblemClass = new VehicleProblemClass();

        FindVehicleProblemUpdateByProblemIDDataSet TheFindVehicleProblemUpdateByProblemIdDataSet = new FindVehicleProblemUpdateByProblemIDDataSet();

        public ShowVehicleProblemsNotes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TheFindVehicleProblemUpdateByProblemIdDataSet = TheVehicleProblemClass.FindVehicleProblemUpdateByProblemID(MainWindow.gintProblemID);

            dgrResults.ItemsSource = TheFindVehicleProblemUpdateByProblemIdDataSet.FindVehicleProblemUpdateByProblemID;
        }
    }
}
