using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
