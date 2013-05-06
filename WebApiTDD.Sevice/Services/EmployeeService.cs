using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApiTDD.Context.AppContext;
using WebApiTDD.DataContract;
using WebApiTDD.Domain.Models;
using WebApiTDD.Repository.Repository;
using WebApiTDD.Sevice.Interfaces;
using WebApiTDD.Repository.UnitOfWork;

namespace WebApiTDD.Sevice.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWrok;
        private IRepository<Manager> _managerRepo;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWrok = unitOfWork;
            _managerRepo = _unitOfWrok.GetRepository<Manager>();

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var managers = _managerRepo.All().ToList();
            var Employee = Mapper.Map<IList<Manager>, IList<Employee>>(managers);
            return Employee;
        }

        public Employee FindById(object id)
        {
            var entry = _managerRepo.GetById(id);
            return Mapper.Map<Manager, Employee>(entry);
        }
    }
}
