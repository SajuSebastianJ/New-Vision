using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace NewVision.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sterm = "", int pTypeId = 0)
        {
            IEnumerable<Product> products = await _homeRepository.GetProducts(sterm, pTypeId);
            IEnumerable<PType> pTypes = await _homeRepository.PTypes();
            ProductDisplayModel productModel = new ProductDisplayModel
            {
                Products = products,
                PTypes = pTypes,
                STerm = sterm,
                PTypeId = pTypeId
            };
            return View(productModel);
        }

        public IActionResult About()
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