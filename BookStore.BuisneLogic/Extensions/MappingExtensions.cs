using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Models.Users;
using BookStore.DataAccess.Entities.Base;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions
{
    public static class MappingExtensions
    {
        public static UserModelItem Mapping(this ApplicationUser user)
        {
            return new UserModelItem()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                LastName = user.LastName,
                FirstName = user.FirstName
            };
        }

        public static PrintingEditionModelItem Mapping(this PrintingEdition printingEditionModelItem)
        {
            return new PrintingEditionModelItem()
            {
                Id = printingEditionModelItem.Id,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Type = printingEditionModelItem.Type,
            };
        }

        public static PrintingEditionModelItem Mapping(this BookStore.DataAccess.Models.PrintingEditions.PrintingEditionModelItem printingEditionModelItem)
        {
            return new PrintingEditionModelItem()
            {
                Id = printingEditionModelItem.Id,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Type = printingEditionModelItem.Type,
                AuthorsNames = printingEditionModelItem.AuthorsNames
            };
        }

        public static AuthorModelItem Mapping(this Author author)
        {
            return new AuthorModelItem()
            {
                Id = author.Id,
                Name = author.Name
            };
        }

        public static AuthorModelItem Mapping(this BookStore.DataAccess.Models.Authors.AuthorModelItem author)
        {
            return new AuthorModelItem()
            {
                Id = author.Id,
                Name = author.Name,
                PrintingEditions = author.PrintingEditions
            };
        }

        public static OrderModelItem Mapping(this Order order)
        {
            return new OrderModelItem()
            {
                Id = order.Id,
                Date = order.CreationDate,
            };
        }

        public static OrderModelItem Mapping(this BookStore.DataAccess.Models.Orders.OrderModelItem order)
        {
            return new OrderModelItem()
            {
                Id = order.Id,
                Date = order.Date,
                UserName = order.UserName,
                UserEmail = order.UserEmail,
                Product = order.Product,
                Title = order.Title,
                Qty = order.Qty,
                OrderAmount = order.OrderAmount,
                Status = order.Status
            };
        }
    }
}
