using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Invoice_Detail
    {
        [Key]
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal InvoiceAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public Customer Customer { get; set; }


    }
}
