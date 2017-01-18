﻿using System.ComponentModel.DataAnnotations;

namespace TrainRightApi.Models
{
    public class SinSubCatCrossRef
    {
        
        public int Id { get; set; }

        public int SubCatId { get; set; }
        
        public int CrossSubCatId { get; set; }

    }
}
