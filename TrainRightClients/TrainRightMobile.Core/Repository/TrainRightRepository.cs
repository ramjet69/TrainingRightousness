using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TrainRightMobile.Core.Repository
{
    public class TrainRightRepository
    {
        //private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();
        string url = "";

        public TrainRightRepository()
        {
            Task.Run(() => LoadDataAsync(url)).Wait();
        }

        private async Task LoadDataAsync(string uri)
        {
            //if (hotDogGroups != null)
            if(true)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                        HttpResponseMessage response = await getResponse;
                        responseJsonString = await response.Content.ReadAsStringAsync();
                        //hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(responseJsonString);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }
        }



    }
}
