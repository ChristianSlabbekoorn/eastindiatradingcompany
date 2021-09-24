using EastIndia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EastIndia.Services;
using Newtonsoft.Json;

namespace EastIndia.Controllers
{
    public class GetAllRoutesController : ApiController
    {
        private readonly PriceCalculator _priceCalculator = new PriceCalculator();
        
        [HttpPost]
        public HttpResponseMessage GetAllRoutes([FromBody] Package package)
        {
            if(package.IsRecorded || package.IsCautious) 
                return new HttpResponseMessage(HttpStatusCode.NoContent);

            const string tanger = "Tanger";
            const string tunis = "Tunis";
            const string cairo = "Cairo";
            const string suakin = "Suakin";
            const string kapGuardafui = "Kap Guardafui";
            const string mozambique = "Mozambique";
            const string tamatave = "Tamatave";
            const string kapStMarie = "Kap St.Marie";
            const string kapstaden = "Kapstaden";
            const string hvalbugten = "Hvalbugten";
            const string slaveKysten = "Slavekysten";
            const string guldKysten = "Guld Kysten";
            const string sierraLeone = "Sierra Leone";
            const string stHelena = "St.Helena";
            const string deKanariskeOeer = "De Kanariske Oeer";
            const string dakar = "Dakar";

            var list = new List<ExternalRouteDetails>
            {
                new ExternalRouteDetails()
                {
                    Start = tanger,
                    Stop = tunis,
                    Price = _priceCalculator.CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()

                },
                new ExternalRouteDetails()
                {
                    Start = tunis,
                    Stop = cairo,
                    Price = _priceCalculator.CalculatePrice(5, package).ToString(),
                    Duration = CalculateDuration(5).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = cairo,
                    Stop = suakin,
                    Price = _priceCalculator.CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = suakin,
                    Stop = kapGuardafui,
                    Price = _priceCalculator.CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapGuardafui,
                    Stop = mozambique,
                    Price = _priceCalculator.CalculatePrice(8, package).ToString(),
                    Duration = CalculateDuration(8).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapGuardafui,
                    Stop = tamatave,
                    Price = _priceCalculator.CalculatePrice(8, package).ToString(),
                    Duration = CalculateDuration(8).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = mozambique,
                    Stop = kapStMarie,
                    Price = _priceCalculator.CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapStMarie,
                    Stop = kapstaden,
                    Price = _priceCalculator.CalculatePrice(8, package).ToString(),
                    Duration = CalculateDuration(8).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapstaden,
                    Stop = hvalbugten,
                    Price = _priceCalculator.CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = hvalbugten,
                    Stop = slaveKysten,
                    Price = _priceCalculator.CalculatePrice(9, package).ToString(),
                    Duration = CalculateDuration(9).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = hvalbugten,
                    Stop = guldKysten,
                    Price = _priceCalculator.CalculatePrice(11, package).ToString(),
                    Duration = CalculateDuration(11).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = slaveKysten,
                    Stop = guldKysten,
                    Price = _priceCalculator.CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = sierraLeone,
                    Stop = guldKysten,
                    Price = _priceCalculator.CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = hvalbugten,
                    Stop = stHelena,
                    Price = _priceCalculator.CalculatePrice(10, package).ToString(),
                    Duration = CalculateDuration(10).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapstaden,
                    Stop = stHelena,
                    Price = _priceCalculator.CalculatePrice(9, package).ToString(),
                    Duration = CalculateDuration(9).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = sierraLeone,
                    Stop = stHelena,
                    Price = _priceCalculator.CalculatePrice(11, package).ToString(),
                    Duration = CalculateDuration(11).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = sierraLeone,
                    Stop = dakar,
                    Price = _priceCalculator.CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = dakar,
                    Stop = deKanariskeOeer,
                    Price = _priceCalculator.CalculatePrice(5, package).ToString(),
                    Duration = CalculateDuration(5).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = tanger,
                    Stop = deKanariskeOeer,
                    Price = _priceCalculator.CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                }
            };

            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(list),
                    System.Text.Encoding.UTF8, "application/json")
            };

        }

        private int CalculateDuration(int numberOfHops)
        {
            return numberOfHops * 12 * 60;
        }
    }
}
