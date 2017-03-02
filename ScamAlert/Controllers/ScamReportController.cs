using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScamAlert.Models;
using System.Data.SqlClient;

namespace ScamAlert.Controllers
{
    public class ScamReportController : Controller
    {
        private aklaassenEntities1 db = new aklaassenEntities1();

        // GET: ScamReport/Create
        public ActionResult CreateScamReport()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateScamReport(ScamReport scamReport)
        {
            int userId = getUserId();
            int scamId = Convert.ToInt32(Session["scamId"]);
            db.uspAddAScamReport(userId, scamId, scamReport.report);
            return RedirectToAction("View", "Home", scamId);
        }

        // GET: ScamReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScamReport scamReport = db.ScamReports.Find(Convert.ToInt32(Session["scamId"]));
            if (scamReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.scamId = new SelectList(db.Scams, "scamId", "scamName", Convert.ToInt32(Session["scamId"]));
            ViewBag.byUserId = new SelectList(db.Users, "userId", "userName", getUserId());
            return View(scamReport);
        }

        // POST: ScamReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scamReportId,scamId,byUserId,report,timePosted")] ScamReport scamReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scamReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.scamId = new SelectList(db.Scams, "scamId", "scamName", scamReport.scamId);
            ViewBag.byUserId = new SelectList(db.Users, "userId", "userName", scamReport.byUserId);
            return View(scamReport);
        }

        // GET: ScamReport/Delete/5
        public ActionResult Delete(int id)
        {
            ScamReport scamReport = db.ScamReports.Find(id);
            if (scamReport == null)
            {
                return HttpNotFound();
            }
            return View(scamReport);
        }

        // POST: ScamReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScamReport scamReport = db.ScamReports.Find(id);
            db.ScamReports.Remove(scamReport);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private int getUserId()
        {
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetUserId", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = User.Identity.Name;
            sqlConnection1.Open();
            int count = 0;
            count = (Int32)cmd.ExecuteScalar();
            return count;
        }
    }
}
