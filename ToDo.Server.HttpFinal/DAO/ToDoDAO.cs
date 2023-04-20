

namespace ToDo.Server.HttpFinal.DAO
{
    using System;
    using System.Collections.Generic;
    using ToDo.Common;
    using ToDo.DB;
    using DBConnection;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    

    public class ToDoDao
    {
        private DataBase _dataBase;

        public ToDoDao()
        {
            
            _dataBase = new DataBase();
        }

        public void Add(ToDoItem toDo)
        {
            
            _dataBase.Add(toDo);
        }

        public IEnumerable<ToDoItem> Get()
        {
           
            return _dataBase.Get();
        }

        public void Update(Guid id, string toDoItem)
        {
            
            _dataBase.Update(id, toDoItem);
        }

        public void MarkAsComplete(Guid id)
        {
            
            _dataBase.MarkAsComplete(id);
        }
    }
}


