using FluentValidation.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentValidation.DTOs
{
    public class BreakfastDto
    {
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Future]
        public DateTime StartDate { get; set; }
        [Future]
        public DateTime EndDate { get; set; }

        
        public List<string> Savory { get; set; }
        
        public List<string> Sweet { get; set; }
    }
}
