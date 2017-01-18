using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainRightMVC.Areas.Admin.Models;

namespace TrainRightMVC.Areas.Admin.Controllers
{
    [RoutePrefix("Admin/SinSubCat")]
    public class SinSubCatController : Controller
    {
        private string baseuri = ConfigurationManager.AppSettings["BaseUrl"];
        private string url = ConfigurationManager.AppSettings["SinDetails"];
        private string url2 = ConfigurationManager.AppSettings["Tabs"];
        private HttpClient client;

        public SinSubCatController()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(this.baseuri);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Route("SinSubCatDetails/{id?}")]
        public async Task<ActionResult> SinSubCatDetails(int? id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(baseuri + url + id);

            HttpResponseMessage async = await client.GetAsync(baseuri + url2);

            if (!responseMessage.IsSuccessStatusCode)
                return (ActionResult)null;
            SinSectionHeader sinSectionHeader = (SinSectionHeader)JsonConvert.DeserializeObject<SinSectionHeader>(responseMessage.Content.ReadAsStringAsync().Result);
            string result = async.Content.ReadAsStringAsync().Result;
            sinSectionHeader.TabNames = (List<SinSections>)JsonConvert.DeserializeObject<List<SinSections>>(result);
            return (ActionResult)this.View("~/Areas/Admin/Views/SinSubCat/SinSubCatDetails.cshtml", (object)sinSectionHeader);
        }
    }
}