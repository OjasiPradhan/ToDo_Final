using Communication.Server;
using Moq;
using ToDo.Client;
using ToDo.Common;
using ToDo.Common.ToDoSreviceHelperClasses;
using ToDo.Server;

namespace ToDo.test
{
    public class ProgramTests
    {
        private ToDoServiceProxy client { get; set; } = null!;
        public ToDoService server { get; set; } = null!;

        [SetUp]
        public void TestSetup()
        {
            client = new ToDoServiceProxy();
            server = new ToDoService();
        }

        [Test]
        public void AddToDoTest()
        {
            var clientObj = new ToDoItem();
            clientObj.ToDo = "gym";
            Response res = client.TryAddToDo(clientObj);
            Assert.AreEqual("To Do added successfully.", res.ErrorMessage);
        }
        [Test]
        public void GetToDoItems()
        {
            List<ToDoItem> items = new List<ToDoItem>();
            List<ToDoItem> res = client.GetToDoItems();
            Assert.AreEqual(items, res);
        }
        [Test]
        public void MarkAsComplete()
        {
            var clientObj = new ToDoItem();
            clientObj.Id = new System.Guid();
            Response res = client.MarkAsComplete(clientObj.Id);
            Assert.AreEqual("To Do marked successfully.", res.ErrorMessage);
        }
        [Test]
        public void TryUpdateToDoText()
        {
            var clientObj = new ToDoItem();
            string newTask = "Study";
            Response res = client.TryUpdateToDoText(new System.Guid(), newTask);
            Assert.AreEqual("To Do updated successfully.", res.ErrorMessage);
        }


    }
}