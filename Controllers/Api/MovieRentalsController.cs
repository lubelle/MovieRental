using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // load customer and movies base on the ids that the Dto give us
        // for each movie, create a new rental object for that movie and given customer and then add it to the database
        // for internal api, check edge case 4; for public api, check all 4 edge cases
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
             if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie was selected!");    // Edge case 1 for building public api

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("CustomerId is invalid");     // Edge case 2

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more movie Ids are invalid!");    // Edge case 3

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 1)
                    return BadRequest("Movie is not available!");           // Edge case 4

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
