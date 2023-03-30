using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Movies.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace Movies.ApiHandler
{
    public static class MovieHandler
    {
        private static HttpClient client = new HttpClient();
        private static string baseLink = "http://www.omdbapi.com/?apikey=4839f77";

        public static async Task<Movie> CreateMovie(string Title)
        {
            Movie movie = null;
            // Format Search Link
            string searchLink = baseLink + "&t=" + Title;
            try
            {
                HttpResponseMessage response = await client.GetAsync(searchLink);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();

                movie = JsonSerializer.Deserialize<Movie>(responseContent);
            }
            catch (Exception e)
            {
                // Debug
                return new Movie { Title = e.ToString() };
            }
            return movie;
        }

        public static async Task<List<Movie>> CreateMovieList(string Title, string Year)
        {
            MovieSearch movieSearch = null;
            List<Movie> movieList;
            // Format Search Link
            string searchLink = baseLink + "&s=" + Title;

            if (Year != null)
                searchLink += "&y=" + Year;

            try
            {
                HttpResponseMessage response = await client.GetAsync(searchLink);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();

                movieSearch = JsonSerializer.Deserialize<MovieSearch>(responseContent);
                movieList = movieSearch.Search;
            }
            catch (Exception e)
            {
                return null;
            }
            return movieList;
        }
    }
}
