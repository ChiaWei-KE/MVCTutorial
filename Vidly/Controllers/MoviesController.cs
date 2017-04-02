using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Details()
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() {Name = "Shrek"},
                new Movie() {Name = "Wall-E"}
            };

            return View(movies);
        }
//        // GET: Movie/Random
//        public ActionResult Random()
//        {
//            var movie = new Movie()
//            {
//                Name = "Shrek"
//            };
//
//            var customers = new List<Customer>()
//            {
////                new Customer() { Name = "Customer 1"},
////                new Customer() { Name = "Customer 2"},
////                new Customer() { Name = "Customer 3"},
////                new Customer() { Name = "Customer 4"},
////                new Customer() { Name = "Customer 5"},
////                new Customer() { Name = "Customer 6"}
//            };
//
//            var viewModel = new RandomMovieViewModel()
//            {
//               Movie = movie,
//               Customers = customers
//            };
//
//            return View(viewModel);
//        }

//        public ActionResult Edit(int? id)
//        {
//            return Content($"Id is {id ?? 0}");
//        }
//
//        public ActionResult Index(int? pageIndex, string sortBy)
//        {
//            if (!pageIndex.HasValue) pageIndex = 1;
//            if (string.IsNullOrEmpty(sortBy)) sortBy = "Name";
//
//            return Content($"Page Index is {pageIndex} and sorted by {sortBy}");
//        }
//
//        [Route("movies/release/{year}/{month:regex(\\d{2})}")]
//        public ActionResult ByReleaseDate(int year, int month)
//        {
//            return Content($"{year} + {month}");
//        }

       
    }
}