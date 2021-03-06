﻿using System.Web.Http;
using TrainRightApi.Models;
using TrainRightApi.Repository;

namespace TrainRightApi.Controllers
{
    [RoutePrefix("api/SeeAlso")]
    public class SeeAlsoController : BaseApiController
    {
        private ITrainRightRepository _repository;

        public SeeAlsoController(ITrainRightRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Post([FromBody] SeeAlso mdl)
        {
            return Ok(_repository.UpdateSeeAlso(mdl));
        }


    }
}