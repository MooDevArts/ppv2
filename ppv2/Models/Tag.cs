using System.ComponentModel.DataAnnotations;

namespace ppv2.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public required string TagName { get; set; }

        //A Tag can be associated with many Tasks
        public ICollection<Task>? Tasks { get; set; }
    }

    public class TagDto
    {
        public int TagId { get; set; }
        public required string TagName { get; set; }
    }
}
