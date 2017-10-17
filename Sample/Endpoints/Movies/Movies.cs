using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Endpoints.Movies
{
  public class Movies
  {
    private Requests requests { get; set; }
    private APIs api { get; set; }
    private string movieId { get; set; }
    private Requests movieDetails
    {
      get
      {
        requests = new Requests(this.api, Endpoint: string.Format(@"movie/{0}?api_key={1}&language=en-US", movieId, this.api.ApiKey));        
        return requests;
      }
    }
    public Movies(APIs API)
    {
      this.api = API;
    }
    public Requests MovieDetails(string MovieId)
    {
      this.movieId = MovieId;
      return movieDetails;
    }
  }
}
