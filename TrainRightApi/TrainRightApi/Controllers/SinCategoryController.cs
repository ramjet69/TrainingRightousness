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
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAllSinCategories());
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get([FromUri] int id)
        {
            return Ok(_repository.GetSinCategorybyId(id));
        }

        public IHttpActionResult Post([FromBody] SinCategory mdl)
        {
            return (IHttpActionResult)null;
        }
    }
}