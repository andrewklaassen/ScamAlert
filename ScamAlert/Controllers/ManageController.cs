using ScamAlert.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ScamAlert.Controllers
{
    public class ManageController : Controller
    {
        private aklaassenEntities1 db = new aklaassenEntities1();

        // GET: Manage
        public ActionResult Index()
        {
            List<User> a = new List<User>();
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetUser", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@userId", SqlDbType.Int).Value = getUserId();
            sqlConnection1.Open();
            // Create a reader to get a list
            SqlDataReader reader = cmd.ExecuteReader();
            // Create a list using the reader
            while (reader.Read())
            {
                User u = new User();
                u.userName = reader["userName"].ToString();
                u.firstName = reader["firstName"].ToString();
                u.lastName = reader["lastName"].ToString();
                a.Add(u);
            }
            return View(a);
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