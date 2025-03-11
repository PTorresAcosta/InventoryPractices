using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Practice5Model.Models
{
    public class Purchase
    {
        [Key]
        public int? PurchaseId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
        public DateTime PurchaseDate { get; set; }

    }
}
