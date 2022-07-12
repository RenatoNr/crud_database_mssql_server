
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDB.models
{
    internal class Product
    {
        public Guid IdProduct { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = String.Empty ;
        public string Description { get; set; } = String.Empty;
        public decimal Price { get; set; }

    }
}
