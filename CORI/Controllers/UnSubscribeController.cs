using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CORI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CORI.Controllers
{
    public class UnsubscribeController : Controller
    {
        public IConfiguration Configuration { get; }

        public UnsubscribeController(IConfiguration config)
        {
            Configuration = config;
        }

        [AllowAnonymous]
        public IActionResult Index(string email)
        {
            return View(email);
        }

        [AllowAnonymous]
        public IActionResult Unsubscribe(string email)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                if (!string.IsNullOrEmpty(email))
                {
                    using (var context = new ApplicationDbContext(optionsBuilder.Options))
                    {
                        //IO.Email.Email myEmail = new IO.Email.Email(context, "");
                        //myEmail.Unsubscribe(email);
                    }
                }
                else
                {
                    throw new ApplicationException("No email");
                }

                return new JsonResult(new { error = false });

            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = true });
            }            
        }
    }
}