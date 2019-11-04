﻿using System;
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

        // GET api/values
        public IEnumerable<string> Get()
        {
            // Retrieve all movies from db logic
            return new string[] { "movie1 string", "movie2 string" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            // Retrieve movie by id from db logic
            var movie = context.Movies.FirstOrDefault(m => m.MovieId == id);
            var value = movie.Title;
            return value;
        }

        // POST api/values
        public void Post([FromBody]Movie value)
        {
            context.Movies.Add(value);
            context.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            // Update movie in db logic
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