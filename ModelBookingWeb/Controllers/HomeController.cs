using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelBookingWeb.Models;

namespace ModelBookingWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AssignmentData _assignmentData;

        public HomeController(AssignmentData assignmentData)
        {
            _assignmentData = assignmentData;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Guid assignmentId, DateTime date, string text, double amount)
        {
            _assignmentData.AddExpence(assignmentId, date, text, amount);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
