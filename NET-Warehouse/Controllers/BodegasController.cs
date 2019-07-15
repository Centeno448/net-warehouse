using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NET_Warehouse.Models;

namespace NET_Warehouse.Controllers
{
    public class BodegasController : Controller
    {
        private WarehouseDB db = new WarehouseDB();

        // GET: Bodegas
        public ActionResult Index()
        {
            return View(db.Bodegas.ToList());
        }

        // GET: Bodegas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View(bodega);
        }

        // GET: Bodegas/Create
        public ActionResult Create()
        {
            ViewBag.PaisBodega = new[] { "Ecuador", "Chile", "Colombia", "Venezuela", "Peru"};
            return View();
        }

        // POST: Bodegas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BodegaID,NombreBodega,PaisBodega")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Bodegas.Add(bodega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bodega);
        }

        // GET: Bodegas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaisBodega = new[] { "Ecuador", "Chile", "Colombia", "Venezuela", "Peru" };
            return View(bodega);
        }

        // POST: Bodegas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BodegaID,NombreBodega,PaisBodega")] Bodega bodega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodega);
        }

        // GET: Bodegas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bodega bodega = db.Bodegas.Find(id);
            if (bodega == null)
            {
                return HttpNotFound();
            }
            return View(bodega);
        }

        // POST: Bodegas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bodega bodega = db.Bodegas.Find(id);
            db.Bodegas.Remove(bodega);
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

        public ActionResult Reporte()
        {
            var bodegas = db.Bodegas.ToList();
            decimal total;
            Dictionary<int, decimal> final = new Dictionary<int, decimal>();
            foreach(var bod in bodegas)
            {
                total = 0;
                foreach(var prod in bod.Productos)
                {
                    total += prod.PrecioProd;
                }
                final.Add(bod.BodegaID, total);
            }

            ViewBag.Bodegas = final;
            return View(bodegas);
        }
    }
}
