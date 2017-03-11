using ScamAlert.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace ScamAlert.Controllers
{
    public class HomeController : Controller
    {
        private aklaassenEntities1 db = new aklaassenEntities1();

        public ActionResult Index()
        {
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetScamsSearch", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = "";
            sqlConnection1.Open();
            // Use a reader to get a list
            SqlDataReader reader = cmd.ExecuteReader();
            List<Scam> scamList = new List<Scam>();
            // Create a list using the reader
            while (reader.Read())
            {
                Scam scam = new Scam();
                scam.scamId = int.Parse(Convert.ToString(reader["scamId"]));
                scam.scamName = reader["scamName"].ToString();
                scam.description = reader["description"].ToString();
                scam.datePosted = DateTime.Parse(reader["datePosted"].ToString());
                scam.firstReportedBy = int.Parse(Convert.ToString(reader["firstReportedBy"]));
                scamList.Add(scam);
            }
            return View(scamList.ToList());
        }
        public ActionResult IndexSearch(String search)
        {
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetScamsSearch", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = search;
            sqlConnection1.Open();
            // Use a reader to get a list
            SqlDataReader reader = cmd.ExecuteReader();
            List<Scam> scamList = new List<Scam>();
            // Create a list using the reader
            while (reader.Read())
            {
                Scam scam = new Scam();
                scam.scamId = int.Parse(Convert.ToString(reader["scamId"]));
                scam.scamName = reader["scamName"].ToString();
                scam.description = reader["description"].ToString();
                scam.datePosted = DateTime.Parse(reader["datePosted"].ToString());
                scam.firstReportedBy = int.Parse(Convert.ToString(reader["firstReportedBy"]));
                scamList.Add(scam);
            }
            return View(scamList.ToList());
        }
        // GET: IndexError
        // Is only called when there is an error and a redirect back to the index
        public ActionResult IndexError()
        {
            ViewBag.Message = "<div class=\"alert alert-info alert-dismissible\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + "No Shopping Cart Items added" + " </div>";
            return View("Index");
        }
        public ActionResult View(int scamId)
        {
            try
            {
                var model = new ScamReports
                {
                    ScamReportss = getScamReportss(scamId),
                    ScamId = scamId   
                };
                List<ScamReports> modelList = new List<ScamReports>();
                modelList.Add(model);
                //Return the view
                return View(modelList);
            }
            catch (Exception e)
            {
                return RedirectToAction("IndexError", "Home");
            }
        }
        
        private List<ScamReport> getScamReportss(int scamId)
        {
            Session["scamId"] = scamId;
            // Open a Sql Connection
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetScamReports", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ScamId", SqlDbType.Int).Value = scamId;
            sqlConnection1.Open();
            // Create a reader to get a list
            SqlDataReader reader = cmd.ExecuteReader();
            List<ScamReport> scamrList = new List<ScamReport>();
            // Create a list using the reader
            while (reader.Read())
            {
                ScamReport scamreport = new ScamReport();
                scamreport.report = reader["report"].ToString();
                scamreport.timePosted = DateTime.Parse(reader["timePosted"].ToString());
                scamreport.User = new User();
                scamreport.User.userName = reader["userName"].ToString();
                scamrList.Add(scamreport);
            }
            sqlConnection1.Close();
            return scamrList;
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