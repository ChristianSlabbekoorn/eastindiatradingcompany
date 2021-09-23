using EastIndia.Helpers;
using EastIndia.Managers;
using EastIndia.Models;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;

[assembly: OwinStartupAttribute(typeof(EastIndia.Startup))]
namespace EastIndia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            DbHelper dbHelper = new DbHelper();

            List<List<Location>> locations = new List<List<Location>>();

            locations.Add(dbHelper.GetAll<Location>(x => x.Name == "Sierra Leone"));
            locations.Add(dbHelper.GetAll<Location>(x => x.Name == "Dakar"));
        }
    }
}
