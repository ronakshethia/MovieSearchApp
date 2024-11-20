using System;
using MauiAppSample.Services;

namespace MauiAppSample.Models
{
    public class Movie
    {
        public List<MovieResponse> ListOfMovies { get; private set; }

        #region METHODS

        public void PopulateFromResponse(IMovieService movieService)
        {
        }

        #endregion
    }
}
