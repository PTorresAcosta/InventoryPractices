using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice5Model.Models;

namespace Practice5Model.DTO
{
    public class SaleProductDTO
    {
        public Sale Sales { get; set; }
        public Product Products { get; set; }

    }
}
