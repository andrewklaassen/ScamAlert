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
    public class ScamsController : Controller
    {
        private aklaassenEntities1 db = new aklaassenEntities1();
        
        [Authorize]
        // GET: Scams/Create
        public ActionResult Create()
        {
            ViewBag.firstReportedBy = new SelectList(db.Users, "userId", "userName");
            return View();
        }

        // POST: Scams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "scamId,scamName,description,datePosted,firstReportedBy,latitude,longitude")] Scam scam)
        {
            int userId = getUserId();
            db.uspAddAScam(scam.scamName,scam.description, getUserId(),scam.latitude, scam.longitude );
            return RedirectToAction("Index", "Home");
        }

        // GET: Scams/Edit/5
        public ActionResult Edit(int id)
        {
            Scam scam = db.Scams.Find(id);
            if (scam == null)
            {
                return HttpNotFound();
            }
            ViewBag.firstReportedBy = new SelectList(db.Users, "userId", "userName", scam.firstReportedBy);
            return View(scam);
        }

        // POST: Scams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "scamId,scamName,description,datePosted,firstReportedBy")] Scam scam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.firstReportedBy = new SelectList(db.Users, "userId", "userName", scam.firstReportedBy);
            return View(scam);
        }

        // GET: Scams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scam scam = db.Scams.Find(id);
            if (scam == null)
            {
                return HttpNotFound();
            }
            return View(scam);
        }

        // POST: Scams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scam scam = db.Scams.Find(id);
            db.Scams.Remove(scam);
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

        private int getUserId()
        {
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetUserId", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = User.Identity.Name;
            sqlConnection1.Open();
            int count = 0;
            count = (Int32)cmd.ExecuteScalar();
            sqlConnection1.Close();
            return count;
        }
        public ActionResult Map()
        {
            
            return View();

        }
        public JsonResult getLocations() {
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetLocations", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            sqlConnection1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Location> locList = new List<Location>();
            // Create a list using the reader
            while (reader.Read())
            {
                Location loc = new Location();
                try
                {
                    loc.longitude = double.Parse(Convert.ToString(reader["longitude"]));
                    loc.latitude = double.Parse(Convert.ToString(reader["latitude"]));
                }
                catch (Exception e)
                {
                    //Skip because null objects
                }
                locList.Add(loc);
            }
            sqlConnection1.Close();
            return Json(locList, JsonRequestBehavior.AllowGet);
        }
    }
}
