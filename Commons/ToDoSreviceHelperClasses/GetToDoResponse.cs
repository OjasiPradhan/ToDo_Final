using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Common.ToDoSreviceHelperClasses
{
    public class GetToDoResponse : Response
    {
        public List<ToDoItem> ToDoData { get; set; }
    }
}
