using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Presentation.Web.Models.ViewModel
{
    public class CourseHomeViewModel
    {
        public Course[] courses { get; set; }
        public Course course { get; set; }
        public string search { get; set; }
        public string sortBy { get; set; }
        public string order { get; set; }
        public int page { get; set; }
        public int items { get; set; }
        public int totalPages { get; set; }
        public SelectListItem[] pageItems { get; set; }

        public CourseHomeViewModel(string sortBy, string order)
        {
            this.order = order;
            this.sortBy = sortBy;

            pageItems = new SelectListItem[]
            {
                new SelectListItem{Text="10",Value="10",Selected= items.ToString() == "10"},
                new SelectListItem{Text="20",Value="20",Selected= items.ToString() == "20"},
                new SelectListItem{Text="30",Value="30",Selected= items.ToString() == "30"},
            };
        }
    }
}