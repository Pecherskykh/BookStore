using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookStore.DataAccess.Entities;

namespace BookStore.DataAccess.Initialization
{
    public class DataBaseInitialization
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationContext _applicationContext;
        public DataBaseInitialization(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, ApplicationContext applicationContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationContext = applicationContext;
        }

        public void StartInit()
        {
            InitializationApplicationUser();
            /*InitializationAuthors();
            InitializationAuthorInPrintingEdition();            
            InitializationOrder();
            InitializationOrderItem();
            InitializationPayment();
            InitializationPrintingEdition();*/
        }

        public void InitializationApplicationUser()
        {
            var role = new Role();
            role.Name = "Admin";
            _roleManager.CreateAsync(role).GetAwaiter().GetResult();

            var role1 = new Role();
            role1.Name = "User";
            _roleManager.CreateAsync(role1).GetAwaiter().GetResult();

            List<ApplicationUser> users = new List<ApplicationUser>()
                {
                    new ApplicationUser { Email = "model.Email4", UserName = "model.Email2",  FirstName = "FirstName2", LastName = "LastName2"},
                    new ApplicationUser { Email = "model.Email7", UserName = "model.Email3",  FirstName = "FirstName2", LastName = "LastName2" },
                };

            foreach (ApplicationUser user in users)
            {
                var result = _userManager.CreateAsync(user).GetAwaiter().GetResult();
                if(result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, role.Name).GetAwaiter();
                }
            }           
        }

        public void InitializationAuthors()
        {
                   
                List<Author> authors = new List<Author>()
                {
                    new Author { Name = "Name1" },
                    new Author { Name = "Name2" }
                };               

                foreach(Author author in authors)
                    _applicationContext.Authors.Add(author);
                _applicationContext.SaveChanges();

        }

        public void InitializationAuthorInPrintingEdition()
        {
 
                List<AuthorInPrintingEdition> authorInPrintingEditions = new List<AuthorInPrintingEdition>()
                {
                    new AuthorInPrintingEdition { AuthorId = 4, PrintingEditionId = 1 },
                    new AuthorInPrintingEdition { AuthorId = 4, PrintingEditionId = 1 }
                };

                foreach (AuthorInPrintingEdition authorInPrintingEdition in authorInPrintingEditions)
                    _applicationContext.AuthorInPrintingEditions.Add(authorInPrintingEdition);
                _applicationContext.SaveChanges();

        }

        public void InitializationOrder()
        {

                List<Order> orders = new List<Order>()
                {
                    new Order{ UserId = 7, PaymentId = 8 },
                    new Order{ UserId = 7, PaymentId = 8 }
                };

                foreach (Order order in orders)
                    _applicationContext.Orders.Add(order);
                _applicationContext.SaveChanges();
        }

        public void InitializationOrderItem()
        {

                List<OrderItem> orderItems = new List<OrderItem>()
                {
                    new OrderItem{ OrderId = 2, PrintingEditionId = 4 },
                    new OrderItem{ OrderId = 2, PrintingEditionId = 4 }
                };

                foreach (OrderItem orderItem in orderItems)
                    _applicationContext.OrderItems.Add(orderItem);
                _applicationContext.SaveChanges();
        }

        public void InitializationPayment()
        {

                List<Payment> payments = new List<Payment>()
                {
                    new Payment{ TransactionId = 2 },
                    new Payment{ TransactionId = 2 }
                };

                foreach (Payment payment in payments)
                    _applicationContext.Payments.Add(payment);
                _applicationContext.SaveChanges();
        }

        public void InitializationPrintingEdition()
        {
 
                List<PrintingEdition> printingEditions = new List<PrintingEdition>()
                {
                    new PrintingEdition { Description = "fdf" },
                    new PrintingEdition{ Description = "fdf" }
                };

                foreach (PrintingEdition printingEdition in printingEditions)
                    _applicationContext.PrintingEditions.Add(printingEdition);
                _applicationContext.SaveChanges();
        }
    }
}
