using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5Model.Models
{
    public class Product
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        
        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "money")]
        public decimal SellPrice { get; set; }

        public List<Purchase>? Purchases { get; set; }
        public List<Sale>? Sales { get; set; }
        public List<Inventory>? inventoryList { get; set; }

    }
}
