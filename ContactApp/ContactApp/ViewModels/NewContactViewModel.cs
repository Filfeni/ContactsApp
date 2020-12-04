using ContactApp.Models;
using ContactApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class NewContactViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> ContactList { get; set; }
        public Contact NewContact { get; set; }
        public ICommand AddContactCommand { get; }
        public ICommand RemoveContactCommand { get; }

        public NewContactViewModel(ObservableCollection<Contact> contactList)
        {
            NewContact = new Contact();
            ContactList = contactList;
            AddContactCommand = new Command(AddContact);
        }

        public async void AddContact()
        {
            ContactList.Add(NewContact);
            App.Current.MainPage.Navigation.NavigationStack[0].BindingContext = new HomeViewModel(ContactList);
            await App.Current.MainPage.Navigation.PopAsync();
            
        }


    }
}
