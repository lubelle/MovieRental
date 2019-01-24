using AutoMapper;
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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // Get /api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
            if (movies == null)
                return NotFound();
            return Ok(movies);
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
