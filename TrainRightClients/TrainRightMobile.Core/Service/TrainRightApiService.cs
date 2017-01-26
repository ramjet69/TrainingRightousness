using System.Collections.Generic;
using System.Threading.Tasks;
using TrainRightMobile.Core.Models;
using TrainRightMobile.Core.Repository;

namespace TrainRightMobile.Core.Service
{
    public class TrainRightApiService
    {
        private static TrainRightRepository trainRightRepository = new TrainRightRepository();

        public TrainRightApiService()
        {
        }

        public List<SinCategory> GetSinCategories()
        {
            return trainRightRepository.GetSinCategories();
        }


    }
}
