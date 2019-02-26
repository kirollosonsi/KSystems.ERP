using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Presentation.Web.Models.ViewModel
{
    public class OrderHomeViewModel
    {
        public IEnumerable<Order> orders { get; set; }
        public Order order { get; set; }
        public TablePageInfo pageInfo { get; set; }
        public int totalPages { get; set; }
        public SelectListItem[] pageItems { get; set; }

        public OrderHomeViewModel()
        {
            pageItems = new SelectListItem[]
            {
                new SelectListItem{Text="10",Value="10"},
                new SelectListItem{Text="20",Value="20"},
                new SelectListItem{Text="30",Value="30"},
            };

        }
    }
}