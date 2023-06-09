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
    public class PacjentDataStore : AListDataStore<Pacjent>
    {
        public PacjentDataStore()
            : base()
        {
        }

        public override async Task<Pacjent> AddItemToService(Pacjent item)
        {
            return await _service.PacjentPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Pacjent item)
        {
            return await _service.PacjentDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Pacjent> Find(Pacjent item)
        {
            return await _service.PacjentGETAsync(item.Id);
        }

        public override async Task<Pacjent> Find(int id)
        {
            return await _service.PacjentGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.PacjentAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Pacjent item)
        {
            return await _service.PacjentPUTAsync(item.Id, item).HandleRequest();
        }
    }
}