using ScamAlert.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace ScamAlert
{
    public class MyRoleProvider : RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string userName)
        {
            string[] role = new string[1];
            aklaassenEntities1 sse = new aklaassenEntities1();
            int isAdmin = 0;
            int isUser = 0;
            SqlConnection sqlConnection1 = new SqlConnection("data source=cs.cofo.edu;initial catalog=aklaassen;persist security info=True;user id=aklaas01;password=paint123;");
            SqlCommand cmd = new SqlCommand("uspAdminExists", sqlConnection1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
            SqlCommand cmd2 = new SqlCommand("uspUserExists", sqlConnection1);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;

            try
            {
                sqlConnection1.Open();
                isAdmin = (int)cmd.ExecuteScalar();
                isUser = (int)cmd2.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failure");
            }
            sqlConnection1.Close();
            if (isAdmin == 1)
            {
                string rolea = "A";
                role[0] = rolea;
                return role;
            }
            if (isUser == 1)
            {
                string rolec = "U";
                role[0] = rolec;
                return role;
            }
            return role;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}