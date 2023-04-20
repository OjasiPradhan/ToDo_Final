namespace ToDo.Server.HttpFinal.DAL
{
    using System;
    using System.Collections.Generic;
    using ToDo.Common;
    using ToDo.DB;
    using  DBConnection;

    public class ToDoDAL : IToDoDAL
    {
        private DataBase _dataBase;

        public ToDoDAL()
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
