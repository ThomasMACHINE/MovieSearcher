using System;
using System.Collections.Generic;

namespace Movies.Models
{
    public class MovieSearch
    {
        public List<Movie> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }

        public MovieSearch()
        {
        }
    }
}
