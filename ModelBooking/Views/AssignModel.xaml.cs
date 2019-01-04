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
using ModelBooking.Utilities;
using ModelBooking.Viewmodels;
using ModelBookingWPF.Models;

namespace ModelBooking.Views
{
    /// <summary>
    /// Interaction logic for AssignModel.xaml
    /// </summary>
    public partial class AssignModel : Window
    {
        public AssignModel()
        {
            InitializeComponent();
        }

        public Guid? Assignment { get; private set; }
        public List<Guid> Models { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Assignment= (cBAssignment.SelectedItem as Assignment)?.id;
            Models = ModelList.SelectedItems.Cast<Model>().Select(x => x.id).ToList();
            var context = DataContext as ModelAssignmentViewModel;
            var assignment = context.Assignments.FirstOrDefault(x => x.id == Assignment);
            foreach (var m in Models)
            {
                var model = context.Models.FirstOrDefault(x => x.id == m);
                assignment.Models.Add(model.id);
                model.Assignments.Add(assignment.id);
            }
            context.Models.SaveModels();
            context.Assignments.SaveAssignments();
            Close();
        }

    }
}
