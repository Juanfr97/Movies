using Dapper;
using JuanDeDiosFrausto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace JuanDeDiosFrausto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string sqlMovies = "SELECT * FROM Movies";
            using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                var allMovies = connection.Query<Movie>(sqlMovies).ToList();
                List<Movie> movies = new List<Movie>();
                foreach(var movie in allMovies)
                {
                    if (movie.Month == DateTime.Now.Month && movie.Year==DateTime.Now.Year)
                    {
                        movies.Add(movie);
                    }
                }
                if(movies.Count == 0)
                {
                    movies.Add(new Movie() { Name = "Sin peliculas de estreno este mes",Image= "https://cdn-icons-png.flaticon.com/512/73/73312.png" });
                }
                ViewData["movies"] = movies;
                return View(movies);
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