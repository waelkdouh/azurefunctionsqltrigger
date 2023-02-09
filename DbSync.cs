using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AzureSQL.ToDo
{
    public static class ToDoTrigger
    {
        [FunctionName("ToDoTrigger")]
        public static void Run(
            [SqlTrigger("[dbo].[ToDo]", ConnectionStringSetting = "SqlConnectionString")]
            IReadOnlyList<SqlChange<ToDoItem>> changes,
            ILogger logger)
        {
            foreach (SqlChange<ToDoItem> change in changes)
            {
                ToDoItem toDoItem = change.Item;
                logger.LogInformation($"Change operation: {change.Operation}");
                logger.LogInformation($"Id: {toDoItem.Id}, Title: {toDoItem.title}, Url: {toDoItem.url}, Completed: {toDoItem.completed}");
                // model mapping goes here
                // call to the dynamics api goes here

            }
        }


        //[FunctionName("GetToDoItem")]
        //public static IActionResult Run(
        //   [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "gettodoitem")]
        //    HttpRequest req,
        //   [Sql("select [Id], [order], [title], [url], [completed] from dbo.ToDo where Id = @Id",
        //        CommandType = System.Data.CommandType.Text,
        //        Parameters = "@Id={Query.id}",
        //        ConnectionStringSetting = "SqlConnectionString")]
        //    IEnumerable<ToDoItem> toDoItem, ILogger logger)
        //{
        //    logger.LogInformation($"function called ");
        //    return new OkObjectResult(toDoItem.FirstOrDefault());
        //}
    }
}