using System;
using RestSharp;

namespace UnitTestDemo
{
    public class AirportService
    {
        private RestClient _client;

        public AirportService()
        {
            _client = new RestClient("http://flydata.avinor.no");    
        }

        public void GetAirports(Action<string> callback)
        {
            var request = new RestRequest("airportNames.asp");
            _client.ExecuteAsync(request, result => callback(result.Content));
        }
    }
}