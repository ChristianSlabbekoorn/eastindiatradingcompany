using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using EastIndia.Models;
using EastIndia.Models.Dtos;

namespace EastIndia.Integrations
{
    public class IntegrationService
    {
        public List<ExternalRouteDetails> GetAllRoutes(ExternalPackage package, Vendor vendor)
        {
            try
            {
                var handler = new WinHttpHandler();
                var client = new HttpClient(handler);
                
                var uri = vendor == Vendor.TelstarLogistics ?
                    "https://wa2-tl-dk1.azurewebsites.net/api/getRoutesInfo" :
                    "http://wa-oa-dk1.azurewebsites.net/api/integration";

                var json = JsonConvert.SerializeObject(package);
                var request = new HttpRequestMessage
                {
                    Method = vendor == Vendor.TelstarLogistics ? HttpMethod.Post : HttpMethod.Get,
                    RequestUri = new Uri(uri),
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                };

                var response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<ExternalRouteDetails>>(content);
            }
            catch (Exception ex)
            {
                return new List<ExternalRouteDetails>();
            }
        }
    }
}