using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Systems.Data.Core.Domain
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [Required]
        public double price { get; set; }
        public int categoryID { get; set; }
        public int supplierID { get; set; }
        public int quantity { get; set; }

        public virtual Category category { get; set; }
        public virtual Supplier supplier { get; set; }
    }
}
