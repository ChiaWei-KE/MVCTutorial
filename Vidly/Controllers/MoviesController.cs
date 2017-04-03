﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

//        public ActionResult Details(int id)
//        {
//            var movies = GetMovies();
//            var movie = movies.SingleOrDefault(x => x.Id == id);
//
//            if(movie == null) return HttpNotFound();
//
//            return View(movie);
//        }

        public ActionResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.Single(x => x.Id == id);

            var viewModel = new MovieViewModel()
            {
                Movie = movie,
                Genres = GetGenres()
            };

            return View(viewModel);
        }


        private IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(x => x.Genre).ToList();
        }

        private IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        [HttpPost]
        public ActionResult CreateNew(Movie movie)
        {
            movie.AddedDate = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            var existingMovie = _context.Movies.Single(x => x.Id == movie.Id);
            existingMovie.Name = movie.Name;
            existingMovie.Genre = _context.Genres.Single(x => x.Id == movie.GenreId);
            existingMovie.NumberInStocks = movie.NumberInStocks;
            existingMovie.ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Create()
        {
            var viewModel = new MovieViewModel()
            {
                Genres = GetGenres()
            };

            return View(viewModel);
        }
    }
}