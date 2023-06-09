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
    public class PracownikDataStore : AListDataStore<Pracownik>
    {
        public PracownikDataStore()
            : base()
        {
        }

        public override async Task<Pracownik> AddItemToService(Pracownik item)
        {
            return await _service.PracownikPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Pracownik item)
        {
            return await _service.PracownikDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Pracownik> Find(Pracownik item)
        {
            return await _service.PracownikGETAsync(item.Id);
        }

        public override async Task<Pracownik> Find(int id)
        {
            return await _service.PracownikGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.PracownikAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Pracownik item)
        {
            return await _service.PracownikPUTAsync(item.Id, item).HandleRequest();
        }
    }
}