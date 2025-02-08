using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppv2.Data;
using ppv2.Models;
using System;

namespace ppv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TasksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(template: "List")]
        public IActionResult ListTask()
        {
            var allTasks = dbContext.Tasks.ToList();

            return Ok(allTasks);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTaskById(int id)
        {
            var task = dbContext.Tasks.Find(id);

            if (task == null) { return NotFound(); }

            return Ok(task);
        }

        [HttpPost]
        public IActionResult AddTask(TaskDto taskDto)
        {
            var TaskEntity = new ppv2.Models.Task()
            {
                TaskName = taskDto.TaskName,
                TaskDescription = taskDto.TaskDescription,
            };


            dbContext.Tasks.Add(TaskEntity);
            dbContext.SaveChanges();

            return Ok(TaskEntity);
        }

        [HttpPut]
        [Route("{id:int}")]

        public IActionResult UpdateTask(int id, TaskDto taskDto)
        {
            var task = dbContext.Tasks.Find(id);
            if (task == null) { return NotFound(); };
            task.TaskName = taskDto.TaskName;
            task.TaskDescription = taskDto.TaskDescription;


            dbContext.SaveChanges();

            return Ok(task);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTask(int id)
        {
            var task = dbContext.Tasks.Find(id);
            if (task == null) { return NotFound(); };

            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
            return Ok(task);
        }
    }
}
