using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Systems.Data.Core.Domain
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime orderDate { get; set; }
        [Required]
        public int customerID { get; set; }
        [Required]
        public int employeeID { get; set; }
        [StringLength(100)]
        public string shipAddress { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
    }
}
