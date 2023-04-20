using ToDo.Common;
using ToDo.Common.ToDoSreviceHelperClasses;
using ToDo.Common.ToDoEnums; 
using ToDo.DB;
using DBConnection;
using System.Data.SqlClient;




namespace ToDo.Server
{
    public class ToDoService : IToDoService

    {
        IToDoRepository _dbService;
        public ToDoService(DataBase dbService)
        {
            _dbService = dbService;
        }
        public void AddToDo(ToDoItem toDoItem)
        {
            _dbService.Add(toDoItem);

        }
        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _dbService.Get();
        }

        public void MarkAsComplete(Guid id)
        {
            _dbService.MarkAsComplete(id);
        }

        public void UpdateToDoText(Guid id, string updatedText)
        {
            _dbService.Update(id, updatedText);
        }
    }
}