using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for AddModel.xaml
    /// </summary>
    public partial class AddModel : Window, System.Windows.Markup.IComponentConnector
    {

        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBName;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBPhone;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBAddress;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBHeight;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBWeight;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBHairColour;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBUsername;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBPassword;
        //[SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        //internal TextBox tBlComment;



        public string Name          { get; set; }                   // Navn:"/>
        public int    PhoneNumber   { get; set; }                   // Telefon:"/>
        public string Address       { get; set; }                   // Adresse:"/>
        public double Height        { get; set; }                   // Højde:"/>
        public double Weight        { get; set; }                   // Vægt:"/>
        public string HairColour    { get; set; }                   // Hårfarve:"/>
        public string Comment       { get; set; }                   // Brugernavn:"/>
        public string Username { get; set; }                        // Adgangskode:"/>      // til webdelen, hvis det kommer til at blive knyttet sammen
        public string Password { get; set; } // Kommentar:"/>        // til webdelen, hvis det kommer til at blive knyttet sammen


                             
        
        public AddModel()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Name = tBName.Text;
            PhoneNumber = Int32.Parse(tBPhone.Text);
            Address = tBAddress.Text;
            Height = double.Parse(tBHeight.Text);
            Weight = double.Parse(tBWeight.Text);
            HairColour = tBHairColour.Text;
            Username = tBUsername.Text;
            Password = Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(tBPassword.Password))); //????
            Comment = tBlComment.Text;

            DialogResult = true;
        }

    }
}
