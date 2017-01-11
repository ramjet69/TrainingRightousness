using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainRightMVC.Areas.Admin.Models
{
    public class SinSectionHeader
    {
        public string PageTitle { get; set; }

        public string PageComments { get; set; }

        public string PageQuote { get; set; }

        public List<SinSubCrossRefs> SeeAlsoCategories { get; set; }

        public List<SinSections> TabNames { get; set; }
    }
}