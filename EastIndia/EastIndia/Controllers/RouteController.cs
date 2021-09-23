using EastIndia.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EastIndia.Controllers
{
    public class RouteController : Controller
    {
        public Route[] CalculateRoute([FromBody] Package body)
        {
            return new Route[] { new Route(), new Route() };
        }

        public bool GenerateFile([FromBody] RouteReport body)
        {
            return true;
        }

        public bool ChangeSeasonalPrice([FromBody] SeasonalPrice body)
        {
            return true;
        }

        public bool ChangeTypePrice([FromBody] PackageTypePrice body)
        {
            return true;
        }

        public RouteDetails[] GetRoutesInfo([FromBody] Package body)
        {
            return new RouteDetails[] { new RouteDetails(), new RouteDetails() };
        }

        /*
        // GET: Route
        public ActionResult Index()
        {
            return View();
        }

        // GET: Route/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Route/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Route/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Route/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Route/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
