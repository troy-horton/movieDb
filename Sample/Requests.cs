using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Diagnostics;

namespace Sample
{
  class Requests
  {
    Uri baseAddress = new Uri("https://api.themoviedb.org/");
    public HttpResponseMessage Get(string Endpoint)
    {
      //new http client
      HttpClient client = new HttpClient();
      //set base address
      client.BaseAddress = baseAddress;
      //send request and return response
      try
      {
        return GetRequest(Client: client, Endpoint: Endpoint).Result;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      return null;
    }
    private async Task<HttpResponseMessage> GetRequest(HttpClient Client, string Endpoint)
    {
      //use http client to send get request to endpoint
      return await Client.GetAsync(Endpoint);
    }
  }
}
