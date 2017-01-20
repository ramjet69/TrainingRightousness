using System.Collections.Generic;

namespace TrainRightMVC.Areas.Admin.Models
{
    public class SeeAlso
    {
        public List<string> SelectedCategories { get; set; }

        public List<SinSubCategories> AvailableCategories { get; set; }

        public string SinCat { get; set; }

    }
}