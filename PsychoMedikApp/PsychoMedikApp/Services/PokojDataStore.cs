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
    public class PokojDataStore : AListDataStore<Pokoj>
    {
        public PokojDataStore()
        {
        }

        public override async Task<Pokoj> AddItemToService(Pokoj item)
        {
            return await _service.PokojPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Pokoj item)
        {
            return await _service.PokojDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Pokoj> Find(Pokoj item)
        {
            return await _service.PokojGETAsync(item.Id);
        }

        public override async Task<Pokoj> Find(int id)
        {
            return await _service.PokojGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.PokojAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Pokoj item)
        {
            return await _service.PokojPUTAsync(item.Id, item).HandleRequest();
        }
    }
}