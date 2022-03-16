using Dapper;
using JuanDeDiosFrausto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace JuanDeDiosFrausto.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            string sqlMovies = "SELECT * FROM Movies";
            using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                var movies = connection.Query<Movie>(sqlMovies).ToList();
                return View(movies);
            }
        }

        public IActionResult Details(int id)
        {
            string sqlMovies = $"SELECT * FROM Movies WHERE MovieId='{id}'";
            using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                var movie = connection.Query<Movie>(sqlMovies).FirstOrDefault();
                return View(movie);
            }
        }

        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ISAN,Name,Category,Year,Month,Image,Duration,Summary")] Movie movie)
        {
            string sql = $"INSERT INTO Movies (ISAN,Name,Category,Year,Month,Image,Duration,Summary) VALUES(@ISAN,@Name,@Category,@Year,@Month,@Image,@Duration,@Summary)";
            try
            {
                if (ModelState.IsValid)
                {
                    using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
                    {
                        connection.Execute(sql, new
                        {
                            ISAN = movie.ISAN,
                            Name = movie.Name,
                            Category = movie.Category,
                            Year = movie.Year,
                            Month = movie.Month,
                            Image = movie.Image,
                            Duration=movie.Duration,
                            Summary=movie.Summary
                        });
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            string sqlMovies = $"SELECT * FROM Movies WHERE MovieId='{id}'";
            using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                var movie = connection.Query<Movie>(sqlMovies).FirstOrDefault();
                return View(movie);
            }
        }

        [HttpPost]
        public ActionResult Edit([Bind("ISAN,Name,Category,Year,Month,Image,Duration,Summary")] Movie movie, int id)
        {
            string sql = $"UPDATE Movies SET ISAN=@ISAN,Name=@Name,Category=@Category,Year=@Year,Month=@Month,Image=@Image,Duration=@Duration,Summary=@Summary WHERE MovieId='{id}'";
            try
            {
                if (ModelState.IsValid)
                {
                    using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
                    {
                        connection.Execute(sql, new
                        {
                            ISAN = movie.ISAN,
                            Name = movie.Name,
                            Category = movie.Category,
                            Year = movie.Year,
                            Month = movie.Month,
                            Image = movie.Image,
                            Duration = movie.Duration,
                            Summary = movie.Summary
                        });
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }

        }

        public ActionResult Delete(int id)
        {
            string sqlMovies = $"SELECT * FROM Movies WHERE MovieId='{id}';";
            using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
            {
                var movie = connection.Query<Movie>(sqlMovies).FirstOrDefault();
                return View(movie);
            }
        }

        [HttpPost]
        public ActionResult Delete([Bind("ISAN")]string ISAN, string id)
        {
            string sql = $"DELETE FROM Movies WHERE MovieId='{id}'";
            try
            {

                using (var connection = new SqlConnection("Data Source = MEX-5J6PMG3\\SQLEXPRESS; Initial Catalog=FraustoJuan; TrustServerCertificate=True; Trusted_Connection=True; MultipleActiveResultSets=true"))
                {
                    connection.Execute(sql);
                    return RedirectToAction(nameof(Index));
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View();
            }
        }

    }
}

