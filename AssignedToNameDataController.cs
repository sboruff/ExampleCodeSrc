using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseMaintanenceForms.Models;

namespace DatabaseMaintanenceForms.Controllers
{
    public class AssignedToNameDataController : Controller
    {
        private S1_SDBBEEntities db = new S1_SDBBEEntities();

        // GET: /AssignedToNameData/
        public ActionResult Index()
        {
            return View(db.AssignedToNameDatas.ToList());
        }

        // GET: /AssignedToNameData/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedToNameData assignedtonamedata = db.AssignedToNameDatas.Find(id);
            if (assignedtonamedata == null)
            {
                return HttpNotFound();
            }
            return View(assignedtonamedata);
        }

        // GET: /AssignedToNameData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AssignedToNameData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AssignedToID,AssignedToFullName,DateCreated,DateModified")] AssignedToNameData assignedtonamedata)
        {
            if (ModelState.IsValid)
            {
                db.AssignedToNameDatas.Add(assignedtonamedata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignedtonamedata);
        }

        // GET: /AssignedToNameData/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedToNameData assignedtonamedata = db.AssignedToNameDatas.Find(id);
            if (assignedtonamedata == null)
            {
                return HttpNotFound();
            }
            return View(assignedtonamedata);
        }

        // POST: /AssignedToNameData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AssignedToID,AssignedToFullName,DateCreated,DateModified")] AssignedToNameData assignedtonamedata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedtonamedata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignedtonamedata);
        }

        // GET: /AssignedToNameData/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedToNameData assignedtonamedata = db.AssignedToNameDatas.Find(id);
            if (assignedtonamedata == null)
            {
                return HttpNotFound();
            }
            return View(assignedtonamedata);
        }

        // POST: /AssignedToNameData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AssignedToNameData assignedtonamedata = db.AssignedToNameDatas.Find(id);
            db.AssignedToNameDatas.Remove(assignedtonamedata);
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
