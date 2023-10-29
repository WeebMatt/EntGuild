using EntGuild.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EntGuild.Data;


namespace EntGuild.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly EntGuildContext _context;

        public MoviesController(ILogger<MoviesController> logger, EntGuildContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var productGenreVM = new ProductGenreViewModel();

            productGenreVM.BooksProducts = GetShuffledCardsForGenre(1, 4);
            productGenreVM.MoviesProducts = GetShuffledCardsForGenre(2, 4);
            productGenreVM.GamesProducts = GetShuffledCardsForGenre(3, 4);

            return View(productGenreVM);
        }

        public List<Product> GetShuffledCardsForGenre(int genre, int count)
        {
            {
                var allProducts = _context.Product.Where(p => p.Genre == genre).ToList();
                ShuffleCards(allProducts);
                return allProducts.Take(count).ToList();
            }
        }

        private void ShuffleCards<T>(IList<T> list)
        {
            int f = list.Count;
            Random random = new Random();
            while (f > 1)
            {
                f--;
                int l = random.Next(f + 1);
                (list[l], list[f]) = (list[f], list[l]);
            }
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
