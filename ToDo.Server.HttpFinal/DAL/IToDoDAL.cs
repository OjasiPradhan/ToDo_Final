using ToDo.Common;
using System;
using System.Collections.Generic;


namespace ToDo.Server.HttpFinal.DAL
{
    public interface IToDoDAL
    {
     
        void Add(ToDoItem toDo);

        IEnumerable<ToDoItem> Get();

        void Update(Guid id, string toDoItem);

        void MarkAsComplete(Guid id);
    }

}

