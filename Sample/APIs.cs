using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Sample.Endpoints.Movies;

namespace Sample
{
  public class APIs
  {
    private string apikey { get; set; }
    public string ApiKey { get { return apikey = ConfigurationManager.AppSettings["ApiKey"]; } set { apikey = value; } }
    public Movies Movies { get { return new Movies(API: this); } }
    public HttpClient v3Client
    {
      get
      {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["v3ApiBaseAddress"]);
        return client;
      }
    }
  }
}
