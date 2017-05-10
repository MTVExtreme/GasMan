using GasMan.Data;
using GasMan.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GasMan.Web.Controllers
{
    public class GasPriceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GasPrice
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                GasPriceList();

            }


            var qry = from q in db.GasPrices
                      select new IndexViewListModel
                      {
                          Date = q.Date,
                          US_Average = q.US_Average,
                          Midwest_Average = q.Midwest_Average,

                      };

            return View(qry);
            //db.GasPrices.ToList()
        }

        private void GasPriceList()
        {
            var query = from g in db.GasPrices
                        select g.Date;

            List<DateTime> dateListZ = query.ToList();
            List<string> dateList = new List<string>();

            foreach (var d in dateListZ)
            {
                var current = d.ToString("MMM-dd-yyyy");
                dateList.Add(current);
            }

            var usQuery = from g in db.GasPrices
                            select g.US_Average;
            var midwestQuery = from g in db.GasPrices
                          select g.Midwest_Average;

            List<double> usList = usQuery.ToList();
            List<double> MidwestList = midwestQuery.ToList();

            ViewBag.UsAverage = usList;
            ViewBag.MidwestAverage = MidwestList;
            ViewBag.Date = dateList;
        }

        // GET: GasPrice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RetailPrice retailPrice = db.GasPrices.Find(id);
            if (retailPrice == null)
            {
                return HttpNotFound();
            }
            return View(retailPrice);
        }

        // GET: GasPrice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GasPrice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,US_Average,Midwest_Average,Speedway_Average,BP_Average,Shell_Average")] RetailPrice retailPrice)
        {
            if (ModelState.IsValid)
            {
                db.GasPrices.Add(retailPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(retailPrice);
        }


        public ActionResult PriceCalculator(PriceCalculatorViewModel model)
        {
            
            var usPrice = db.GasPrices.OrderByDescending(p => p.ID).FirstOrDefault().US_Average;
            var midwestPrice = db.GasPrices.OrderByDescending(p => p.ID).FirstOrDefault().Midwest_Average;
            var date = db.GasPrices.OrderByDescending(p => p.ID).FirstOrDefault().Date;



            var qry = from q in db.GasPrices
                      select new PriceCalculatorViewModel
                      {
                          Date = date,
                          US_Average = usPrice,
                          Midwest_Average = midwestPrice,

                      };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PriceCalculator(bool? post, PriceCalculatorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usPrice = db.GasPrices.OrderByDescending(p => p.ID).FirstOrDefault().US_Average;
                var midwestPrice = db.GasPrices.OrderByDescending(p => p.ID).FirstOrDefault().Midwest_Average;
                var date = db.GasPrices.OrderByDescending(p => p.ID).FirstOrDefault().Date;

                model.Midwest_Average = midwestPrice;
                model.US_Average = usPrice;

                ViewBag.Mileage = model.GasMileage;
                ViewBag.Miles = model.MilesDriven;
                ViewBag.Tank = model.TankSize;
                ViewBag.US = model.PriceUS;
                ViewBag.Midwest = model.PriceMidwest;


                var qry = from q in db.GasPrices
                          select new PriceCalculatorViewModel
                          {
                              Date = date,
                              US_Average = usPrice,
                              Midwest_Average = midwestPrice,

                          };


                return View(model);
            }
            else {
                return View();
            }
            
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
