using ToDo.Common.ToDoEnums;

namespace ToDo.Common
{
    public class ToDoItem
    {
        public string Task { get; set; }
        public ToDoItemStatus Status { get; set; }
        public Guid Id { get; set; }

        public ToDoItem() 
        {
           
        }
        

        public ToDoItem(Guid guid, string task, ToDoItemStatus status)
        {
            Id = guid;
            Task = task;
            Status = status;
        }


     
       
        
    }
}
