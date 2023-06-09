using PsychoMedik.Service.Reference;
using PsychoMedikApp.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace PsychoMedikApp.ViewModels.ChorobaVM
{
    public class NewChorobaViewModel : ANewViewModel<Choroba>
    {
        #region Pola
        private string nazwa;
        private string opis;
        #endregion
        #region Właściwości
        public string Nazwa { get => nazwa; set => SetProperty(ref nazwa, value); }
        public string Opis { get => opis; set => SetProperty(ref opis, value); }
        #endregion
        public override Choroba SetItem()
        {
            return new Choroba
            {
                Id = 0,
                CzyAktywny = true,
                DataModyfikacji = DateTime.Now,
                DataUtworzenia = DateTime.Now,
                Opis = this.Opis,
                Nazwa = this.Nazwa,
                HistoriaChorob = null,
                Objawy = null
            };
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(nazwa);
        }
    }
}