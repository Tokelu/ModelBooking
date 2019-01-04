using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModelBookingWPF.Models
{
    public class Assignment
    {

        public Assignment()
        {
            // Ikke implementeret - Skal bruges til Json 
        }


        public Assignment(string _customer, DateTime _startDate, int _nbrDays, string _location, int _nbrModelsNeeded, string _comment)
        {
            customer = _customer;
            startDate = _startDate;
            nbrDays = _nbrDays;
            location = _location;
            nbrModelsNeeded = _nbrModelsNeeded;
            comment = _comment;
            
        }


        private string customer;
        private DateTime startDate;
        private int nbrDays;
        private string location;
        private int nbrModelsNeeded;
        private string comment;


        public Guid id { get; set; } = Guid.NewGuid();
        public string Customer
        {
            get => customer;
            set { customer = (value?.Length > 1 ? value : "Not Set"); }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public DateTime StartDate
        {
            get => startDate;
            set { startDate = value; }
        }

        public int AmountOfDays
        {
            get => nbrDays;
            set { nbrDays = (value > 0 ? value : 1); }
        }

        public int AmountOfModels
        {
            get => nbrModelsNeeded;
            set { nbrModelsNeeded = (value > 0 ? value : 1); } // altid mindst én model til et job.
        }

        public string Comment
        {
            get => comment;
            set { comment = (value?.Length > 1 ? value : "No comments"); }
        }
        public ObservableCollection<Guid> Models { get; set; } = new ObservableCollection<Guid>();
    }
}