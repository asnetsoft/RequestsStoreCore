using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RequestsStore
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestsStoreId { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }

        [Display(Name ="Статус")]
        public int StatusId { get; set; }
        public Statuses Statuses { get; set; }

        public int RequestId { get; set; }
        public Requests Requests { get; set; }
    }
}
