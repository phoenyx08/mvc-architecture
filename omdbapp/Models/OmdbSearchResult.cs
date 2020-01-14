using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace omdbapp.Models
{
    public class OmdbSearchResult
    {
        public List<Movie> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}