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
    public class StanowiskoDataStore : AListDataStore<Stanowisko>
    {
        public StanowiskoDataStore()
        {
        }

        public override async Task<Stanowisko> AddItemToService(Stanowisko item)
        {
            return await _service.StanowiskoPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Stanowisko item)
        {
            return await _service.StanowiskoDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Stanowisko> Find(Stanowisko item)
        {
            return await _service.StanowiskoGETAsync(item.Id);
        }

        public override async Task<Stanowisko> Find(int id)
        {
            return await _service.StanowiskoGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.StanowiskoAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Stanowisko item)
        {
            return await _service.StanowiskoPUTAsync(item.Id, item).HandleRequest();
        }
    }
}