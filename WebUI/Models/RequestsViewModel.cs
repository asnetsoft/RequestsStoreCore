using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebUI.Models
{
    public class RequestsViewModel
    {
        public int RequestId { get; set; }
        [Display(Name ="Тема")]
        [Required]
        public string Name { get; set; }
        [Display(Name ="Содержание")]
        [Required]
        public string Content { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Дата закрытия")]
        public DateTime? ClosedDate { get; set; }


    }
}