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
     * Assert that the GET movie endpoint receives a 200 response, verify response body
       * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US where movie id is 274
       * 2.  Assert that response code is 200
       * 3.  Assert that the movie title is correct
     */

    /*     
    * Test 2: 
    * Assert that the GET movie endpoint receives a 401 response, no api key, verify response body
      * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using an empty api key
      * 2.  Assert that response code is 401
      * 3.  Assert that the response body status_code is 7
      * 4.  Assert that the response body status_message is "Invalid API key: You must be granted a valid key."
    */

    /*     
    * Test 3: 
    * Assert that the GET movie endpoint receives a 401 response, invalid api key, verify response body
      * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using an invalid api key
      * 2.  Assert that response code is 401
      * 3.  Assert that the response body status_code is 7
      * 4.  Assert that the response body status_message is "Invalid API key: You must be granted a valid key."
    */

    /*
    * Test 4: 
    * Assert that the GET movie endpoint receives a 404 response, invalid movie id
      * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using an invalid movie integer value
      * 2.  Assert that response code is 404
      * 3.  Assert that the response body status_code is 34
      * 4.  Assert that the response body status_message is "The resource you requested could not be found."
    */

    /*
    * Test 5: 
    * Assert that the GET movie endpoint receives a 404 response, send string for movie id
    * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US using a string for the movie integer
    * 2.  Assert that response code is 404
    * 3.  Assert that the response body status_code is 34
    * 4.  Assert that the response body status_message is "The resource you requested could not be found."
    */

    /*
    * Test 6: 
    * Assert that the GET alternative_titles endpoint receives a 200 response, verify response body
     * 1.  Send call to get endpoint 3/movie/{movieId}/alternative_titles?api_key={apiKey}&language=en-US where movie id is 274
     * 2.  Assert that response code is 200
     * 3.  Assert that in the titles object list, the object where the "iso_3166_1" value is "CO" that the title object value is "El silencio de los inocentes"
     * 4.  Assert that the count in the titles object list is x.  This count could change over time so may need update test as things change
    */

    /*
    * Test 7: 
    * Assert that the GET credits endpoint receives a 200 response, verify response body
     * 1.  Send call to get endpoint 3/movie/{movieId}/credits?api_key={apiKey} where movie id is 274
     * 2.  Assert that response code is 200
     * 3.  Assert that in the cast object list, the object where the "character" value is "Clarice Starling" that the name object value is "Jodie Foster"
     * 4.  Assert that the count in the cast object list is x.  This count could change over time so may need update test as things change
    */

    /*
    * Test 8: 
    * Assert that the GET release dates endpoint receives a 200 response, verify response body
     * 1.  Send call to get endpoint 3/movie/{movieId}/release_dates?api_key={apiKey} where movie id is 274
     * 2.  Assert that response code is 200
     * 3.  Assert that in the results object list, the object where the "iso_3166_1" value is "HU" that in the release_dates object value the release date object value is "1992-03-27T00:00:00.000Z"
     * 4.  Assert that the count in the results object list is x.  This count could change over time so may need update test as things change
    */

    /*
    * Test 9: 
    * Assert that the POST rate movie endpoint receives a 200 response, verify response body
    * 1.  Send call to POST endpoint 3/movie/{movieId}/rating?api_key={apiKey} where movie id is 274
    * 2.  Assert that response code is 200
    * 3.  Assert that in the response body status_code and status_message are correct
    */

    /*
    * Test 10: 
    * Assert that the POST rate movie endpoint receives a 404 response, invalid request body, verify response body
    * 1.  Send call to POST endpoint 3/movie/{movieId}/rating?api_key={apiKey} where movie id is 274, use invalid request body
    * 2.  Assert that response code is 404
    * 3.  Assert that in the response body status_code and status_message are correct
    */

    /*
    * Test 11: 
    * Assert that the DELETE moving rating endpoint receives a 200 response, verify response body
    * 1.  Send call to DELETE endpoint 3/movie/{movieId}/rrating?api_key={apiKey} where movie id is 274
    * 2.  Assert that response code is 200
    * 3.  Assert that in the response body status_code and status_message are correct
    */

    /*
    * Test 12: 
    * Assert that the POST rate endpoint receives a 401 response, no guest_session_id in query string, verify response body
    * 1.  Send call to get endpoint 3/movie/{movieId}/rrating?api_key={apiKey} where movie id is 274
    * 2.  Assert that response code is 401
    * 3.  Assert that in the response body status_code and status_message are correct
    */
    [TestInitialize]
    public void Setup()
    {

    }
    //[TestMethod]
    //public void GetMovieDetailsSuccess()
    //{
    //  /*
    //   * Assert that the GET movie endpoint receives a 200 response, verify response body
    //   * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US where movie id is 274
    //   * 2.  Assert that response code is 200
    //   * 3.  Assert that the movie title is correct
    //   */
    //  //new requests object
    //  Requests requests = new Requests();
    //  //send get call with appropriate endpoint and apikey
    //  var response = requests.Get(Endpoint: string.Format(@"3/movie/{0}?api_key={1}&language=en-US", "274", apiKey));
    //  MovieDetailsResponse detailsObject = null;

    //  try
    //  {
    //    //deserialize json response
    //    detailsObject = JsonConvert.DeserializeObject<MovieDetailsResponse>(response.Content.ReadAsStringAsync().Result);
    //  }
    //  catch (JsonReaderException jsonEx)
    //  {
    //    //fail test if deserialization fails
    //    Assert.Fail(string.Format("Unable to deserialize response.  Exception: {0}"), jsonEx);
    //  }
    //  //assert that response has a 200 OK code
    //  Assert.AreEqual(200, (int)response.StatusCode);
    //  //assert that the movie title is correct in the response body
    //  Assert.AreEqual("The Silence of the Lambs", detailsObject.title);
    //}
    [TestMethod]
    public void GetMovieDetailsSuccess1()
    {
      /*
       * Assert that the GET movie endpoint receives a 200 response, verify response body
       * 1.  Send call to get endpoint 3/movie/{movieId}?api_key={apiKey}&language=en-US where movie id is 274
       * 2.  Assert that response code is 200
       * 3.  Assert that the movie title is correct
       */
      //new requests object
      APIs api = new APIs();
      //send get call with appropriate endpoint and apikey
      //var response = requests.Get(Endpoint: string.Format(@"3/movie/{0}?api_key={1}&language=en-US", "274", apiKey));
      var response = api.Movies.MovieDetails(MovieId: "274").Get();
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
      //assert that the movie title is correct in the response body
      Assert.AreEqual("The Silence of the Lambs", detailsObject.title);
    }

    [TestMethod]
    public void PostMovieRatingSuccess()
    {
      /*
      * Test 9: 
      * Assert that the POST rate movie endpoint receives a 200 response, verify response body
      * 1.  Send call to POST endpoint 3/movie/{movieId}/rating?api_key={apiKey} where movie id is 274
      * 2.  Assert that response code is 200
      * 3.  Assert that in the response body status_code and status_message are correct
      */

      /*
       *1.  Send call to POST endpoint 3/movie/274/rating?api_key=apiKey
       *2.  Deserialize json response
       *3.  Fail test if deserialization fails
       *4.  Assert that response code is 200
       *5.  Assert that status_code is correct in response body
       *6.  Assert that status_message is correct in response body
       *7.  Send Get Account States call for movie 274 and assert that rated object is correct
       */
    }
  }
}
