using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Systems.Data.Core.Domain
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [StringLength(300)]
        public string description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
