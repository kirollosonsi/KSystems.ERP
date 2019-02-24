using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_Systems.Data.Core.Domain
{
    public class TablePageInfo
    {
        public string search { get; set; }
        public int? items { get; set; }
        public int? page { get; set; }
        public string sortBy { get; set; }
        public string order { get; set; }

        public TablePageInfo()
        {
            search = string.Empty;
            items = 10;
            page = 1;
            sortBy = string.Empty;
            order = string.Empty;
        }
    }
}