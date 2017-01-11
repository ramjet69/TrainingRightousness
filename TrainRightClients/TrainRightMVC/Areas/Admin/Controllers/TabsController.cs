using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrainRightMVC.Areas.Admin.Models;
using TrainRightMVCommon.Helpers;


namespace TrainRightMVC.Areas.Admin.Controllers
{
    [RoutePrefix("Admin/Tabs")]
    public class TabsController : Controller
    {
        private string baseuri = ConfigurationManager.AppSettings["BaseUrl"];
        private string url = ConfigurationManager.AppSettings["TabSection"];
        private string url2 = ConfigurationManager.AppSettings["Tabs"];
        private string url3 = ConfigurationManager.AppSettings["SinSubCat"];
        private HttpClient client;

        public TabsController()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(this.baseuri);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Route("SeeAlso/{subcat}")]
        public async Task<ActionResult> SeeAlso(string subcat)
        {
            HttpResponseMessage responseMessage = await this.client.GetAsync(this.baseuri + this.url + "SeeAlso/" + subcat);
            HttpResponseMessage async = await this.client.GetAsync(this.baseuri + this.url3);
            SeeAlso seeAlso = new SeeAlso();
            if (async.IsSuccessStatusCode)
            {
                string result = async.Content.ReadAsStringAsync().Result;
                seeAlso.AvailableCategories = (List<SinSubCategories>)JsonConvert.DeserializeObject<List<SinSubCategories>>(result);
            }
            if (responseMessage.IsSuccessStatusCode)
            {
                var m0 = JsonConvert.DeserializeObject<List<SinSubCatCrossRef>>(responseMessage.Content.ReadAsStringAsync().Result);
                List<SinSubCategories> sinSubCategoriesList = new List<SinSubCategories>();
                foreach (SinSubCatCrossRef sinSubCatCrossRef in (List<SinSubCatCrossRef>)m0)
                {
                    SinSubCatCrossRef item = sinSubCatCrossRef;
                    IEnumerable<SinSubCategories> source = seeAlso.AvailableCategories.Where<SinSubCategories>((Func<SinSubCategories, bool>)(c => c.Id == item.CrossSubCatId));
                    sinSubCategoriesList.Add(new SinSubCategories()
                    {
                        SubCategoryName = source.First<SinSubCategories>().SubCategoryName,
                        Id = source.First<SinSubCategories>().Id
                    });
                }
                seeAlso.AvailableCategories = sinSubCategoriesList;
            }
            return (ActionResult)this.View("~/Areas/Admin/Views/Tabs/SeeAlso.cshtml", (object)seeAlso);
        }

        [Route("InfoCommand/{subcat}")]
        public ActionResult GeneralInformation()
        {
            return (ActionResult)this.View("~/Areas/Admin/Views/Tabs/GeneralInfo.cshtml");
        }

        [Route("WhatHappens/{subcat}")]
        public async Task<ActionResult> WhatHappens(string subcat)
        {
            HttpResponseMessage async = await this.client.GetAsync(this.baseuri + this.url + "WhatHappens/" + subcat);
            List<WhatHappens> whatHappensList = new List<WhatHappens>();
            if (async.IsSuccessStatusCode)
                whatHappensList = (List<WhatHappens>)JsonConvert.DeserializeObject<List<WhatHappens>>(async.Content.ReadAsStringAsync().Result);
            return (ActionResult)this.View("~/Areas/Admin/Views/Tabs/WhatHappens.cshtml", (object)whatHappensList);
        }

        [Route("Repentance/{subcat}")]
        public async Task<ActionResult> Repentance(string subcat)
        {
            HttpResponseMessage async = await this.client.GetAsync(this.baseuri + this.url + "Repentance/" + subcat);
            List<Repentance> repentanceList = new List<Repentance>();
            if (async.IsSuccessStatusCode)
                repentanceList = (List<Repentance>)JsonConvert.DeserializeObject<List<Repentance>>(async.Content.ReadAsStringAsync().Result);
            return (ActionResult)this.View("~/Areas/Admin/Views/Tabs/Repentance.cshtml", (object)repentanceList);
        }

        [Route("LikenedTo")]
        public ActionResult LikenedTo()
        {
            return (ActionResult)this.View();
        }

        [Route("Blessing")]
        public ActionResult Blessing()
        {
            return (ActionResult)this.View();
        }

        [Route("Illustration")]
        public ActionResult Illustration()
        {
            return (ActionResult)this.View();
        }

        [Route("Verses")]
        public ActionResult Verses()
        {
            return (ActionResult)this.View();
        }
    }
}