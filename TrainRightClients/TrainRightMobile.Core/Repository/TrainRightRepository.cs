using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TrainRightMobile.Core.Models;

namespace TrainRightMobile.Core.Repository
{
    public class TrainRightRepository
    {
        string _url = "http://169.254.80.80:8080/api/SinCat";
        

        public TrainRightRepository()
        {
            
        }



        public List<SinCategory> GetSinCategories()
        {
            List<SinCategory> sinCategories;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Task<HttpResponseMessage> getResponse = client.GetAsync(_url + "?getsubs=false");
                    HttpResponseMessage response = getResponse.Result;
                    var responseJsonString = response.Content.ReadAsStringAsync();
                    sinCategories = JsonConvert.DeserializeObject<List<SinCategory>>(responseJsonString.Result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return sinCategories;
        }
    }
}
