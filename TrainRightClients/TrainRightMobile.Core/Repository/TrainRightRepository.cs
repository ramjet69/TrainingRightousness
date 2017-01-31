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
        string _url = "http://169.254.80.80:8080";
        

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
                    Task<HttpResponseMessage> getResponse = client.GetAsync(_url + "/api/SinCat?getsubs=false");
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


        public List<SinSubCategory> GetSinSubCategories(int id)
        {
            List<SinSubCategory> sinSubCategories;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Task<HttpResponseMessage> getResponse = client.GetAsync(_url + "/api/SinSubCat?id=" + id);
                    HttpResponseMessage response = getResponse.Result;
                    var responseJsonString = response.Content.ReadAsStringAsync();
                    sinSubCategories = JsonConvert.DeserializeObject<List<SinSubCategory>>(responseJsonString.Result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return sinSubCategories;
        }


        public List<SinSection> GetSinSections()
        {
            List<SinSection> sinSection;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Task<HttpResponseMessage> getResponse = client.GetAsync(_url + "/api/SinSubCat/SinDetails/Tabs");
                    HttpResponseMessage response = getResponse.Result;
                    var responseJsonString = response.Content.ReadAsStringAsync();
                    sinSection = JsonConvert.DeserializeObject<List<SinSection>>(responseJsonString.Result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return sinSection;
        }


        public SinSectionHeader GetSinSectionHeader(int id)
        {
            SinSectionHeader sinSectionHeader;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Task<HttpResponseMessage> getResponse = client.GetAsync(_url + "/api/SinSubCat/SinDetails/" + id);
                    HttpResponseMessage response = getResponse.Result;
                    var responseJsonString = response.Content.ReadAsStringAsync();
                    sinSectionHeader = JsonConvert.DeserializeObject<SinSectionHeader>(responseJsonString.Result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return sinSectionHeader;
        }

        public SeeAlso GetSeeAlso(int id)
        {
            SeeAlso seeAlso;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Task<HttpResponseMessage> getResponse = client.GetAsync(_url + "/api/TabSection/SeeAlso/mobile/" + id);
                    HttpResponseMessage response = getResponse.Result;
                    var responseJsonString = response.Content.ReadAsStringAsync();
                    seeAlso = JsonConvert.DeserializeObject<SeeAlso>(responseJsonString.Result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return seeAlso;
        }

        public List<WhatHappens> GetWhatHappens(int id)
        {
            List<WhatHappens> whatHappens;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    Task<HttpResponseMessage> getResponse = client.GetAsync(_url + "/api/TabSection/WhatHappens/mobile/" + id);
                    HttpResponseMessage response = getResponse.Result;
                    var responseJsonString = response.Content.ReadAsStringAsync();
                    whatHappens = JsonConvert.DeserializeObject<List<WhatHappens>>(responseJsonString.Result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return whatHappens;
        }


    }
}
