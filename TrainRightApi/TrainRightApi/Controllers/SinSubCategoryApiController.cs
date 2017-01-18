using System.Collections.Generic;
using System.Web.Http;
using TrainRightApi.Models;
using TrainRightApi.Repository;

namespace TrainRightApi.Controllers
{
    [RoutePrefix("api/SinSubCat")]
    public class SinSubCategoryApiController : BaseApiController
    {
        private ITrainRightRepository _repository;

        public SinSubCategoryApiController(ITrainRightRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAllSubCategories());
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_repository.GetSinSubCategoriesbyId(id));
        }

        [HttpGet]
        [Route("SinDetails/{id}")]
        public IHttpActionResult GetSinDetails([FromUri] int id)
        {
            return Ok(_repository.GetSinSectionHeader(id));
        }

        [HttpGet]
        [Route("SinDetails/Tabs")]
        public IHttpActionResult GetSinSectionTabs()
        {
            return Ok(_repository.GetSinSectionTabs());
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] IEnumerable<SinSubCategory> mdls)
        {
            return null;
        }
    }
}
