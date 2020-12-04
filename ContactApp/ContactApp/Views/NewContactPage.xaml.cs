using ContactApp.Models;
using ContactApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewContactPage : ContentPage
    {
        public NewContactPage(ObservableCollection<Contact> contactList)
        {
            
            InitializeComponent();
            BindingContext = new NewContactViewModel(contactList);
        }
    }
}