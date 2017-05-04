﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace UCRS.Web.Models
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}