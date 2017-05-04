using ScamAlert.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScamAlert.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Approve()
        {
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetUnapprovedScams", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                sqlConnection1.Open();
            }
            catch (Exception e)
            {
                return RedirectToAction("IndexError", "Home");
            }
            // Use a reader to get a list
            SqlDataReader reader = cmd.ExecuteReader();
            List<ScamUnapproved> scamList = new List<ScamUnapproved>();
            // Create a list using the reader
            while (reader.Read())
            {
                ScamUnapproved scam = new ScamUnapproved();
                scam.scamId = int.Parse(Convert.ToString(reader["scamId"]));
                scam.scamName = reader["scamName"].ToString();
                scam.description = reader["description"].ToString();
                scam.datePosted = DateTime.Parse(reader["datePosted"].ToString());
                scam.userName = reader["userName"].ToString();
               
                scamList.Add(scam);
            }

            sqlConnection1.Close();
            return View(scamList.ToList());
        }
        public ActionResult ApproveScam(int? scamId)
        {
            SqlConnection sql1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspApproveScam", sql1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@scamId", SqlDbType.VarChar).Value = scamId;
            sql1.Open();
            cmd.ExecuteNonQuery();
            return RedirectToAction("Approve");
        }
    }
}