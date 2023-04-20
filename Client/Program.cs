using ToDo.Common;
using ToDo.Common.ToDoEnums;
using ToDo.Common.ToDoSreviceHelperClasses;


namespace ToDo.Client {
    public class Program
    {
        private static List<Guid> toDoId = new List<Guid>();
        static void Main(string[] args)
        {

            IToDoService Service = new ToDoServiceProxy();
            var flag = true;

            while (flag)
            {
                DisplayToDoServices.ToDoServices();

                System.Console.WriteLine("Select an option listed above : ");
                if (!int.TryParse(System.Console.ReadLine(), out int inputValue))
                {
                    continue;
                }
                System.Console.WriteLine((ToDoServiceChoice)inputValue);


                switch ((ToDoServiceChoice)inputValue)
                {
                    case ToDoServiceChoice.Add:
                        System.Console.Write("Please enter the todo item: ");
                        var todoItem = System.Console.ReadLine();
                        SafeActionCall(() => Service.AddToDo(new ToDoItem() { Id = Guid.NewGuid(), Task = todoItem }));

                        break;

                    case ToDoServiceChoice.View:
                        var toDoResponse = SafeFunctionCall(() => Service.GetToDoItems());
                        DisplayToDosOnConsole((List<ToDoItem>)toDoResponse);
                        break;


                    case ToDoServiceChoice.Update:
                        {
                            System.Console.WriteLine("Please enter the Id of the todo to be Updated: ");
                            var idToUpdate = System.Console.ReadLine();
                            System.Console.WriteLine("Enter the updated text: ");
                            var updatedText = System.Console.ReadLine();

                            if (Guid.TryParse(idToUpdate, out Guid guid))
                            {
                                Service.UpdateToDoText(guid, updatedText);
                            }

                            break;
                        }

                    case ToDoServiceChoice.MarkAsComplete:
                        {
                            System.Console.WriteLine("Please enter the Id of the todo to be mark as complete: ");
                            var id = System.Console.ReadLine();
                            if (Guid.TryParse(id, out Guid guid))
                            {
                                Service.MarkAsComplete(guid);
                            }
                            break;
                        }


                    case ToDoServiceChoice.Exit:
                        flag = false;
                        break;
                }
            }


            static void DisplayToDosOnConsole(List<ToDoItem> toDos)
            {
                foreach (var toDo in toDos)
                {
                    toDoId.Add(toDo.Id);
                    System.Console.WriteLine($"{toDoId.IndexOf(toDo.Id) + 1} {toDo.Task} {toDo.Status}");
                }
            }
            void SafeActionCall(Action func)
            {
                try
                {
                    func();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
            }

            T SafeFunctionCall<T>(Func<T> func)
            {
                try
                {
                    return func();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                    return default(T);
                }
            }
        }
    } }