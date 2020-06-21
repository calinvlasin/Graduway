using Graduway.BL.Models;
using Graduway.DAL.Entities;

namespace Graduway.BL.Builders
{
    public interface ITaskBuilder
    {
        Task BuildTask(TaskModel taskModel);
    }
    public class TaskBuilder: ITaskBuilder
    {
        public Task BuildTask(TaskModel taskModel)
        {
            Task task = new Task
            {
                Description = taskModel.Description,
                Estimate = taskModel.Estimate,
                PriorityLevelId = taskModel.PriorityLevelId,
                StateId = taskModel.StateId,
                EmployeeId = taskModel.EmployeeId,
                Title = taskModel.Title
            };
            return task;
        }
    }
}
