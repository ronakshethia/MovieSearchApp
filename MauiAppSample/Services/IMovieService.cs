using MauiAppSample.Models;

namespace MauiAppSample.Services
{
    public interface IMovieService
    {
        Task<List<MoviesResult>> SearchMoviesAsync(string searchTerm, int pageNumber = 1);
    }
}

