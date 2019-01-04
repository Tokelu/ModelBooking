using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ModelBooking.Utilities;
using ModelBooking.Views;
using ModelBookingWPF.Models;


namespace ModelBooking.Viewmodels
{
    public class ModelAssignmentViewModel
    {
        public ObservableCollection<Assignment> Assignments { get; } = new ObservableCollection<Assignment>();
        public ObservableCollection<Model> Models { get; } = new ObservableCollection<Model>();

        public ModelAssignmentViewModel()
        {
            Models.LoadModels();
            Assignments.LoadAssignments();
        }
        private ICommand _addModelCommand;
        public ICommand AddModelCommand => _addModelCommand ?? (_addModelCommand = new RelayCommand(AddModel));

        private ICommand _addAssignmentCommand;
        public ICommand AddAssignmentCommand => _addAssignmentCommand ?? (_addAssignmentCommand = new RelayCommand(AddAssignment));

        private ICommand _addAssignModelCommand;
        public ICommand AddAssignModelCommand => _addAssignModelCommand ?? (_addAssignModelCommand = new RelayCommand(AssignModel));


        private void AddModel()
        {
            AddModel model = new AddModel();
            model.ShowDialog();

            Models.Add(new Model(
                model.Name,
                model.PhoneNumber,
                model.Address,
                model.Height,
                model.Weight,
                model.HairColour,
                model.Comment,
                model.Username,
                model.Password
            ));

            Models.SaveModels();
        }
        private void AddAssignment()
        {
            AddAssignment assignment = new AddAssignment();
            assignment.ShowDialog();

            Assignments.Add(new Assignment(
                assignment.CName,
                assignment.StartDate,
                assignment.NumberDaysNeeded,
                assignment.Location,
                assignment.NumberModelsNeeded,
                assignment.Comment));

            Assignments.SaveAssignments();
        }
        private void AssignModel()
        {
            AssignModel modelAssignment = new AssignModel();
            modelAssignment.DataContext = this;
            modelAssignment.Show();
            
        }









    }
}