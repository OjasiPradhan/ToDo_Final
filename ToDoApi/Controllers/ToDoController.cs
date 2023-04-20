using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Model;
using ToDo.DB;
using ToDo.Common;
using System.Net;



namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoServiceController : ControllerBase
{
    private IToDoRepository DbPointer;
  

    public ToDoServiceController( IToDoRepository DBreference)
    {
      
        DbPointer = DBreference;
    }

    [HttpPost]
    public void Post([FromBody] ToDoItem toDoItem)
    {
        
        {
            throw new Exception(" Add Operation was Unsuccesful");
        }
        DbPointer.Add(toDoItem);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var Tasks = DbPointer.Get();

        return Ok(Tasks);
    }

    

    [HttpPut("{id}")]
    public void Put(string id, [FromBody] string UpdatedToDo)
    {
        var guid = Guid.Parse(id);
        if (!ModelState.IsValid)
        {
            throw new Exception("Unsuccesful Update Operation");

        }
        DbPointer.Update(guid, UpdatedToDo);
    }

    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        Guid guid = Guid.Parse(id);
        DbPointer.MarkAsComplete(guid);
    }

}
}