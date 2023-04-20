using Communication.Client;
using Communication.Server;
using ToDo.Common.ToDoSreviceHelperClasses;
using System.Net;
using ToDo.Server;
using DBConnection;

namespace ToDoManager
{
    public class Program
    {
      //  private static IToDoRepository _dbService;
        public static void Main(string[] args)
        {
            IPEndPoint ClientEndPoint = new(IPAddress.Parse("127.0.0.1"), 1234);
            IPEndPoint ServerEndPoint = new(IPAddress.Parse("127.0.0.1"), 1235);
            var messageReciver = new MessageReciver(ClientEndPoint);
            while (true)
            {
                var message = messageReciver.RecivedMessage();
                MessageRecived(message);
            }
            object MessageRecived(object message) {
                DataBase dbObject = new DataBase();
                ToDoService toDoService = new ToDoService(dbObject);
                
                object response = null;
                if (message != null)
                {
                    if (message is AddToDoRequest add)
                    {
                        toDoService.AddToDo(add.ToDo);
                        MessageSender<Response> addMessageSender = new MessageSender<Response>(ServerEndPoint);
                        addMessageSender.SendMessage(CreateDefaultResponse());
                    }
                    else if (message is GetToDosRequest)
                    {
                        var res = toDoService.GetToDoItems();
                        MessageSender<GetToDoResponse> addMessageSender = new MessageSender<GetToDoResponse>(ServerEndPoint);
                        addMessageSender.SendMessage(new GetToDoResponse { IsSuccess = true, ToDoData = res.ToList() });
                    }
                    else if (message is UpdateToDoRequest update)
                    {
                        toDoService.UpdateToDoText(update.ToDo.Id, update.ToDo.Task);
                        return CreateDefaultResponse();
                    }
                    else if (message is MarkCompleteToDoRequest markAsComplete)
                    {
                        toDoService.MarkAsComplete(markAsComplete.Id);
                        return CreateDefaultResponse();
                    }

                }
                return response;

            }




            Response CreateDefaultResponse()
            {
                return new Response()
                {
                    IsSuccess = true
                };
            }



        }
    }
}


