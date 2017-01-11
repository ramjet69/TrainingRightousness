using System.ComponentModel.DataAnnotations;

namespace TrainRightApi.Models
{
    public class SinSectionHeader
    {
        [Key]
        public int Id { get; set; }
        public int SubCatId { get; set; }

        public string PageTitle { get; set; }

        public string PageComments { get; set; }

        public string PageQuote { get; set; }
        
    }
}
