using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_Systems.Data.Core.Domain
{
    public class OrderDetail
    {
        [Key ,Column(Order = 0)]
        public int orderID { get; set; }
        [Key, Column(Order = 1)]
        public int productID { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
