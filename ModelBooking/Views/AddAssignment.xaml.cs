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

namespace ModelBooking.Views
{
    /// <summary>
    /// Interaction logic for AddAssignment.xaml
    /// </summary>
    public partial class AddAssignment : Window
    {
        public AddAssignment()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {           
            CName = tBCName.Text;
            StartDate = tBStartDate.SelectedDate ?? DateTime.Today; 
            NumberDaysNeeded = Int32.Parse(tBNumberDays.Text);
            Location = tBLocation.Text;
            NumberModelsNeeded = Int32.Parse(tBNumberModels.Text);
            Comment = tBlComment.Text;

            DialogResult = true;
        }

        public string Comment { get; set; }

        public int NumberModelsNeeded { get; set; }

        public string Location { get; set; }

        public int NumberDaysNeeded { get; set; }

        public DateTime StartDate { get; set ; }

        public string CName { get; set; }
    }
}
