using CurrysToGo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrysToGo.Controllers
{
    public class HomeController : Controller
    {
        //connect to db context data layer
        CurrysToGoDb _db = new CurrysToGoDb();

        /// <summary>
        /// base function that will enable sorting and search fuctionallity
        /// it will also display all the restaurants called from the home index view
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ActionResult Index(string sortOrder,string searchString)
        {

            var model = from n in _db.Restaurants
                        select n;
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(n => n.Name.Contains(searchString));

            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
            switch (sortOrder)
            {

                case "name_desc":
                    model = model.OrderByDescending(n => n.Name);
                    break;
                    
                default:
                    model = model.OrderBy(n => n.Name);
                    break;
            }            

            return View(model.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// dispose if not used
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);    
        }


    }
}