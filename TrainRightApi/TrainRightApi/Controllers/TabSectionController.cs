using System.Web.Http;
using TrainRightApi.Models;
using TrainRightApi.Repository;

namespace TrainRightApi.Controllers
{
    [RoutePrefix("api/TabSection")]
    public class TabSectionController : BaseApiController
    {
        private ITrainRightRepository _repository;

        public TabSectionController(ITrainRightRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("SeeAlso/{subcat}")]
        public IHttpActionResult SeeAlso(string subcat)
        {
            return Ok(_repository.GetSeeAlso(subcat));
        }

        [HttpGet]
        [Route("SeeAlso/mobile/{subid}")]
        public IHttpActionResult SeeAlso(int subid)
        {
            return Ok(_repository.GetSeeAlso(subid));
        }

        [HttpGet]
        [Route("InfoCommands/{subcat}")]
        public IHttpActionResult InfoCommands(string subcat)
        {
            return Ok(_repository.GetInfoCommands(subcat));
        }

        [HttpGet]
        [Route("WhatHappens/{subcat}")]
        public IHttpActionResult WhatHappens(string subcat)
        {
            return Ok(_repository.GetWhatHappens(subcat));
        }

        [HttpGet]
        [Route("WhatHappens/mobile/{subid}")]
        public IHttpActionResult WhatHappens(int subid)
        {
            return Ok(_repository.GetWhatHappens(subid));
        }



        [HttpGet]
        [Route("Repentance/{subcat}")]
        public IHttpActionResult Repentance(string subcat)
        {
            return Ok(_repository.GetRepentance(subcat));
        }

        [HttpPost]
        [Route("UpdateDetails/{subcat}")]
        public IHttpActionResult UpdateTabDetail(string subcat, [FromBody] InfoCommands details)
        {
            return Ok(_repository.UpdateInfoCommands(details));
        }

        [HttpPost]
        [Route("CreateDetails/{subcat}")]
        public IHttpActionResult CreateTabDetail(string subcat, [FromBody] InfoCommands details)
        {
            return Ok(_repository.CreateInfoCommands(details));
        }
    }
}