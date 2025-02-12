﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }

        public Brand()
        {
            //constructorların hepsinde olması gereken yapıları buraya yazabiliriz.
        }

        public Brand(int id,string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
 