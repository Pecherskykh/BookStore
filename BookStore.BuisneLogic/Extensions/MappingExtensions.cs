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

        public static ApplicationUser Mapping(this UserModelItem user)
        {
            return new ApplicationUser()
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

        public static List<AuthorModelItem> Mapping(this ICollection<BookStore.DataAccess.Models.Authors.AuthorModelItem> authorModelItems)
        {
            List<AuthorModelItem> a = new List<AuthorModelItem>();
            foreach(BookStore.DataAccess.Models.Authors.AuthorModelItem authorModelItem in authorModelItems)
            {
                a.Add(authorModelItem.Mapping());
            }
            return a;
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
                Authors = new AuthorModel()
                {
                    Items = printingEditionModelItem.Authors.Mapping()
                }
            };
        }

        public static PrintingEdition Mapping(this PrintingEditionModelItem printingEditionModelItem)
        {
            return new PrintingEdition()
            {
                Id = printingEditionModelItem.Id,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Type = printingEditionModelItem.Type,
            };
        }

        public static AuthorInPrintingEdition Mapping(this PrintingEditionModelItem printingEditionModelItem, AuthorModelItem authorModelItem)
        {
            return new AuthorInPrintingEdition()
            {
                AuthorId = authorModelItem.Id,
                PrintingEditionId = printingEditionModelItem.Id
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

        public static Author Mapping(this AuthorModelItem author)
        {
            return new Author()
            {
                Id = author.Id,
                Name = author.Name
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
                Quantity = order.Quantity,
                OrderAmount = order.OrderAmount,
                Status = order.Status
            };
        }

        public static Order Mapping(this OrderModelItem order)
        {
            return new Order()
            {
                Description = order.Description,
                PaymentId = order.PaymentId,
                UserId = order.UserId
            };
        }
    }
}
