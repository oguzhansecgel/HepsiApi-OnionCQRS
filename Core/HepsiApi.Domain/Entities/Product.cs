using HepsiApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Domain.Entities
{
    public class Product :EntityBase
    {
        public Product()
        {
            
        }
        public Product(string title,string description,int brandID,decimal price,decimal discount)
        {
            Title = title;
            Description = description;
            BrandID = brandID;
            Price = price;
            Discount = discount;
        }
        public string Title { get; set; }
        public string Description { get; set; }

        //public required string ImagePath { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
