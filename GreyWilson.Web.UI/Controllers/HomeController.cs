using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreyWilson.Web.UI.Models;
using System.Data.SQLite;
using GreyWilson.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using GreyWilson.Web.UI.Models.Home;

namespace GreyWilson.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClaimRepository ClaimRepository;

        public HomeController(){
            ClaimRepository = new ClaimRepository(); 
        }


        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Claims = ClaimRepository.GetAll().OrderByDescending(o => o.CreatedOn);
            return View(viewModel);
        }


        public IActionResult Pendulum()
        {
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
