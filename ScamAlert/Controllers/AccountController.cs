using ScamAlert.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Web.Security;

namespace ScamAlert.Controllers
{
    public class AccountController : Controller
    {
        private aklaassenEntities1 sse = new aklaassenEntities1();

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ScamAlert.Models.User c)
        {
            // Compute the hash
            byte[] data = System.Text.Encoding.UTF8.GetBytes(c.passwordHash + "abc123lkj");
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.UTF8.GetString(data);
            // Open a Sql connection
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspVerifyUser", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CurrentUser", SqlDbType.VarChar).Value = c.userName;
            cmd.Parameters.Add("@CurrentHash", SqlDbType.VarChar).Value = hash;
            sqlConnection1.Open();
            int count = 0;
            count = (Int32)cmd.ExecuteScalar();
            // If count is 0 then the username or password is wrong
            if (count == 1)
            {
                FormsAuthentication.SetAuthCookie(c.userName, false);
                SqlCommand cm = new SqlCommand("uspGetPoints", sqlConnection1);
                cm.CommandType = CommandType.StoredProcedure;
                int userid = getUserId(c.userName);
                cm.Parameters.Add("@userId", SqlDbType.VarChar).Value = userid;
                int points = 0;
                points = (Int32)cm.ExecuteScalar();
                ViewData["points"] = points;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "<div class=\"alert alert-warning alert-dismissible\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + "Wrong Username or Password" + "</div>";
                return View();
            }
        }

        // Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET Register
        public ActionResult Register()
        {
            return View();
        }

        // POST Register
        [HttpPost]
        public ActionResult Register(User u)
        {
            // Hash the password
            byte[] data = System.Text.Encoding.UTF8.GetBytes(u.passwordHash + "abc123lkj");
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.UTF8.GetString(data);
            // Use Database context to do stored procedure
            try
            {
                sse.uspAddUser(u.userName, u.firstName, u.lastName, hash);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.ToString();
                return View("Register");
            }
            return RedirectToAction("Index", "Home");
        }
        private int getUserId(string username)
        {
            SqlConnection sqlConnection = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspGetUserId", sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
            sqlConnection.Open();
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