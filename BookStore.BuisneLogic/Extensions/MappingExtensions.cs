using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Models.Users;
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

        public static AuthorModelItem Mapping(this BookStore.DataAccess.Models.Authors.AuthorModelItem author)
        {
            return new AuthorModelItem()
            {
                Id = author.Id,
                Name = author.Name,
                PrintingEditions = author.PrintingEditions
            };
        }
    }
}
