﻿using System;
namespace Movies.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }
        public string imdbRating { get; set; }
        /// <summary>
        /// Release date
        /// </summary>
        public string Released { get; set; }
        /// <summary>
        /// The length of the movie
        /// </summary>
        public string Runtime { get; set; }
        public string imdbID { get; set; }

        public Movie() { }
    }
}
