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
    public class HistoriaChorobyDataStore : AListDataStore<HistoriaChoroby>
    {
        public HistoriaChorobyDataStore()
            : base()
        {
        }

        public override async Task<HistoriaChoroby> AddItemToService(HistoriaChoroby item)
        {
            return await _service.HistoriaChorobyPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(HistoriaChoroby item)
        {
            return await _service.HistoriaChorobyDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<HistoriaChoroby> Find(HistoriaChoroby item)
        {
            return await _service.HistoriaChorobyGETAsync(item.Id);
        }

        public override async Task<HistoriaChoroby> Find(int id)
        {
            return await _service.HistoriaChorobyGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.HistoriaChorobyAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(HistoriaChoroby item)
        {
            return await _service.HistoriaChorobyPUTAsync(item.Id, item).HandleRequest();
        }
    }
}