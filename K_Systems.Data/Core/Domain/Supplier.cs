using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Systems.Data.Core.Domain
{
    public class Supplier
    {

        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        public string companyName { get; set; }
        [StringLength(50)]
        [Required]
        public string contactName { get; set; }
        [StringLength(50)]
        public string address { get; set; }
        [StringLength(20)]
        public string mobile { get; set; }
        [StringLength(300)]
        public string extraInfo { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
