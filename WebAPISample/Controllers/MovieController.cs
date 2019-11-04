using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class MovieController : ApiController
    {
        ApplicationDbContext context;
        public MovieController()
        {
            context = new ApplicationDbContext();
        }

        // GET api/movie
        public IEnumerable<Movie> Get()
        {
            return context.Movies.ToList();
        }

        // GET api/movie/1
        public IHttpActionResult Get(int id)
        {
            // Retrieve movie by id from db logic
            var movie = context.Movies.FirstOrDefault(m => m.MovieId == id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST api/values
        public void Post([FromBody]Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Movie movie)
        {
            // Update movie in db logic
            var movies = context.Movies.FirstOrDefault(m => m.MovieId == id);
            movies.Director = movie.Director;
            movies.Genre = movie.Genre;
            movies.Title = movie.Title;

            context.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Movie movie = context.Movies.FirstOrDefault(m => m.MovieId == id);
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }

}