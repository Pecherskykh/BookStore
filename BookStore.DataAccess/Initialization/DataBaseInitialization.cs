using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.Linq;
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
            InitializationRoles();
            InitializationAdmin();
            InitializationAuthors();
            InitializationPrintingEdition();
        }

        public void InitializationRoles()
        {
            List<Role> roles = new List<Role>()
            {
                new Role{Name = "Admin"},
                new Role{Name = "User"}
            };

            foreach (Role role in roles)
            {
                _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }          
        }

        public void InitializationAdmin()
        {
            ApplicationUser admin = new ApplicationUser { Email = "admin@mail.com", UserName = "Admin", FirstName = "Admin", LastName = "Admin" };

            var result = _userManager.CreateAsync(admin).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            }
        }

        public void InitializationAuthors()
        {
            long amountAuthors = _applicationContext.Authors.Count();
            if (amountAuthors == 0)
            {
                Author author = new Author { Name = "Author" };
                _applicationContext.Authors.Add(author);
                _applicationContext.SaveChanges();
            }
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
            long amountPrintingEdition = _applicationContext.PrintingEditions.Count();
            if (amountPrintingEdition == 0)
            {
                PrintingEdition printingEdition = new PrintingEdition
                {
                    Title = "Title",
                    Description = "fdf",
                    Price = 25,
                    Status = "Status",
                    Currency = "Currency",
                    Type = "Type"
                };
                _applicationContext.PrintingEditions.Add(printingEdition);
                _applicationContext.SaveChanges();
            }
        }
    }
}
