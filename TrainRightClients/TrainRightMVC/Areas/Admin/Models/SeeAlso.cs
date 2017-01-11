using System.Collections.Generic;

namespace TrainRightMVC.Areas.Admin.Models
{
    public class SeeAlso
    {
        public List<int> SelectedCategories { get; set; }

        public List<SinSubCategories> AvailableCategories { get; set; }
    }
}