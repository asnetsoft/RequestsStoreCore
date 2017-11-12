using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class StatusesViewModel
    {
        public int StatusID { get; set; }
        [Display(Name = "Статус")]
        public string Name { get; set; }
    }
}