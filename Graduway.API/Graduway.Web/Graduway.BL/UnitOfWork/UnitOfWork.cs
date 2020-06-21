using Graduway.BL.UnitOfWork.Interfaces;
using Graduway.DAL;
using Graduway.DAL.Entities;
using Graduway.DAL.Interfaces;
using Graduway.DAL.Repository;
using System;

namespace Graduway.BL.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly GraduwayDbContext _context;
        private IGenericRepository<Employee> _employeesRepository;
        private IGenericRepository<Task> _tasksRepository;
        private IGenericRepository<PriorityLevel> _priorityLevelsRepository;
        private IGenericRepository<State> _statesRepository;


        public UnitOfWork(GraduwayDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Employee> EmployeesRepository
        {
            get
            {

                if (_employeesRepository == null)
                {
                    _employeesRepository = new GenericRepository<Employee>(_context);
                }
                return _employeesRepository;
            }
        }

        public IGenericRepository<Task> TasksRepository
        {
            get
            {

                if (_tasksRepository == null)
                {
                    _tasksRepository = new GenericRepository<Task>(_context);
                }
                return _tasksRepository;
            }
        }

        public IGenericRepository<PriorityLevel> PriorityLevelsRepository
        {
            get
            {

                if (_priorityLevelsRepository == null)
                {
                    _priorityLevelsRepository = new GenericRepository<PriorityLevel>(_context);
                }
                return _priorityLevelsRepository;
            }
        }

        public IGenericRepository<State> StatesRepository
        {
            get
            {

                if (_statesRepository == null)
                {
                    _statesRepository = new GenericRepository<State>(_context);
                }
                return _statesRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
