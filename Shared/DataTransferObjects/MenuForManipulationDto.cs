using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record MenuForManipulationDto
    {
        [Required(ErrorMessage = "MenuItem name is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Name is 100 characters.")]
        public string Name { get; init; }

        [MaxLength(100, ErrorMessage = "Maximum length for Description is 100 characters.")]
        public string Description { get; init; }


        [Required(ErrorMessage = "Price is a required field.")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 1")]
        public decimal Price { get; init; }
    }
}
