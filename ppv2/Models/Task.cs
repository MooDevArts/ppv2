using Azure;
using System.ComponentModel.DataAnnotations;

namespace ppv2.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public required string TaskName { get; set; }
        public string TaskDescription { get; set; }

        //A Task can be asigned to many Staff
        public ICollection<Staff>? Staffs { get; set; }

        //A Task can be associated with many Tags
        public ICollection<Tag>? Tags { get; set; }
    }

    public class TaskDto
    {
        public int TaskId { get; set; }
        public required string TaskName { get; set; }
        public string TaskDescription { get; set; }
    }


}
