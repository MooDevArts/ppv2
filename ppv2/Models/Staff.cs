using System.ComponentModel.DataAnnotations;

namespace ppv2.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public required string StaffName { get; set; }

        //A Staff can have many Tasks
        public ICollection<Task>? Tasks { get; set; }
    }
}
