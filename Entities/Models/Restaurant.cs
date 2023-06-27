using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Restaurant
    {
        [Column("RestaurantId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Restaurant name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public string StartTime { get; set; }
        

        [Required(ErrorMessage = "End time is required.")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public string EndTime { get; set; }


        [ForeignKey(nameof(Address))]
        public Guid AddressId { get; set; }
        public Address? Address { get; set; }

    }
}
