using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Newtonsoft.Json;
namespace Sample
{
  [TestClass]
  public class Tests
  {

    /*
     * Test 1: 
     * Assert that the endpoint receives a 200 response
       * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US
       * 2.  Assert that response code is 200
       * 3.  Assert that the movie title is correct
     */

    /*     
    * Test 2: 
    * Assert that the endpoint receives a 401 response
      * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using an empty api key
      * 2.  Assert that response code is 401
      * 3.  Assert that the response body status_code is 7
      * 4.  Assert that the response body status_message is "Invalid API key: You must be granted a valid key."
    */

    /*     
    * Test 3: 
    * Assert that the endpoint receives a 401 response
      * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using an invalid api key
      * 2.  Assert that response code is 401
      * 3.  Assert that the response body status_code is 7
      * 4.  Assert that the response body status_message is "Invalid API key: You must be granted a valid key."
    */

    /*
    * Test 4: 
    * Assert that the endpoint receives a 404 response
      * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using an invalid movie integer value
      * 2.  Assert that response code is 404
      * 3.  Assert that the response body status_code is 34
      * 4.  Assert that the response body status_message is "The resource you requested could not be found."
    */

    /*
    * Test 5: 
    * Assert that the endpoint receives a 404 response
    * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using a string for the movie integer
    * 2.  Assert that response code is 404
    * 3.  Assert that the response body status_code is 34
    * 4.  Assert that the response body status_message is "The resource you requested could not be found."
    */
    string apiKey = null;
    [TestInitialize]
    public void Setup()
    {
      apiKey = ConfigurationManager.AppSettings["ApiKey"];
    }
    [TestMethod]
    public void Assert200Response()
    {
      /*
       * Assert that the endpoint receives a 200 response
       * 1. Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US
       * 2.  Assert that response code is 200
       * 3.  Assert that the movie title is correct
       */
      //new requests object
      Requests requests = new Requests();
      //send get call with appropriate endpoint and apikey
      var response = requests.Get(Endpoint: string.Format(@"3/movie/{0}?api_key={1}&language=en-US", "274", apiKey));
      MovieDetailsResponse detailsObject = null;

      try
      {
        //deserialize json response
        detailsObject = JsonConvert.DeserializeObject<MovieDetailsResponse>(response.Content.ReadAsStringAsync().Result);
      }
      catch (JsonReaderException jsonEx)
      {
        //fail test if deserialization fails
        Assert.Fail(string.Format("Unable to deserialize response.  Exception: {0}"), jsonEx);
      }
      //assert that response has a 200 OK code
      Assert.AreEqual(200, (int)response.StatusCode);
      Assert.AreEqual("The Silence of the Lambs", detailsObject.title);
    }

    [TestMethod]
    public void Assert401Response()
    {
      /*
      * Assert that the endpoint receives a 401 response
      * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using an empty api key
      * 2.  Assert that response code is 401
      * 3.  Assert that the response body status_code is 7
      * 4.  Assert that the response body status_message is "Invalid API key: You must be granted a valid key."
       */
      //new requests object
      Requests requests = new Requests();
      //send get call with appropriate endpoint and no apikey
      var response = requests.Get(Endpoint: string.Format(@"3/movie/{0}?api_key={1}&language=en-US", "247", string.Empty));
      MovieDetailsResponse detailsObject = null;
      try
      {
        //deserialize json response
        detailsObject = JsonConvert.DeserializeObject<MovieDetailsResponse>(response.Content.ReadAsStringAsync().Result);
      }
      catch (JsonReaderException jsonEx)
      {
        //fail test if deserialization fails
        Assert.Fail(string.Format("Unable to deserialize response.  Exception: {0}"), jsonEx);
      }
      //assert that response has a 401 Unauthorized code
      Assert.AreEqual(401, (int)response.StatusCode);
      Assert.AreEqual(7, detailsObject.status_code);
      Assert.AreEqual("Invalid API key: You must be granted a valid key.", detailsObject.status_message);
    }
  }
}
