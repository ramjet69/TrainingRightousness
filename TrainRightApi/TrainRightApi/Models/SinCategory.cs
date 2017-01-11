using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainRightApi.Models
{
    public class SinCategory
    {

        public SinCategory()
        {
            SinSubCategory = new List<SinSubCategory>();
        }

        [Key]
        public int Id { get; set; }

        public string SinCategoryName { get; set; }

        public virtual ICollection<SinSubCategory> SinSubCategory { get; set; }
    }
}
