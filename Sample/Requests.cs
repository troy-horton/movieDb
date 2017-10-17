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
  public class Requests
  {
    private string endpoint { get; set; }
    private APIs api { get; set; }

    public Requests(APIs API, string Endpoint)
    {
      this.api = API;
      this.endpoint = Endpoint;
    }
    //public HttpResponseMessage Get(string Endpoint)
    //{
    //  //new http client
    //  HttpClient client = new HttpClient();
    //  //set base address
    //  client.BaseAddress = baseAddress;
    //  //send request and return response
    //  try
    //  {
    //    return GetRequest(Client: client, Endpoint: Endpoint).Result;
    //  }
    //  catch (Exception ex)
    //  {
    //    Debug.WriteLine(ex);
    //  }
    //  return null;
    //}
    public HttpResponseMessage Get()
    {
      //send request and return response
      try
      {
        return GetRequest().Result;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      return null;
    }
    private async Task<HttpResponseMessage> GetRequest()
    {
      //use http client to send get request to endpoint
      
      return await this.api.v3Client.GetAsync(endpoint);
    }
  }
}
