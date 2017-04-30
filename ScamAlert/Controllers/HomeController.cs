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
            int userId = getUserId();
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
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
            List<ScamVote> scamList = new List<ScamVote>();
            // Create a list using the reader
            while (reader.Read())
            {
                ScamVote scam = new ScamVote();
                scam.scamId = int.Parse(Convert.ToString(reader["scamId"]));
                scam.scamName = reader["scamName"].ToString();
                scam.description = reader["description"].ToString();
                scam.datePosted = DateTime.Parse(reader["datePosted"].ToString());
                scam.firstReportedBy = int.Parse(Convert.ToString(reader["firstReportedBy"]));
                scam.votes = int.Parse(Convert.ToString(reader["votes"]));
                try
                {
                    scam.vote = Convert.ToInt16(reader["vote"]);
                }
                catch (Exception)
                {

                    scam.vote = 0;
                }
                scamList.Add(scam);
            }
            
            sqlConnection1.Close();
            return View(scamList.ToList());
        }
        public ActionResult IndexSearch(String search)
        {
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetScamsSearch", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            int userId = getUserId();
            cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            if(search == null)
            {
                search = "";
            }
            cmd.Parameters.Add("@Search", SqlDbType.VarChar).Value = search;
            sqlConnection1.Open();
            // Use a reader to get a list
            SqlDataReader reader = cmd.ExecuteReader();
            List<ScamVote> scamList = new List<ScamVote>();
            // Create a list using the reader
            while (reader.Read())
            {
                ScamVote scam = new ScamVote();
                scam.scamId = int.Parse(Convert.ToString(reader["scamId"]));
                scam.scamName = reader["scamName"].ToString();
                scam.description = reader["description"].ToString();
                scam.datePosted = DateTime.Parse(reader["datePosted"].ToString());
                scam.firstReportedBy = int.Parse(Convert.ToString(reader["firstReportedBy"]));
                scam.votes = int.Parse(Convert.ToString(reader["votes"]));
                try
                {
                    scam.vote = int.Parse(Convert.ToString(reader["vote"]));
                }
                catch (Exception e)
                {
                    scam.vote = 0;
                }
                scamList.Add(scam);
            }
            sqlConnection1.Close();
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
                if (User.Identity.IsAuthenticated == false)
                {
                    ViewData["previous"] = false;
                }
                else
                {
                    SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
                    SqlCommand cmd2 = new SqlCommand("uspCheckForPreviousScamReport", sqlConnection1);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@userId", SqlDbType.VarChar).Value = getUserId();
                    cmd2.Parameters.Add("@scamId", SqlDbType.VarChar).Value = scamId;
                    sqlConnection1.Open();
                    int count = 0;
                    count = (Int32)cmd2.ExecuteScalar();
                    if (count == 1)
                    {
                        ViewData["previous"] = true;
                    }
                    else
                    {
                        ViewData["previous"] = false;
                    }
                }
                //Return the view
                return View(modelList);
            }
            catch (Exception e)
            {
                return RedirectToAction("IndexError", "Home");
            }
        }
        [Authorize]
        public ActionResult Upvote(int scamId)
        {
            db.uspVote(getUserId(), scamId, true);
            return RedirectToAction("IndexSearch", "Home", "");
        }
        [Authorize]
        public ActionResult Downvote(int scamId)
        {
            db.uspVote(getUserId(), scamId, false);
            return RedirectToAction("IndexSearch", "Home", "");
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
                scamreport.scamId = scamId;
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
            try
            {
                count = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
    }
}