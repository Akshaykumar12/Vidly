using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m =>m.Genre).ToList();
            return View(movies);
        }
        
        //Get:MovieDetail
        public ActionResult MovieDetail(int id)
        {
            var movieDetail = _context.Movies.Include(m => m.Genre).ToList().SingleOrDefault(m=>m.Id==id);           
            return View(movieDetail);
        }

        public ActionResult New()
        {
            var ViewModel = new MovieViewModel
            {
                Genres = _context.Genres,
                Movie = new Movie()
            };
            return View("MovieForm",ViewModel);
        }


        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new MovieViewModel
                {
                    Genres = _context.Genres,
                    Movie = movie
                };
                return View("MovieForm", ViewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
          
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == id);
            var ViewModel = new MovieViewModel
            {
                Movie = movieInDb,
                Genres = _context.Genres

            };
            return View("MovieForm", ViewModel);
        }
    }
       
      
}