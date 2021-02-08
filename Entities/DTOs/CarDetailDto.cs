using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public int ColourId { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ColourName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
