using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public List<Purchase>? Purchases { get; set; }

        [JsonIgnore]
        public List<Sale>? Sales { get; set; }

        [JsonIgnore]
        public List<Inventory>? inventoryList { get; set; }

    }
}
