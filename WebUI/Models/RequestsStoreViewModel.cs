using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace WebUI.Models
{
    public class RequestsStoreViewModel
    {
        public int RequestsStoreId { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime Date { get; set; }

        [Display(Name = "Комментарий")]
        [Required]
        public string Comments { get; set; }

        [Display(Name = "Статус")]
        public int StatusId { get; set; }
        public StatusesViewModel Statuses { get; set; }

        public int RequestId { get; set; }
        public RequestsViewModel Requests { get; set; }
    }
}