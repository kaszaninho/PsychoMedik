using PsychoMedikApp.ViewModels;
using PsychoMedikApp.Views;
using PsychoMedikApp.Views.ChorobaView;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PsychoMedikApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ChorobaDetailsPage), typeof(ChorobaDetailsPage));
            Routing.RegisterRoute(nameof(NewChorobaPage), typeof(NewChorobaPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}