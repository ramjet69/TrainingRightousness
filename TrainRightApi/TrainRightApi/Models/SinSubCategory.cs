using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainRightApi.Models;

namespace TrainRightApi.Models
{
    public class SinSubCategory
    {
        
        [Key]
        public int Id { get; set; }

        public string SubCategoryName { get; set; }

        public int SinCategoryId { get; set; }
        
    }
}
