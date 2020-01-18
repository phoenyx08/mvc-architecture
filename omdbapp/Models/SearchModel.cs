using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace omdbapp.Models
{
    public class SearchModel
    {
        [Display(Name="Search query string")]
        public string SearchQuery { get; set; }
        public List<Movie> SearchResult { get; set; }
        public string Totals { get; set; }
    }
}