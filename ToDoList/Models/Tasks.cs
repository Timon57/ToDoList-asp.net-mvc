using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TaskName{ get; set; }

        public string Description { get; set; }

        public Boolean Completed { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Today;
    }
}
