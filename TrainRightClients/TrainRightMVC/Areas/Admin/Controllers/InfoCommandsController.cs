using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainRightMVC.Areas.Admin.Models;

namespace TrainRightMVC.Areas.Admin.Controllers
{
    [RoutePrefix("Admin/InfoCommands")]
    public class InfoCommandsController : Controller
    {
        private string baseuri = ConfigurationManager.AppSettings["BaseUrl"];
        private string url = ConfigurationManager.AppSettings["TabSection"];
        private string url2 = ConfigurationManager.AppSettings["TabUpdate"];
        private string url3 = ConfigurationManager.AppSettings["TabCreate"];
        private HttpClient client;

        public InfoCommandsController()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(this.baseuri);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> General_Update([DataSourceRequest] DataSourceRequest request, InfoCommands commands)
        {
            if (commands == null || !this.ModelState.IsValid)
            {
                return (ActionResult)this.Json(ModelStateExtensions.ToDataSourceResult(this.ModelState));
            }


            HttpResponseMessage httpResponseMessage = await HttpClientExtensions.PostAsync<InfoCommands>(this.client, this.baseuri + this.url2 + "InfoCommands", commands, (MediaTypeFormatter)new JsonMediaTypeFormatter());

            return !httpResponseMessage.IsSuccessStatusCode ? (ActionResult)this.Json((object)"[{Error}]") : (ActionResult)this.Json((object)QueryableExtensions.ToDataSourceResult((IEnumerable)JsonConvert.DeserializeObject<List<InfoCommands>>(httpResponseMessage.Content.ReadAsStringAsync().Result), request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> General_Create([DataSourceRequest] DataSourceRequest request, InfoCommands commands)
        {
            if (commands == null || !this.ModelState.IsValid)
                return (ActionResult)this.Json(ModelStateExtensions.ToDataSourceResult(this.ModelState));
            commands.SubCatId = 1;
            HttpResponseMessage httpResponseMessage = await HttpClientExtensions.PostAsync<InfoCommands>(this.client, this.baseuri + this.url3 + "InfoCommands", commands, (MediaTypeFormatter)new JsonMediaTypeFormatter());
            return !httpResponseMessage.IsSuccessStatusCode ? (ActionResult)this.Json((object)"[{Error}]") : (ActionResult)this.Json((object)QueryableExtensions.ToDataSourceResult((IEnumerable)JsonConvert.DeserializeObject<List<InfoCommands>>(httpResponseMessage.Content.ReadAsStringAsync().Result), request));
        }

        public ActionResult General_Read([DataSourceRequest] DataSourceRequest request, string subcat)
        {
            HttpResponseMessage result = this.client.GetAsync(this.baseuri + this.url + "InfoCommands/" + subcat).Result;
            List<InfoCommands> infoCommandsList = new List<InfoCommands>();
            if (result.IsSuccessStatusCode)
                return (ActionResult)this.Json((object)QueryableExtensions.ToDataSourceResult((IEnumerable)JsonConvert.DeserializeObject<List<InfoCommands>>(result.Content.ReadAsStringAsync().Result), request));
            return (ActionResult)this.Json((object)"[{Error}]");
        }
    }
}