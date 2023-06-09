using PsychoMedik.Service.Reference;
using PsychoMedikApp.Helpers;
using PsychoMedikApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychoMedikApp.Services
{
    public class WizytaDataStore : AListDataStore<Wizyta>
    {
        public WizytaDataStore()
            : base()
        {
        }

        public override async Task<Wizyta> AddItemToService(Wizyta item)
        {
            return await _service.WizytaPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Wizyta item)
        {
            return await _service.WizytaDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Wizyta> Find(Wizyta item)
        {
            return await _service.WizytaGETAsync(item.Id);
        }

        public override async Task<Wizyta> Find(int id)
        {
            return await _service.WizytaGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.WizytaAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Wizyta item)
        {
            return await _service.WizytaPUTAsync(item.Id, item).HandleRequest();
        }
    }
}