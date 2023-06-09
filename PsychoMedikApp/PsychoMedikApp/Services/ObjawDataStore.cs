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
    public class ObjawDataStore : AListDataStore<Objaw>
    {
        public ObjawDataStore()
            : base()
        {
        }

        public override async Task<Objaw> AddItemToService(Objaw item)
        {
            return await _service.ObjawPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Objaw item)
        {
            return await _service.ObjawDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Objaw> Find(Objaw item)
        {
            return await _service.ObjawGETAsync(item.Id);
        }

        public override async Task<Objaw> Find(int id)
        {
            return await _service.ObjawGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ObjawAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Objaw item)
        {
            return await _service.ObjawPUTAsync(item.Id, item).HandleRequest();
        }
    }
}