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
using BookStore.DataAccess.Common.Constants;

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
        private readonly string _connectionString;
        public OrderRepository()
        {
            _connectionString = Constants.DapperConstants.connectionString;
        }

        public async Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel)
        {
            var filter = new StringBuilder(@$"FROM Orders
                        INNER JOIN AspNetUsers ON Orders.UserId = AspNetUsers.Id
                        WHERE Orders.IsRemoved = 0
	                    AND AspNetUsers.UserName LIKE '%{ordersFilterModel.SearchString}%' OR AspNetUsers.Email LIKE '%{ordersFilterModel.SearchString}%' ");

            var resulModel = new OrderModel();
            var orders = new List<Response>();
             var sqlQuery = new StringBuilder(@"SELECT o.Id, o.CreationDate, o.UserName, o.Email, b.Type, b.Title, b.Count, o.Amount FROM
             (
	            SELECT Orders.Id, Orders.CreationDate, AspNetUsers.UserName, AspNetUsers.Email, Orders.Amount ");
            sqlQuery.Append(filter);
            sqlQuery.Append("ORDER BY Orders.Id ");
            sqlQuery.Append(@"OFFSET @pageCount * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY
               ) AS o
                    INNER JOIN
                    (
	                    SELECT OrderItems.OrderId, PrintingEditions.Type, PrintingEditions.Title, OrderItems.Count 
	                    FROM OrderItems 
	                    INNER JOIN PrintingEditions ON PrintingEditions.Id = OrderItems.PrintingEditionId
                    ) AS b ON o.Id = b.OrderId;");
            sqlQuery.Append("SELECT COUNT(Orders.Id) ");
            sqlQuery.Append(filter);

            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                using (var multi = await connection.QueryMultipleAsync(sqlQuery.ToString(),
                    new
                    {
                        pageCount = ordersFilterModel.PageCount,
                        pageSize = ordersFilterModel.PageSize
                    }))
                {
                    orders = (await multi.ReadAsync<Response>()).ToList();
                    resulModel.Count = await multi.ReadFirstAsync<int>();
                }
            }
                                                               
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
