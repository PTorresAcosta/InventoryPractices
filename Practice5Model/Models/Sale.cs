using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Practice5Model.Models
{
    public class Sale
    {

        [Key]
        public int? SaleId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
