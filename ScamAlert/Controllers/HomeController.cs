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
            var sCAM = db.Scams;
            return View(sCAM.ToList());
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
    }
}