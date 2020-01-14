using System;
using System.ComponentModel.DataAnnotations;


namespace omdbapp.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}