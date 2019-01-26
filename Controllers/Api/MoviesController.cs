using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // Get /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            var movieDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);


            return Ok(movieDto);
        }

        // Get /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movieInDb));
        }

        // Post /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovies(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var newMovie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            movieDto.Id = newMovie.Id;
            return Created(new Uri(Request.RequestUri + "/" + newMovie.Id), movieDto);
        }

        // Put /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovies(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok("Update Successful");
        }

        // Delete /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovies(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok("Delete Successful");
        }
    }
}
