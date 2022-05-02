using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog;
using MedHelper.Models;
using Microsoft.AspNetCore.Authorization;

namespace MedHelper.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        //
        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }
        //
        // public IActionResult Index()
        // {
        //     return View();
        // }
        readonly IDiagnosticContext _diagnosticContext;

        public HomeController(IDiagnosticContext diagnosticContext)
        {
            _diagnosticContext = diagnosticContext ??
                                 throw new ArgumentNullException(nameof(diagnosticContext));
        }
       // [Authorize]
        public IActionResult Index()
        {
            // The request completion event will carry this property
            _diagnosticContext.Set("CatalogLoadTime", 1423);

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