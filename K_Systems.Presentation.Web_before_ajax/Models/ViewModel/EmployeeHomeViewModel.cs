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
        public Employee[] employees { get; set; }
        public Employee employee { get; set; }
        public string search { get; set; }
        public string sortBy { get; set; }
        public string order { get; set; }
        public int page { get; set; }
        public int items { get; set; }
        public int totalPages { get; set; }
        public SelectListItem[] orderItems { get; set; }
        public SelectListItem[] sortByItems { get; set; }
        public SelectListItem[] pageItems { get; set; }

        public EmployeeHomeViewModel(string sortBy, string order)
        {
            this.order = order;
            this.sortBy = sortBy;
            orderItems = new SelectListItem[]
            {
                new SelectListItem{Text="Asending",Value="asc",Selected=order == "asc"},
                new SelectListItem{Text="Descending",Value="dsc",Selected=order == "dsc"}
            };

            sortByItems = new SelectListItem[]
            {
                new SelectListItem{Text="ID",Value="id",Selected= sortBy == "id"},
                new SelectListItem{Text="First Name",Value="fName",Selected= sortBy == "fName"},
                new SelectListItem{Text="Last Name",Value="lName",Selected= sortBy == "lName"},
                new SelectListItem{Text="Phone",Value="phone",Selected= sortBy == "phone"},
                new SelectListItem{Text="E-mail",Value="email",Selected= sortBy == "email"},

            };

            pageItems = new SelectListItem[]
            {
                new SelectListItem{Text="10",Value="10",Selected= items.ToString() == "10"},
                new SelectListItem{Text="20",Value="20",Selected= items.ToString() == "20"},
                new SelectListItem{Text="30",Value="30",Selected= items.ToString() == "30"},

            };

        }
    }
}