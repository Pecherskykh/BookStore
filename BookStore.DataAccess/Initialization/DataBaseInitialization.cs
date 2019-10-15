using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Collections.Generic;
using BookStore.DataAccess.Entities;

namespace BookStore.DataAccess.Initialization
{
    public class DataBaseInitialization
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationContext _applicationContext;
        public ApplicationContext Context { get { return _applicationContext; } }
        public UserManager<ApplicationUser> UserManager { get { return _userManager; } }
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
                new Role{Name = "Admin"},
                new Role{Name = "User"}
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
                _userManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
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
 
                var authorInPrintingEditions = new List<AuthorInPrintingEdition>()
                {
                    new AuthorInPrintingEdition 
                    { 
                        AuthorId = 4, 
                        PrintingEditionId = 1
                    },
                    new AuthorInPrintingEdition { AuthorId = 4, PrintingEditionId = 1 }
                };

                foreach (AuthorInPrintingEdition authorInPrintingEdition in authorInPrintingEditions)
                    _applicationContext.AuthorInPrintingEditions.Add(authorInPrintingEdition);
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
