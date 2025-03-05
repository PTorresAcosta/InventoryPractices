﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5Model.Models
{
    public class Inventory
    {

        public int InventoryId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product product { get; set; }


    }
}
