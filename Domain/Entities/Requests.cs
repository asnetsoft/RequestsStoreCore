using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Requests
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ClosedDate { get; set; }

    }
}
