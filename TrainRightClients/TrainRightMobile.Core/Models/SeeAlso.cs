using System.Collections.Generic;

namespace TrainRightMobile.Core.Models
{
    public class SeeAlso
    {

        public List<string> SelectedCategories { get; set; }

        public List<SinSubCategory> AvailableCategories { get; set; }

        public string SinCat { get; set; }

    }
}
