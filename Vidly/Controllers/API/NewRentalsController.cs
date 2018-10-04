using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
         _context = new ApplicationDbContext();   
        }
        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            var retaltDtos = _context.Rentals.ToList().Select(Mapper.Map<Rental, NewRentalDto>);
            return Ok(retaltDtos);
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto rentalDto)
        {
            var customer = _context.Customers.Single(c=>c.Id==rentalDto.CustomerId);
            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not Avalible");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    BorrowedDate = DateTime.Now
                };
                _context.Rentals.Add(rental);
                
            }
            _context.SaveChanges();

            return Ok();



        }
    }
}
