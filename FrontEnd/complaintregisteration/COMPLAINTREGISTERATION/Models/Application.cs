using System.ComponentModel.DataAnnotations;

namespace COMPLAINTREGISTERATION.Models
{
    public class Application
    {
        [Key]
        public int applicationid { get; set; }
        public string ApplicationName { get; set; }
    }
}
