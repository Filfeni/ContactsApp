using ContactApp.Models;
using ContactApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> ContactList { get; set; }
        public Contact SelectedContact { get; set; }
        public ICommand AddButtonCommand { get; }

        public HomeViewModel()
        {
            ContactList = new ObservableCollection<Contact>();
            AddButtonCommand = new Command(GoToNewContactPage);
        }
        public HomeViewModel(ObservableCollection<Contact> contactList)
        {
            ContactList = contactList;
            AddButtonCommand = new Command(GoToNewContactPage);
        }

        public async void GoToNewContactPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewContactPage(ContactList));
        }
    }
}
