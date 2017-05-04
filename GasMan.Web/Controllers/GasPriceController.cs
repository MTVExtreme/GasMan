using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GasMan.Data;

namespace GasMan.Web.Controllers
{
    public class GasPriceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GasPrice
        public ActionResult Index()
        {
            return View(db.GasPrices.ToList());
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

        // GET: GasPrice/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: GasPrice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,US_Average,Midwest_Average,Speedway_Average,BP_Average,Shell_Average")] RetailPrice retailPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retailPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(retailPrice);
        }

        // GET: GasPrice/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: GasPrice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RetailPrice retailPrice = db.GasPrices.Find(id);
            db.GasPrices.Remove(retailPrice);
            db.SaveChanges();
            return RedirectToAction("Index");
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
