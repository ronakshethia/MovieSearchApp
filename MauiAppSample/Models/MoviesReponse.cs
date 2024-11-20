using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Models
{
    internal class MoviesReponse
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("results")]
        public List<MoviesResult> Results { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }
    }
}
