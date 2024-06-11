using System.ComponentModel.DataAnnotations;

namespace COMPLAINTREGISTERATION.Models
{
    public class Branch
    {
        [Key]
        public int branchid { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string BranchName { get; set; }
    }
}
