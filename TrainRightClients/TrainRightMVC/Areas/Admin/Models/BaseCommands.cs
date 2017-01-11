using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainRightMVC.Areas.Admin.Models
{
    public class BaseCommands
    {
        public int Id { get; set; }

        public int SubCatId { get; set; }

        public string BibleBook { get; set; }

        public string BibleBookAbbr { get; set; }

        public string VerseNumber { get; set; }

        public string Verse { get; set; }

    }
}