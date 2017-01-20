using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainRightApi.Models
{
    public class SeeAlso
    {

        public List<string> SelectedCategories { get; set; }

        public List<SinSubCategory> AvailableCategories { get; set; }

        public string SinCat { get; set; }

    }
}