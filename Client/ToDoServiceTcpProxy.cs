using Communication.Client;
using Communication.Server;
using Newtonsoft.Json;
using System;
using System.Net;
using ToDo.Common;
using ToDo.Common.ToDoSreviceHelperClasses;
namespace ToDo.Client;
public class ToDoServiceProxy : IToDoService
{
    IPEndPoint ClientEndPoint = new(IPAddress.Parse("127.0.0.1"), 1234);
    IPEndPoint ServerEndPoint = new(IPAddress.Parse("127.0.0.1"), 1235);
    private List<ToDoItem> list = new List<ToDoItem>();
    public void AddToDo(ToDoItem toDoItem)
    {
        var request = new AddToDoRequest() { ToDo = toDoItem};
        var addToDoMessageSender = new MessageSender<AddToDoRequest>(ClientEndPoint);
        addToDoMessageSender.SendMessage(request);
        var addToDoMessageReciver = new MessageReciver(ServerEndPoint);
        Response final_response= (Response)addToDoMessageReciver.RecivedMessage();

        if (final_response == null || final_response.IsSuccess == false)
        {
            
            throw new Exception(final_response?.ErrorMessage ?? string.Empty);
        }

    }


    public IEnumerable<ToDoItem> GetToDoItems()
    {
        var request = new GetToDosRequest();
        var GetToDoMessageSender = new MessageSender<GetToDosRequest>(ClientEndPoint);
        GetToDoMessageSender.SendMessage(request);

        var GetToDoMessageReciver = new MessageReciver(ServerEndPoint);
        GetToDoResponse responce = (GetToDoResponse)GetToDoMessageReciver.RecivedMessage();
        //List<ToDoItem> response = JsonConvert.DeserializeObject<List<ToDoItem>>(responce.ToString());
        return responce.ToDoData;
        
    }

    public void MarkAsComplete(Guid id)
    {
        var request = new MarkCompleteToDoRequest() { Id = id};
        var markASCompleteToDoMessageSender = new MessageSender<MarkCompleteToDoRequest>(ClientEndPoint);
        markASCompleteToDoMessageSender.SendMessage(request);
        
       
      
       
    }

    public void UpdateToDoText(Guid id, string updatedText)
    {
        var toDo = new ToDoItem() { Id = id, Task = updatedText };
        var request = new UpdateToDoRequest() { ToDo = toDo };
        var updateToDoMessageSender = new MessageSender<UpdateToDoRequest>(ClientEndPoint);
        updateToDoMessageSender.SendMessage(request);

    }
}

