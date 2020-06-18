using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genres2020.Models
{
    public class ProductModel
    {
        public string ProductCode { get; set; }

        public string ProductTitle { get; set; }

        public string ProductDescription { get; set; }

        public double UnitPrice { get; set; }

        public double YourPrice { get; set; }

        public string CategoryName { get; set; }

        public string ProductAgeRating { get; set; }

        public int? ProductLength { get; set; }

        public int? ProductYearCreated { get; set; }

        public string MediumName { get; set; }

        public string PublisherName { get; set; }

        public string ProductImageURL { get; set; }

        public bool OnSale { get; set; }

        public int RatingID { get; set; }
    }
}
