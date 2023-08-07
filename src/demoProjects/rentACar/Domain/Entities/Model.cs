using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity
    {
        public int BrandId { get; set; }
        public int Id { get; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public virtual Brand? Brand { get; set; }  //virtual bir çok orm ile kullanılmasını sağlar

        public Model()
        {
            
        }
        public Model(int id,int brandId,string name,decimal dailyPrice,string imageUrl): this()
        {
            Id = id;
            BrandId = brandId;
            Name = name;
            ImageUrl = imageUrl;
            Name = name;
        }
    }
}
  