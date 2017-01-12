﻿using System.Collections.Generic;
using System.Web.Http;
using TrainRightApi.Models;
using TrainRightApi.Repository;

namespace TrainRightApi.Controllers
{
    [RoutePrefix("api/SinCat")]
    public class SinCategoryController : BaseApiController
    {
        private ITrainRightRepository _repository;

        public SinCategoryController(ITrainRightRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get([FromUri] bool? getsubs)
        {
            bool? nullable = getsubs;
            return Ok(_repository.GetAllSinCategories(!nullable.HasValue || nullable.GetValueOrDefault()));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_repository.GetSinCategorybyId(id, true));
        }

        [HttpGet]
        [Route("SinSubCatByCatId")]
        public IHttpActionResult GetSubCategoriesByCatId([FromUri] int catid)
        {
            return Ok(_repository.GetSinSubCategorisbyCatId(catid));
        }

        public IHttpActionResult Post([FromBody] SinCategory mdl)
        {
            return (IHttpActionResult)null;
        }
    }
}