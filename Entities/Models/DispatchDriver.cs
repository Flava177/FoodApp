using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Column("DispatchDriverId")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Full Name is a required field.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number.")]
    public string PhoneNumber { get; set; }
}
