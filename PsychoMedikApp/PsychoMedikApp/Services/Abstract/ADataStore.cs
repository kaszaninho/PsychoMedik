using PsychoMedik.Service.Reference;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PsychoMedikApp.Services.Abstract
{
    public abstract class ADataStore
    {
        public PsychoMedikService _service;
        public ADataStore()
        {
            //Use this code to test locally - localhost do not have certificate
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);
            _service = new PsychoMedikService("https://localhost:7109", client);
        }
    }
}
