using System.Collections.Generic;
using Graduway.BL.Models;
using Graduway.BL.Services.Interfaces;
using Graduway.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Graduway.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpGet("tasks/get")]
        public IActionResult GetTasks([FromQuery] int employeeId)
        {
            IEnumerable<Task> tasks = _tasksService.GetTasksByEmployeeId(employeeId);
            return Ok(tasks);
        }

        [HttpPost("tasks/add")]
        public IActionResult AddTask([FromBody] TaskModel task)
        {
            _tasksService.AddTask(task);
            return Ok(true);
        }

        [HttpGet("tasks/priority-levels")]
        public IActionResult GetPriorityLevels()
        {
            IEnumerable<PriorityLevel> priorityLevels = _tasksService.GetPriorityLevels();
            return Ok(priorityLevels);
        }

        [HttpGet("tasks/states")]
        public IActionResult GetStates()
        {
            IEnumerable<State> states = _tasksService.GetStates();
            return Ok(states);
        }

        [HttpDelete("tasks/delete")]
        public IActionResult Delete([FromQuery]int taskId)
        {
            _tasksService.DeleteTask(taskId);
            return Ok(true);
        }

        [HttpGet("tasks/get-task")]
        public IActionResult GetTaskById([FromQuery]int taskId)
        {
            Task task = _tasksService.GetTaskById(taskId);
            return Ok(task);
        }

        [HttpPut("tasks/update")]
        public IActionResult UpdateTask([FromBody] Task updatedTask)
        {
            _tasksService.UpdateTask(updatedTask);
            return Ok(true);
        }
    }
}
