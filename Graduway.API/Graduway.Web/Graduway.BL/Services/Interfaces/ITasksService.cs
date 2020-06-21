using System.Collections.Generic;
using Graduway.BL.Models;
using Graduway.DAL.Entities;

namespace Graduway.BL.Services.Interfaces
{
    public interface ITasksService
    {
        IEnumerable<Task> GetTasksByEmployeeId(int employeeId);
        void AddTask(TaskModel task);
        IEnumerable<PriorityLevel> GetPriorityLevels();
        IEnumerable<State> GetStates();
        void DeleteTask(int taskId);
        Task GetTaskById(int taskId);
        void UpdateTask(Task updatedTask);
    }
}
