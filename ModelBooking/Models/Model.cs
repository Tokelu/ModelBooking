using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ModelBookingWPF.Models
{
    [Serializable]
    public class Model
    {

        public Model()
        {
            // Ikke implementeret - Skal bruges til Json 
        }

        public Model(string _name, int _phoneNumber, string _address,double _height,double _weight,string _hairColour,string _comment,string _username, string _password)
        {
            name = _name;
            phoneNumber = _phoneNumber;
            address = _address;
            height = _height;
            weight = _weight;
            hairColour = _hairColour;
            comment = _comment;
            username = _username;
            password = _password;

        }

        private string name;
        private int    phoneNumber;
        private string address;
        private double height;
        private double weight;
        private string hairColour;
        private string comment;
        private string username; // til webdelen, hvis det kommer til at blive knyttet sammen
        private string password; // til webdelen, hvis det kommer til at blive knyttet sammen

        public Guid id { get; set; } = Guid.NewGuid();
        public string Name
        {
            get => name;
            set { name = (value?.Length > 1 ? value : "Not Set"); }
        }

        public int PhoneNumber
        {
            get => phoneNumber;
            set { phoneNumber = (value > 0 ? value : 0); }
        }

        public string Address
        {
            get => address;
            set { address = (value?.Length > 1 ? value : "Not Set"); }
        }

        public double Height
        {
            get => height;
            set { height = (value > 0 ? value : 0); }
        }

        public double Weight
        {
            get => weight;
            set { weight = (value > 0 ? value : 0); }
        }

        public string HairColour
        {
            get => hairColour;
            set { hairColour = (value?.Length > 1 ? value : "Not Set"); }
        }

        public string Comment
        {
            get => comment;
            set { comment = (value?.Length > 1 ? value : "No Comments"); }
        }

        public string Username
        {
            get => username;
            set { username = (value?.Length > 1 ? value : "Not Set"); }
        }

        public string Password
        {
            get => password;
            set { password =  value; }
        }
        public ObservableCollection<Guid> Assignments { get; set; } = new ObservableCollection<Guid>();


        public ObservableCollection<Expense> Expenses { get; set; } = new ObservableCollection<Expense>();
    }
}