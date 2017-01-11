using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainRightMVC.Areas.Admin.Models
{
    public class SinCategories
    {
        
        public SinCategories()
        {
            SinSubCategory = new List<SinSubCategories>();
        }

        public int Id { get; set; }

        public string SinCategoryName { get; set; }

        public ICollection<SinSubCategories> SinSubCategory { get; set; }

    }
}