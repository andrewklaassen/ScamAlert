﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScamAlert.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class aklaassenEntities1 : DbContext
    {
        public aklaassenEntities1()
            : base("name=aklaassenEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<ScamReport> ScamReports { get; set; }
        public virtual DbSet<Scam> Scams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int uspAddAScam(string scamName, string description, Nullable<int> firstReportedBy, Nullable<decimal> latitude, Nullable<decimal> longitude)
        {
            var scamNameParameter = scamName != null ?
                new ObjectParameter("scamName", scamName) :
                new ObjectParameter("scamName", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var firstReportedByParameter = firstReportedBy.HasValue ?
                new ObjectParameter("firstReportedBy", firstReportedBy) :
                new ObjectParameter("firstReportedBy", typeof(int));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("latitude", latitude) :
                new ObjectParameter("latitude", typeof(decimal));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("longitude", longitude) :
                new ObjectParameter("longitude", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddAScam", scamNameParameter, descriptionParameter, firstReportedByParameter, latitudeParameter, longitudeParameter);
        }
    
        public virtual int uspAddUser(string userName, string firstName, string lastName, string passwordHash)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("firstName", firstName) :
                new ObjectParameter("firstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("lastName", lastName) :
                new ObjectParameter("lastName", typeof(string));
    
            var passwordHashParameter = passwordHash != null ?
                new ObjectParameter("passwordHash", passwordHash) :
                new ObjectParameter("passwordHash", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddUser", userNameParameter, firstNameParameter, lastNameParameter, passwordHashParameter);
        }
    
        public virtual ObjectResult<uspGetScams_Result> uspGetScams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetScams_Result>("uspGetScams");
        }
    
        public virtual int uspAddAScamReport(Nullable<int> userId, Nullable<int> scamId, string report)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var scamIdParameter = scamId.HasValue ?
                new ObjectParameter("scamId", scamId) :
                new ObjectParameter("scamId", typeof(int));
    
            var reportParameter = report != null ?
                new ObjectParameter("report", report) :
                new ObjectParameter("report", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAddAScamReport", userIdParameter, scamIdParameter, reportParameter);
        }
    
        public virtual int uspAdminExists(string username, ObjectParameter isAdmin)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspAdminExists", usernameParameter, isAdmin);
        }
    
        public virtual ObjectResult<uspGetScamReports_Result> uspGetScamReports(Nullable<int> scamId)
        {
            var scamIdParameter = scamId.HasValue ?
                new ObjectParameter("scamId", scamId) :
                new ObjectParameter("scamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetScamReports_Result>("uspGetScamReports", scamIdParameter);
        }
    
        public virtual ObjectResult<Nullable<bool>> uspGetVote(Nullable<int> userId, Nullable<int> scamId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var scamIdParameter = scamId.HasValue ?
                new ObjectParameter("scamId", scamId) :
                new ObjectParameter("scamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<bool>>("uspGetVote", userIdParameter, scamIdParameter);
        }
    
        public virtual int uspUserExists(string username, ObjectParameter isUser)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUserExists", usernameParameter, isUser);
        }
    
        public virtual int uspVerifyUser(string currentUser, string currentHash)
        {
            var currentUserParameter = currentUser != null ?
                new ObjectParameter("CurrentUser", currentUser) :
                new ObjectParameter("CurrentUser", typeof(string));
    
            var currentHashParameter = currentHash != null ?
                new ObjectParameter("CurrentHash", currentHash) :
                new ObjectParameter("CurrentHash", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspVerifyUser", currentUserParameter, currentHashParameter);
        }
    
        public virtual int uspVote(Nullable<int> userId, Nullable<int> scamId, Nullable<bool> vote)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var scamIdParameter = scamId.HasValue ?
                new ObjectParameter("scamId", scamId) :
                new ObjectParameter("scamId", typeof(int));
    
            var voteParameter = vote.HasValue ?
                new ObjectParameter("vote", vote) :
                new ObjectParameter("vote", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspVote", userIdParameter, scamIdParameter, voteParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> uspCheckForPreviousScamReport(Nullable<int> userId, Nullable<int> scamId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            var scamIdParameter = scamId.HasValue ?
                new ObjectParameter("scamId", scamId) :
                new ObjectParameter("scamId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("uspCheckForPreviousScamReport", userIdParameter, scamIdParameter);
        }
    
        public virtual ObjectResult<uspGetScamsSearch_Result> uspGetScamsSearch(string search, Nullable<int> userId)
        {
            var searchParameter = search != null ?
                new ObjectParameter("Search", search) :
                new ObjectParameter("Search", typeof(string));
    
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetScamsSearch_Result>("uspGetScamsSearch", searchParameter, userIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> uspGetUserId(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("uspGetUserId", userNameParameter);
        }
    
        public virtual ObjectResult<uspGetUser_Result> uspGetUser(Nullable<int> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("userId", userId) :
                new ObjectParameter("userId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetUser_Result>("uspGetUser", userIdParameter);
        }
    }
}
