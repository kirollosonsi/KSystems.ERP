using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Presentation.Web.Models.ViewModel
{
    public class EmployeeHomeViewModel
    {
        public IEnumerable<Employee> employees { get; set; }
        public Employee employee { get; set; }
        public TablePageInfo pageInfo { get; set; }
        public int totalPages { get; set; }
        public SelectListItem[] pageItems { get; set; }

        public EmployeeHomeViewModel()
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