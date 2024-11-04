using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Models
{
    public class CategriesSubCategries
    {
        public string CategriesName { get; set; }
        public string Value { get; set; }
        public List<SelectListItem> SubCategories { get; set; }
    }
}