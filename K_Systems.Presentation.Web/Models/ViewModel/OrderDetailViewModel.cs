using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Presentation.Web.Models.ViewModel
{
    public class OrderDetailViewModel
    {
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public K_Systems.Data.Core.Domain.Order order { get; set; }

    }
}