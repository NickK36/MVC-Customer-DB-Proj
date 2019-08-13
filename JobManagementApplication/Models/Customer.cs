using System.ComponentModel.DataAnnotations;

namespace JobManagementApplication.Models
{
    public class Customer
    {
        public int? ID { get; set; }
        [Required]
        [Display(Name ="First Name"), StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name"), StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Phone Number"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name ="Address"), StringLength(30, MinimumLength = 10)]
        public string Address { get; set; }
        [Required]
        [Display(Name = "City Of Residence"), StringLength(25, MinimumLength = 5)]
        public string City { get; set; }
        public string ImageName { get; set; }
    }
}