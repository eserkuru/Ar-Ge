using System.Diagnostics;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using SharedLocalizerTest.Models;
using Util.Localization;

namespace SharedLocalizerTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILanguageService _language;

        //private readonly IStringLocalizer<CoreResource> _coreLocalizer;
        //private readonly IStringLocalizer<SharedResource> _sharedLocalizer;
        //private readonly IStringLocalizer<SharedResource> _localizerLocalizer;
        public HomeController(
            ILogger<HomeController> logger
            , ILanguageService language
            //,IStringLocalizer<CoreResource> coreLocalizer, IStringLocalizer<SharedResource> sharedLocalizer, IStringLocalizer<SharedResource> localizerLocalizer
            )
        {
            _logger = logger;
            _language = language;
            //_coreLocalizer = coreLocalizer; _sharedLocalizer = sharedLocalizer; _localizerLocalizer = localizerLocalizer;
        }


        public IActionResult Index()
        {
            var core = _language.Core("Hello Core");
            var shared = _language.Shared("Hello Plugin");
            var local = _language.Local("Hello Home Controller");


            _logger.LogInformation(core);
            _logger.LogInformation(shared);
            _logger.LogInformation(local);
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
