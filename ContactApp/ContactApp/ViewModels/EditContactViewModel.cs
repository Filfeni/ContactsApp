using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class EditContactViewModel
    {
        public ObservableCollection<Contact> ContactList { get; set; }
        public Contact NewContact { get; set; }
        public ICommand EditContactCommand { get; }
        public int IndexSelected { get; }

        public EditContactViewModel(ObservableCollection<Contact> contactList, int indexSelected)
        {
            IndexSelected = indexSelected;
            ContactList = contactList;
            NewContact = contactList[indexSelected];
            EditContactCommand = new Command(EditContact);
        }

        public async void EditContact()
        {
            ContactList[IndexSelected] = NewContact;
            App.Current.MainPage.Navigation.NavigationStack[0].BindingContext = new HomeViewModel(ContactList);
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
