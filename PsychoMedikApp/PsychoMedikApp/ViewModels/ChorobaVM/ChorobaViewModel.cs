using PsychoMedik.Service.Reference;
using PsychoMedikApp.ViewModels.Abstract;
using PsychoMedikApp.Views.ChorobaView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PsychoMedikApp.ViewModels.ChorobaVM
{
    public class ChorobaViewModel : AListViewModel<Choroba>
    {
        public ChorobaViewModel()
            : base("Choroby")
        {
        }

        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewChorobaPage));
        }

        public override async void OnItemSelected(Choroba item)
        {
            if (item == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(ChorobaDetailsPage)}?{nameof(ChorobaDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}