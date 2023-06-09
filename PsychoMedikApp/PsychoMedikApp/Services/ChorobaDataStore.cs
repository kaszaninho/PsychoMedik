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
    public class ChorobaDataStore : AListDataStore<Choroba>
    {
        public ChorobaDataStore()
            : base()
        {
        }

        public override async Task<Choroba> AddItemToService(Choroba item)
        {
            return await _service.ChorobaPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Choroba item)
        {
            return await _service.ChorobaDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Choroba> Find(Choroba item)
        {
            return await _service.ChorobaGETAsync(item.Id);
        }

        public override async Task<Choroba> Find(int id)
        {
            return await _service.ChorobaGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ChorobaAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Choroba item)
        {
            return await _service.ChorobaPUTAsync(item.Id, item).HandleRequest();
        }
    }
}