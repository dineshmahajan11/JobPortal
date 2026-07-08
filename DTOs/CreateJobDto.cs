using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTOs
{
    public class CreateJobDto
    {
        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        public string Location { get; set; } = string.Empty;

        [Range(1, 100000000, ErrorMessage = "Salary must be greater than 0.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(100, ErrorMessage = "Company name cannot exceed 100 characters.")]
        public string CompanyName { get; set; } = string.Empty;
    }
}