using PsychoMedikApp.Services;
using PsychoMedikApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PsychoMedikApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<ChorobaDataStore>();
            DependencyService.Register<HarmonogramDataStore>();
            DependencyService.Register<HistoriaChorobyDataStore>();
            DependencyService.Register<ObjawDataStore>();
            DependencyService.Register<PacjentDataStore>();
            DependencyService.Register<PokojDataStore>();
            DependencyService.Register<PracownikDataStore>();
            DependencyService.Register<StanowiskoDataStore>();
            DependencyService.Register<WizytaDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
