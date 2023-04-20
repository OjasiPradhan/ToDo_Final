using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ToDo.DB;
using ToDo.Common;

namespace ToDo.Server.HttpFinal.Controllers
{
    public class ToDoFinalController
    {

        [ApiController]
        [Route("[controller]")]
        public class ToDoServiceController : ControllerBase
        {
            private IToDoRepository _database;
            public ToDoServiceController(IToDoRepository database)
            {
                _database = database;
            }


            [HttpGet(Name = "GetAllToDoItem")]

            public IActionResult Get()
            {
                try
                {
                    var toDoItemList = _database.Get();
                    return Ok(toDoItemList);
                }
                catch (Exception except)
                {
                   
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

        }
    }
}