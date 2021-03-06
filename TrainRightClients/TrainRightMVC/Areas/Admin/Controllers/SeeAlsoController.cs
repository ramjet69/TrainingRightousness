﻿using Kendo.Mvc.Extensions;
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
    [RoutePrefix("Admin/SeeAlso")]
    public class SeeAlsoController : Controller
    {
        private string baseuri = ConfigurationManager.AppSettings["BaseUrl"];
        private string url = "";
        private HttpClient client;

        public SeeAlsoController()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(this.baseuri);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Route("{id}")]
        public async Task<ActionResult> UpdateSeeAlso(SeeAlso commands, string id)
        {

            if (commands == null || !ModelState.IsValid)
            {
                return Json(ModelStateExtensions.ToDataSourceResult(ModelState));
            }
            commands.SinCat = id;
            HttpResponseMessage httpResponseMessage = await HttpClientExtensions.PostAsync(client, baseuri + "api/SeeAlso/Update", commands, new JsonMediaTypeFormatter());

            if (!httpResponseMessage.IsSuccessStatusCode)
                Json("[{Error}]");

            return PartialView();

        }


    }
}