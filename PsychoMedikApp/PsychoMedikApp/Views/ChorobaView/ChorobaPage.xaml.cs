using PsychoMedikApp.ViewModels.ChorobaVM;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsychoMedikApp.Views.ChorobaView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChorobaPage : ContentPage
    {
        private ChorobaViewModel _viewModel;

        public ChorobaPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ChorobaViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        //async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null)
        //        return;

        //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}