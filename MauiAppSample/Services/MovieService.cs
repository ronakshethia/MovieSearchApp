using System;
using MauiAppSample.Models;
using Microsoft.Extensions.DependencyInjection;

namespace MauiAppSample.Services
{
    public class MovieService : IMovieService
    {
        public MovieService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _httpClientService = _serviceProvider.GetService<IHttpClientService>();
        }

        public async Task<List<MoviesResult>> SearchMoviesAsync(string searchTerm, int pageNumber)
        {
            //await Task.Delay(500);
            //return new List<MovieResponse>
            //{
            //    new MovieResponse { Title = "Inception", ImageUrl = "inception.jpg", Genre = "Sci-Fi",  Description = "Leonardo DiCaprio, Joseph Gordon-Levitt" },
            //    new MovieResponse { Title = "Titanic", ImageUrl = "titanic.jpg", Genre = "Romance", Description = "Leonardo DiCaprio, Kate Winslet" }
            //}.Where(m => m.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();


            string endpoint = string.Format("search/movie?query={0}&include_adult=false&language=en-US&page={1}",searchTerm, pageNumber);
            string token = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmNTYzYWU2MmVjNjFlOTU1MmI3YmNhYmRhYTBjMTA5ZiIsIm5iZiI6MTczMjAzOTE3MC45Nzg1NzA1LCJzdWIiOiI2NzNjNmMzZTYwYjdiM2JjOTRhMGI4MzUiLCJzY29wZXMiOlsiYXBpX3JlYWQiXSwidmVyc2lvbiI6MX0.n8Q6hYpjJPXz-vH6sLXU9kuqO_CyKhvYz9MR9GTIw7I";

            var listOfMovies = await _httpClientService.GetAsync<MoviesReponse>(endpoint,token);
            return listOfMovies.Results;
        }

        private readonly IServiceProvider _serviceProvider;

        private readonly IHttpClientService _httpClientService;
    }
}

