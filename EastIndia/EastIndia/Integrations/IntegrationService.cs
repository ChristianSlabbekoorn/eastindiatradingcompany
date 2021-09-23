using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using EastIndia.Models;
using EastIndia.Models.Dtos;
using Flurl.Http;
using Package = EastIndia.Models.Dtos.Package;

namespace EastIndia.Integrations
{
    public class IntegrationService
    {
        public List<ExternalRouteDetails> GetAllRoutes(Package package, Vendor vendor)
        {
            try
            {
                var uri = vendor == Vendor.TelstarLogistics ? 
                    "http://wa-eit-dk1.azurewebsites.net/api/getAllRoutes" :
                    "http://wa-oa-dk1.azurewebsites.net/api/getAllRoutes";
                
                var json = JsonConvert.SerializeObject(package);
                var res = uri.PostJsonAsync(json).Result;

                return res.GetJsonAsync<List<ExternalRouteDetails>>().Result;
            }
            catch (Exception ex)
            {
                return new List<ExternalRouteDetails>();
            }
        }
    }
}