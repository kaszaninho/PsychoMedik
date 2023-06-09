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
    public class HarmonogramDataStore : AListDataStore<Harmonogram>
    {
        public HarmonogramDataStore()
            : base()
        {
        }

        public override async Task<Harmonogram> AddItemToService(Harmonogram item)
        {
            return await _service.HarmonogramPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Harmonogram item)
        {
            return await _service.HarmonogramDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Harmonogram> Find(Harmonogram item)
        {
            return await _service.HarmonogramGETAsync(item.Id);
        }

        public override async Task<Harmonogram> Find(int id)
        {
            return await _service.HarmonogramGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.HarmonogramAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Harmonogram item)
        {
            return await _service.HarmonogramPUTAsync(item.Id, item).HandleRequest();
        }
    }
}