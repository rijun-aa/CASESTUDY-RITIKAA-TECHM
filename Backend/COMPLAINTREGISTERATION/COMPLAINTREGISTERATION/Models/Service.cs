using System.ComponentModel.DataAnnotations;

namespace COMPLAINTREGISTERATION.Models
{
    public class Service
    {
        [Key]
        public int serviceid { get; set; }
        public string ServiceName { get; set; }
    }
}
