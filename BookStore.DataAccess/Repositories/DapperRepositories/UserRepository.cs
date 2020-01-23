using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using BookStore.DataAccess.Entities;
using Dapper;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Text;

namespace BookStore.DataAccess.Repositories.DapperRepositories
{
    public class UserRepository: TestDapper
    {
        string connectionString = "Server=DESKTOP-4C8DBJI;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true";
        public void GetUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var str = new StringBuilder(@"SELECT o.Id, o.CreationDate, o.UserName, o.Email, b.Type, b.Title, b.Count, o.Amount FROM
(
	SELECT Orders.Id, Orders.CreationDate, AspNetUsers.UserName, AspNetUsers.Email, Orders.Amount 
	FROM Orders 
	INNER JOIN AspNetUsers ON Orders.UserId = AspNetUsers.Id
	WHERE Orders.IsRemoved = 0
	AND AspNetUsers.FirstName LIKE '%%' OR AspNetUsers.LastName LIKE '%%' OR AspNetUsers.Email LIKE '%%'
	ORDER BY Orders.Id
	OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY
) AS o
INNER JOIN
(
	SELECT OrderItems.OrderId, PrintingEditions.Type, PrintingEditions.Title, OrderItems.Count 
	FROM OrderItems 
	INNER JOIN PrintingEditions ON PrintingEditions.Id = OrderItems.PrintingEditionId
) AS b ON o.Id = b.OrderId;
");
                var us = db.Query(str.ToString()).ToList();
            }
        }

        public ApplicationUser Get(int id)
        {
            ApplicationUser user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<ApplicationUser>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return user;
        }

        public ApplicationUser Create(ApplicationUser user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                user.Id = 7;
            }
            return user;
        }

        public void Update(ApplicationUser user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
