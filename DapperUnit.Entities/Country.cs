﻿using DapperUnit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperUnit.Entities
{
    public class Country : IEntity, IDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }   
        public bool Deleted { get; set; }

        public List<Pirate> Pirates { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
