using System.Collections.Generic;
using TrainRightMobile.Core.Repository;

namespace TrainRightApi.TrainRightMobile.Core.Repository
{
    public class SinCategory
    {

        public SinCategory()
        {
            SinSubCategory = new List<SinSubCategory>();
        }

        
        public int Id { get; set; }

        public string SinCategoryName { get; set; }

        public virtual ICollection<SinSubCategory> SinSubCategory { get; set; }
    }
}
