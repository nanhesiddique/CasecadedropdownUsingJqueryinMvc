using CasecadingDropdownList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CasecadingDropdownList.Controllers
{
    public class CaseCadeddlController : Controller
    {
        // GET: CaseCadeddl

        tutorialEntities db = new tutorialEntities();
        public ActionResult Index()
        {


            ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");
            return View();
        }
        public List<Country> GetCountryList()
        {
            List<Country> ct = db.Countries.ToList();
            ViewBag.CountryList = new SelectList(ct, "CountryId", "CountryName");
            return ct;
        }
        public ActionResult GetStateList(int CountryId)
        {
            List<State> st = db.States.Where(x => x.CountryId == CountryId).ToList();
            ViewBag.StateOption = new SelectList(st,"StateId","StateName");
            return PartialView("PartialViewOption");
                
        }

    }
}