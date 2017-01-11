using System.ComponentModel.DataAnnotations;

namespace TrainRightApi.Models
{
    public class BaseCommands
    {
        [Key]
        public int Id { get; set; }

        public int SubCatId { get; set; }

        public string BibleBook { get; set; }

        public string BibleBookAbbr { get; set; }

        public string VerseNumber { get; set; }

        public string Verse { get; set; }

    }
}