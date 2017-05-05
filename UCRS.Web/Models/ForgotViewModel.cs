﻿using System.ComponentModel.DataAnnotations;

namespace UCRS.Web.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}