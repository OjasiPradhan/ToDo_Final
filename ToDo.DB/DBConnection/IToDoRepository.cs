using ToDo.Common;
namespace ToDo.DB
{
    public interface IToDoRepository
    {
        void Add(ToDoItem toDo);

        IEnumerable<ToDoItem> Get();
        void Update(Guid id, string toDoItem);

        void MarkAsComplete(Guid id);
    }
}
