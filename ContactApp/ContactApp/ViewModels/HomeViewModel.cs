﻿using ContactApp.Models;
using ContactApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ContactApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Contact> ContactList { get; set; }
        public Contact SelectedContact { get; set; }
        public ICommand AddButtonCommand { get; }
        public ICommand MoreButtonCommand { get; }
        public ICommand RemoveButtonCommand { get; }

        public HomeViewModel()
        {
            ContactList = new ObservableCollection<Contact>();
            AddButtonCommand = new Command(GoToNewContactPage);
            RemoveButtonCommand = new Command<Contact>(RemoveContact);
            MoreButtonCommand = new Command<Contact>(MoreOptions);
        }
        public HomeViewModel(ObservableCollection<Contact> contactList)
        {
            ContactList = contactList;
            AddButtonCommand = new Command(GoToNewContactPage);
            RemoveButtonCommand = new Command<Contact>(RemoveContact);
            MoreButtonCommand = new Command<Contact>(MoreOptions);
        }

        public async void GoToNewContactPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewContactPage(ContactList));
        }

        public async void MoreOptions(Contact contact)
        {
            string result = await App.Current.MainPage.DisplayActionSheet(null, "Cancel", null, new string[] { $"Call +1 {contact.PhoneNumber}", "Edit" });
            
            bool? option = result == null || result == "Cancel" ? (bool?)null 
                : (result == $"Call +1 {contact.PhoneNumber}" ? true : false);
            
            switch (option)
            {
                case true:
                    PhoneDialer.Open($"+1{ contact.PhoneNumber}");
                    break;
                case false:
                    int index = ContactList.IndexOf(contact);
                    await App.Current.MainPage.Navigation.PushAsync(new EditContactPage(ContactList, index));
                    break;
                default:
                    break;
            }

        }

        public void RemoveContact(Contact contact)
        {
            ContactList.Remove(contact);
        }
    }
}
