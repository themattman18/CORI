using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CORI.Controllers
{
    [Authorize]
    public class TextingController : Controller
    {
        private IO.Texting.ITexting TwilioTexting { get; set; }

        public TextingController(IO.Texting.ITexting textServiceLayer)
        {
            TwilioTexting = textServiceLayer ?? throw new ArgumentNullException();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendText(IO.Texting.Models.TextingViewModel textingMessage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TwilioTexting.SendText(textingMessage);
                    return View("~/Views/Texting/Index.cshtml");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("PhoneNumber", ex.Message);
                    return View("~/Views/Texting/Index.cshtml", textingMessage);
                }
            }
            else
            {
                return View("~/Views/Texting/Index.cshtml", textingMessage);
            }
        }
    }
}