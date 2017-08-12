using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using DbManager.Collections;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using spots;
using spots.DAL.SQLS;
using spots.Models.Identity;

namespace DbManager.SqlContext
{
    internal static class Sql
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static string _password = "MyPassword1.";

        internal static bool DeleteAll()
        {
            const string query = "Delete from AspNetUsers";

            using (var con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Execute(query);
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }

        internal static async Task<bool> PopulateDefault()
        {
            try
            {
                var appManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));

                //UserManagerFactory = () => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

                var user1 = new ApplicationUser
                {
                    Id = "06e33dff-d46c-4f12-825b-78ae2c5c96c2",
                    Email = UserCollection.UEmail1,
                    UserName = UserCollection.UEmail1,
                    EmailConfirmed = true
                };

                var user2 = new ApplicationUser
                {
                    Id = "06e33dff-d46c-4f12-825b-78ae2c5c96c3",
                    UserName = UserCollection.UEmail2,
                    Email = UserCollection.UEmail2,
                    EmailConfirmed = true
                };

                var user3 = new ApplicationUser
                {
                    Id = "06e33dff-d46c-4f12-825b-78ae2c5c96c4",
                    UserName = UserCollection.UEmail3,
                    Email = UserCollection.UEmail3,
                    EmailConfirmed = true
                };

                var result1 = await appManager.CreateAsync(user1, _password);
                var result2 = await appManager.CreateAsync(user2, _password);
                var result3 = await appManager.CreateAsync(user3, _password);

                return result1.Succeeded && result2.Succeeded && result3.Succeeded;
            }
            catch
            {
                return false;
            }
        }
    }
}