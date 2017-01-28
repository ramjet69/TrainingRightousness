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

        public List<SinSubCategory> GetSinSubCategoriesById(int id)
        {
            return trainRightRepository.GetSinSubCategories(id);
        }

        public List<SinSection> GetSinSections()
        {
            return trainRightRepository.GetSinSections();
        }

        public SinSectionHeader GetSinSectionHeader(int id)
        {
            return trainRightRepository.GetSinSectionHeader(id);
        }


    }
}
