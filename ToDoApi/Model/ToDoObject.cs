using System.ComponentModel.DataAnnotations;


namespace ToDoApi.Model
{
    public class ToDoObject
    {
        public int ID { get; set; }
        [Required]
        public string Task { get; set; }

        public status Status { get; set; }

    }

    public enum status
    {
        Pending,
        Completed

    }
}
