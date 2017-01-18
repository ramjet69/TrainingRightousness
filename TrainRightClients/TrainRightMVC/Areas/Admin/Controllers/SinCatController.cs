using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainRightMVC.Areas.Admin.Models;
using TrainRightMVCommon.Helpers;

namespace TrainRightMVC.Areas.Admin.Controllers
{
    public class SinCatController : Controller
    {
        private string baseuri = ConfigurationManager.AppSettings["BaseUrl"];
        private string url = ConfigurationManager.AppSettings["SinCat"];
        private string url2 = ConfigurationManager.AppSettings["SinSubCatByCatId"];
        private HttpClient client;

        public SinCatController()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(this.baseuri);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View("SinCatSubCat");
        }

        public async Task<JsonResult> GetSinCategories([DataSourceRequest] DataSourceRequest request, bool? getsubs)
        {
            bool? nullable = getsubs;
            HttpResponseMessage async = await client.GetAsync(baseuri + url + "?getsubs=" + (!nullable.HasValue || nullable.GetValueOrDefault()).ToString());
            return !async.IsSuccessStatusCode ? Json("[{Error}]") : Json(QueryableExtensions.ToDataSourceResult(JsonConvert.DeserializeObject<List<SinCategories>>(async.Content.ReadAsStringAsync().Result), request));
        }



        public async Task<JsonResult> GetSinSubCategories([DataSourceRequest] DataSourceRequest request, int? categoryid)
        {
            int num = categoryid ?? -9999;
            if (num == -9999)
                return Json("[{Error -9999 for categoryId}]");
            HttpResponseMessage async = await client.GetAsync(baseuri + url2 + "?id=" + num);
            return !async.IsSuccessStatusCode ? Json("Error") : Json(QueryableExtensions.ToDataSourceResult(JsonConvert.DeserializeObject<List<SinSubCategories>>(async.Content.ReadAsStringAsync().Result), request));
        }



        [HttpPost]
        public async Task<JsonpResult> AddNewSubCategory([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")] IEnumerable<SinSubCategories> sincats)
        {
            if (ModelState.IsValid)
            {
                client.BaseAddress = new Uri(baseuri + url2);
                if ((await HttpClientExtensions.PostAsJsonAsync(client, baseuri + url2, sincats)).IsSuccessStatusCode)
                    return ControllerExtensions.Jsonp(this, sincats, "callback");
            }
            return ControllerExtensions.Jsonp(this, "[{Error Updating}]", "callback");
        }


    }
}
