using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.OrderItems;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Models.Users;
using BookStore.DataAccess.Entities;
using System.Collections.Generic;

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
                IsRemoved = printingEditionModelItem.IsRemoved,
                Title = printingEditionModelItem.Title,
                Description = printingEditionModelItem.Description,
                Price = printingEditionModelItem.Price,
                Type = printingEditionModelItem.Type,
            };
        }

        public static List<AuthorModelItem> Mapping(this ICollection<BookStore.DataAccess.Models.Authors.AuthorModelItem> authorModelItems)
        {
            List<AuthorModelItem> author = new List<AuthorModelItem>();
            foreach(BookStore.DataAccess.Models.Authors.AuthorModelItem authorModelItem in authorModelItems)
            {
                author.Add(authorModelItem.Mapping());
            }
            return author;
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
                IsRemoved = printingEditionModelItem.IsRemoved,
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

        public static OrderItem Mapping(this OrderItemModelItem orderItem)
        {
            return new OrderItem()
            {
                Amount = orderItem.Amount,
                Currency = orderItem.Currency,
                Count = orderItem.Count,
                OrderId = orderItem.OrderId,
                PrintingEditionId = orderItem.PrintingEditionId
            };
        }

        public static Order Mapping(this OrderModelItem order)
        {
            return new Order()
            {
                Id = order.Id,
                IsRemoved = order.IsRemoved,
                Description = order.Description,
                PaymentId = order.PaymentId,
                UserId = order.UserId
            };
        }
    }
}
