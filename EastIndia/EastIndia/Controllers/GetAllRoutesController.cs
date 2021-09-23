using EastIndia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EastIndia.Controllers
{
    public class GetAllRoutesController : ApiController
    {
        [HttpPost]
        public IEnumerable<ExternalRouteDetails> GetAllRoutes([FromBody] Package package)
        {
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
            const string slaveKysten = "Slave-Kysten";
            const string guldKysten = "Guld-Kysten";
            const string sierraLeone = "Sierra Leone";
            const string stHelena = "St.Helena";
            const string deKanariskeOeer = "De Kanariske Oeer";
            const string dakar = "Dakar";

            return new List<ExternalRouteDetails>
            {
                new ExternalRouteDetails()
                {
                    Start = tanger,
                    Stop = tunis,
                    Price = CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()

                },
                new ExternalRouteDetails()
                {
                    Start = tunis,
                    Stop = cairo,
                    Price = CalculatePrice(5, package).ToString(),
                    Duration = CalculateDuration(5).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = cairo,
                    Stop = suakin,
                    Price = CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = suakin,
                    Stop = kapGuardafui,
                    Price = CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapGuardafui,
                    Stop = mozambique,
                    Price = CalculatePrice(8, package).ToString(),
                    Duration = CalculateDuration(8).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapGuardafui,
                    Stop = tamatave,
                    Price = CalculatePrice(8, package).ToString(),
                    Duration = CalculateDuration(8).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = mozambique,
                    Stop = kapStMarie,
                    Price = CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapStMarie,
                    Stop = kapstaden,
                    Price = CalculatePrice(8, package).ToString(),
                    Duration = CalculateDuration(8).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapstaden,
                    Stop = hvalbugten,
                    Price = CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = hvalbugten,
                    Stop = slaveKysten,
                    Price = CalculatePrice(9, package).ToString(),
                    Duration = CalculateDuration(9).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = hvalbugten,
                    Stop = guldKysten,
                    Price = CalculatePrice(11, package).ToString(),
                    Duration = CalculateDuration(11).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = slaveKysten,
                    Stop = guldKysten,
                    Price = CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = sierraLeone,
                    Stop = guldKysten,
                    Price = CalculatePrice(4, package).ToString(),
                    Duration = CalculateDuration(4).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = hvalbugten,
                    Stop = stHelena,
                    Price = CalculatePrice(10, package).ToString(),
                    Duration = CalculateDuration(10).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = kapstaden,
                    Stop = stHelena,
                    Price = CalculatePrice(9, package).ToString(),
                    Duration = CalculateDuration(9).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = sierraLeone,
                    Stop = stHelena,
                    Price = CalculatePrice(11, package).ToString(),
                    Duration = CalculateDuration(11).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = sierraLeone,
                    Stop = dakar,
                    Price = CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = dakar,
                    Stop = deKanariskeOeer,
                    Price = CalculatePrice(5, package).ToString(),
                    Duration = CalculateDuration(5).ToString()
                },
                new ExternalRouteDetails()
                {
                    Start = tanger,
                    Stop = deKanariskeOeer,
                    Price = CalculatePrice(3, package).ToString(),
                    Duration = CalculateDuration(3).ToString()
                }
            };
            
        }
        private int CalculateDuration(int numberOfHops)
        {
            return numberOfHops * 12 * 60;
        }

        private int CalculatePrice(int numberOfHops, Package package)
        {
            return 2137;
        }
    }
}
