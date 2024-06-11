using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMPLAINTREGISTERATION.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customerid")]
        public int CustomerId { get; set; }

        [ForeignKey("applicationid")]
        public int ApplicationId { get; set; }

        [ForeignKey("serviceid")]
        public int ServiceId { get; set; }

        [ForeignKey("branchid")]
        public int BranchId { get; set; }
       
        public DateTime Timestamp { get; set; }

        [Required]
        public string Status { get; set; }
        [Required]
        public string Description {  get; set; }



        public Customer Customer { get; set; }
        public Branch Branch { get; set; }
        public Application Application { get; set; }
        public Service Service { get; set; }
    }
}
