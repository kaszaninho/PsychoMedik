using PsychoMedikApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace PsychoMedikApp.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class AItemDetailsViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        protected AItemDetailsViewModel()
        {
            CancelCommand = new Command(OnCancel);
            DeleteCommand = new Command(OnDelete);
        }



        public Command DeleteCommand { get; }
        public Command CancelCommand { get; }
        public abstract void LoadProperties(T item);
        private async void OnDelete()
        {
            await DataStore.DeleteItemAsync(itemId);
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }



        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }



        private int itemId;
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }



        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                LoadProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}