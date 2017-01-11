using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrainRightApi.Models
{
    public class SinSection
    {

        [Key]
        public int Id { get; set; }
        
        public string SectionName { get; set; }
        
        public string SectionRouteName { get; set; }

    }
}
