using BookStore.DataAccess.AppContext;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;
using BookStore.DataAccess.Entities;
using static BookStore.DataAccess.Entities.Enums.Enums;

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
            var roles = new List<Role>()
            {
                new Role{Name = RoleEnum.Admin.ToString(),},
                new Role{Name = RoleEnum.User.ToString()}
            };

            foreach (var role in roles)
            {
                _roleManager.CreateAsync(role).GetAwaiter().GetResult();
            }          
        }

        public void InitializationAdmin()
        {
            var admin = new ApplicationUser 
            { 
                Email = "admin@mail.com",
                UserName = "Admin",
                FirstName = "Admin",
                LastName = "Admin"
            };

            var result = _userManager.CreateAsync(admin).GetAwaiter().GetResult();
            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(admin, RoleEnum.Admin.ToString()).GetAwaiter().GetResult();
            }
        }

        public void InitializationAuthors()
        {
            long amountAuthors = _applicationContext.Authors.Count();
            if (amountAuthors == 0)
            {
                var author = new Author
                { 
                    Name = "Author"
                };
                _applicationContext.Authors.Add(author);
                _applicationContext.SaveChanges();
            }
        }

        public void InitializationAuthorInPrintingEdition()
        {
 
                var authorInPrintingEditions = new List<AuthorInPrintingEdition>() //todo remove
                {
                    new AuthorInPrintingEdition 
                    { 
                        AuthorId = 3, 
                        PrintingEditionId = 1
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 3,
                        PrintingEditionId = 7
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 6,
                        PrintingEditionId = 11
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 7,
                        PrintingEditionId = 9
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 8,
                        PrintingEditionId = 8
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 9,
                        PrintingEditionId = 8
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 9,
                        PrintingEditionId = 10
                    },

                    /*new AuthorInPrintingEdition
                    {
                        AuthorId = 3,
                        PrintingEditionId = 13
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 6,
                        PrintingEditionId = 13
                    },
                    new AuthorInPrintingEdition
                    {
                        AuthorId = 7,
                        PrintingEditionId = 13
                    },*/
                    //new AuthorInPrintingEdition { AuthorId = 4, PrintingEditionId = 1 }
                };

            foreach (AuthorInPrintingEdition authorInPrintingEdition in authorInPrintingEditions)
            {
                _applicationContext.AuthorInPrintingEditions.Add(authorInPrintingEdition);
            }
                _applicationContext.SaveChanges();

        }

        public void InitializationPrintingEdition()
        {
            long amountPrintingEdition = _applicationContext.PrintingEditions.Count();
            if (amountPrintingEdition > 0)
            {
                return;
            }
            PrintingEdition printingEdition = new PrintingEdition
            {
                Title = "Title5",
                Description = "Description",
                Price = 40,
                Currency = Currencys.UAH,
                Type = TypePrintingEdition.Book
            };
            _applicationContext.PrintingEditions.Add(printingEdition);
            _applicationContext.SaveChanges();
        }

        public void InitializationOrder()
        {
            List<Order> orders = new List<Order>()
            {
                new Order
                {
                    Description = "Description",
                    PaymentId = 1,
                    UserId = 2
                },

                new Order
                {
                    Description = "Description1",
                    PaymentId = 2,
                    UserId = 1
                },

                new Order
                {
                    Description = "Description2",
                    PaymentId = 1,
                    UserId = 3
                },

                new Order
                {
                    Description = "Description2",
                    PaymentId = 3,
                    UserId = 2
                },
            };

            foreach (Order order in orders)
            {
                _applicationContext.Orders.Add(order);
            }
            _applicationContext.SaveChanges();
        }

        public void InitializationOrderItem()
        {
            /*List<OrderItem> orders = new List<OrderItem>()
            {
                /*new OrderItem
                {
                    /*Amount = 78,
                    Currency = "USD",
                    Count = 7,
                    PrintingEditionId = 7,
                    OrderId = 13
                },

                new OrderItem
                {
                    Amount = 240,
                    Currency = "UAH",
                    Count = 2,
                    PrintingEditionId = 9,
                    OrderId = 12
                },

                new OrderItem
                {
                    Amount = 700,
                    Currency = "EUR",
                    Count = 84,
                    PrintingEditionId = 10,
                    OrderId = 15
                },

                new OrderItem
                {
                    Amount = 12,
                    Currency = "UAH",
                    Count = 1,
                    PrintingEditionId = 12,
                    OrderId = 14
                },
            };

            foreach (OrderItem order in orders)
            {
                _applicationContext.OrderItems.Add(order);
            }
            _applicationContext.SaveChanges();*/
        }
    }
}
