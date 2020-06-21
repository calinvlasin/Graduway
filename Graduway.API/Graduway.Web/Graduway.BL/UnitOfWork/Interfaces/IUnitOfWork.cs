using Graduway.DAL.Interfaces;
using Graduway.DAL.Entities;

namespace Graduway.BL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Employee> EmployeesRepository { get; }
        IGenericRepository<Task> TasksRepository { get; }
        IGenericRepository<PriorityLevel> PriorityLevelsRepository { get; }
        IGenericRepository<State> StatesRepository { get; }
        void Save();
    }
}
