using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Systems.Data.Core.Domain
{
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        public string name { get; set; }
        [StringLength(20)]
        public string phone { get; set; }
        [StringLength(100)]
        public string address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
