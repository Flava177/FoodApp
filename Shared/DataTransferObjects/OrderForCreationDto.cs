using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record OrderForCreationDto
    {

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime RequestedDeliveryTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 1")]
        public decimal TotalAmount { get; set; }

        [Range(0, 50, ErrorMessage = "Quantity must be between 0 and 50.")]
        public int? Quantity { get; set; }
    }

}
