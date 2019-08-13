using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagementApplication.Models
{
    public class Job
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Job Title"), StringLength(30, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Job Description"), StringLength(300, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Customer's Id")]
        public int CustomerID { get; set; }
        public bool IsFinished { get; set; }
        [Required]
        [Display(Name = "Has The Deposit Been Made?")]
        public bool DepositMade { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        [Required]
        [Display(Name = "Job's Worth"), DataType(DataType.Currency)]
        public decimal Worth { get; set; }
        public string convDepositMade { get; set; }
        public string convIsFinished { get; set; }
    }
}
