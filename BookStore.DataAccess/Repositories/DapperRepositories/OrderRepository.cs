using BookStore.DataAccess.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using static BookStore.DataAccess.Entities.Enums.Enums;
using BookStore.DataAccess.Models.OrderItems;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Base;

namespace BookStore.DataAccess.Repositories.DapperRepositories
{
    public class Response
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public TypePrintingEdition Type { get; set; }
        public string Title { get; set; }
        public long Count { get; set; }
        public decimal Amount { get; set; }
    }

    public class OrderRepository : BaseDapperRepository<Order>, IOrderRepository
    {
        string connectionString = "Server=DESKTOP-4C8DBJI;Database=BookStore;Trusted_Connection=True;MultipleActiveResultSets=true";

        public async Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel)
        {
            List<Response> orders = new List<Response>();
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
                    ) AS b ON o.Id = b.OrderId;"
                );
                orders = db.Query<Response>(str.ToString()).ToList();
            }

            /*SELECT o.Id, o.CreationDate, o.UserName, o.Email, b.Type, b.Title, b.Count, o.Amount FROM
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

SELECT COUNT(Orders.Id) FROM Orders 
	                    INNER JOIN AspNetUsers ON Orders.UserId = AspNetUsers.Id
	                    WHERE Orders.IsRemoved = 0
	                    AND AspNetUsers.FirstName LIKE '%%' OR AspNetUsers.LastName LIKE '%%' OR AspNetUsers.Email LIKE '%%';*/

            var resulModel = new OrderModel();
            resulModel.Count = 5;

            resulModel.Items = orders.GroupBy(x => x.Id).Select(o =>
            o.Select(
                x => new OrderModelItem()
                {
                    Id = x.Id,
                    Date = x.CreationDate,
                    UserName = x.UserName,
                    UserEmail = x.Email,
                    OrderItems = o.Select(
                        x => new OrderItemModelItem()
                        {
                            Title = x.Title,
                            Count = x.Count,
                            Type = x.Type
                        }).ToList(),
                    OrderAmount = x.Amount
                }
                ).FirstOrDefault()
            ).ToList();

            return resulModel;
        }
    }
}
