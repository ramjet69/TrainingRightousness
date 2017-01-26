using System.Collections.Generic;

namespace TrainRightMobile.Core.Models
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
