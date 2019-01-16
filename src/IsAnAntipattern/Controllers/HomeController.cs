using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.Counter;
using Microsoft.AspNetCore.Mvc;
using IsAnAntipattern.Models;
using IsAnAntipattern.Services;

namespace IsAnAntipattern.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private static readonly CounterOptions SubDomainCounter = new CounterOptions
        {
            Name = "sub_domain",
            MeasurementUnit = Unit.Calls
        };
        
        private readonly IBlahBlahBlah _blah;
        private readonly IMetrics _metrics;

        public HomeController(IBlahBlahBlah blah, IMetrics metrics)
        {
            _blah = blah;
            _metrics = metrics;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var subDomain = Request.Host.Host.Split('.').FirstOrDefault() ?? "Something";
            var tags = new MetricTags("sub", subDomain);
            _metrics.Measure.Counter.Increment(SubDomainCounter, tags);
            
            var thing = SubDomainTitle(subDomain);
            var blah = _blah.GenerateParagraphs(thing, 4, 8, 4);
            
            var model = new BlahViewModel
            {
                Title = $"{thing} Is An Anti-pattern",
                HtmlText = blah.Text,
                ImagePath = blah.ImagePath,
                UnsplashLink = blah.UnsplashLink
            };
            return View(model);
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
        
        private string SubDomainTitle(string subDomain)
        {
            return subDomain.Contains('-')
                ? string.Join(' ', subDomain.Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .Select(TitleCase))
                : TitleCase(subDomain);
        }

        private static string TitleCase(string subDomain)
        {
            if (subDomain.Length == 0) return "Something";
            if (subDomain.Length == 1) return subDomain.ToUpper();
            return $"{char.ToUpper(subDomain[0])}{subDomain.Substring(1).ToLower()}";
        }
    }
}
