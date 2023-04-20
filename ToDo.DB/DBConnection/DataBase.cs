
using System.Data.SqlClient;
using ToDo.DB;
using ToDo.Common;
using System.Text.Json;
using ToDo.Common.ToDoEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace DBConnection
{
    public class DataBase : IToDoRepository
    {
        private string _connectionString;
         public DataBase()
        {
            _connectionString = "Data Source=LAPTOP-GUTRUQAB\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";
        }
       
        public void Add(ToDoItem toDo)
        {
            string query = $"INSERT INTO TODOLIST (ID, Name, Status) VALUES (@Id,@ToDoItem,@Status)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@Id", toDo.Id);
                    command.Parameters.AddWithValue("@ToDoItem", toDo.Task);
                    command.Parameters.AddWithValue("@Status", toDo.Status);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public IEnumerable<ToDoItem> Get()
        {
            var list = new List<ToDoItem>();

            string displayQuery = "select * from TODOLIST";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand(displayQuery, connection))
                {
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        string guid = dataReader.GetValue(0).ToString();
                        string toDoItem = dataReader.GetValue(1).ToString();
                        string status = dataReader.GetValue(2).ToString();
                        if (Guid.TryParse(guid, out Guid id))
                        {
                            
                            list.Add(new ToDoItem() { Id = id, Task = toDoItem, Status = JsonConvert.DeserializeObject<ToDoItemStatus>(status)});
                        }

                    }
                }
            }
            return list;
        }

        public void Update(Guid id, string toDoItem)
        {
            string query;
            query = $"UPDATE TODOLIST SET Name=@ToDoItem WHERE ID=@Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    if (id != Guid.Empty) // (id == Guid.Empty) --> old code
                    {
                        command.Parameters.AddWithValue("@ToDoItem", toDoItem);
                        command.Parameters.AddWithValue("@Id", id);
                    }
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No record found to update");
                    }


                }
            }
        }

        public void MarkAsComplete(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                string query = $"DELETE FROM TODOLIST WHERE ID=@Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Id", id);
                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No record found to mark as complete.");
                    }

                }
            }
        }
    }
}





































