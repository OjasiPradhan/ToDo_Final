using ToDo.Common.ToDoSreviceHelperClasses;

namespace ToDo.Common;

public interface IToDoService
{
    void AddToDo(ToDoItem toDoItem);
    IEnumerable<ToDoItem> GetToDoItems();
    void MarkAsComplete(Guid id);
    void UpdateToDoText(Guid id, string updatedText);

   
}
