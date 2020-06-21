using System.Collections.Generic;
using System.Linq;
using Graduway.BL.Builders;
using Graduway.BL.Models;
using Graduway.BL.Services.Interfaces;
using Graduway.BL.UnitOfWork.Interfaces;
using Graduway.DAL.Entities;

namespace Graduway.BL.Services
{
    public class TasksService : ITasksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskBuilder _taskBuilder;

        public TasksService(IUnitOfWork unitOfWork, ITaskBuilder taskBuilder)
        {
            this._unitOfWork = unitOfWork;
            _taskBuilder = taskBuilder;
        }

        public IEnumerable<Task> GetTasksByEmployeeId(int employeeId)
        {
            return _unitOfWork.TasksRepository.Get()
                .Where(task => task.EmployeeId == employeeId)
                .OrderBy(x => x.PriorityLevelId).ToList();
        }

        public void AddTask(TaskModel taskModel)
        {
            _unitOfWork.TasksRepository.Insert(_taskBuilder.BuildTask(taskModel));
            _unitOfWork.Save();
        }

        public IEnumerable<PriorityLevel> GetPriorityLevels()
        {
            return _unitOfWork.PriorityLevelsRepository.Get();
        }

        public IEnumerable<State> GetStates()
        {
            return _unitOfWork.StatesRepository.Get();
        }

        public void DeleteTask(int taskId)
        {
            _unitOfWork.TasksRepository.Delete(taskId);
            _unitOfWork.Save();
        }

        public Task GetTaskById(int taskId)
        {
            return _unitOfWork.TasksRepository.GetByID(taskId);
        }

        public void UpdateTask(Task updatedTask)
        {
            Task task = _unitOfWork.TasksRepository.GetByID(updatedTask.Id);
            task.Description = updatedTask.Description;
            task.Estimate = updatedTask.Estimate;
            task.PriorityLevelId = updatedTask.PriorityLevelId;
            task.StateId = updatedTask.StateId;
            task.Title = updatedTask.Title;

            _unitOfWork.TasksRepository.Update(task);
            _unitOfWork.Save();
        }
    }
}
