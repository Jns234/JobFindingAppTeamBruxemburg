using AutoMapper;
using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFindingAppTeamBruxemburg.Repositories;

namespace JobFindingAppTeamBruxemburg.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _objectMapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper objectMapper)
        {
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public async Task UpdateAndSave(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            await _unitOfWork.Save();
        }

        public async Task RemoveAndSave(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.Get(id);
            _unitOfWork.EmployeeRepository.Delete(employee);

        }
        public async Task DeleteEmployee(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.Get(id);
            if (employee == null)
            {
                return;
            }

            try
            {
                await _unitOfWork.BeginTransaction();
                _unitOfWork.EmployeeRepository.Delete(employee);
                await _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();

                throw;
            }
        }

        public async Task<EmployeeModel> GetEmployeeDetails(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.Get(id);
            var model = _objectMapper.Map<EmployeeModel>(employee);

            return model;
        }

        public async Task<EmployeeModel> GetEmployeeForEdit(int id)
        {
            var employee = await _unitOfWork.EmployeeRepository.Get(id);
            var model = _objectMapper.Map<EmployeeModel>(employee);

            return model;
        }

        public async Task<PagedResult<EmployeeModel>> List(int page, int pageSize)
        {
            var projects = await _unitOfWork.EmployeeRepository.List(page, pageSize);
            var models = _objectMapper.Map<PagedResult<EmployeeModel>>(projects);

            return models;
        }

        public async Task SaveEmployee(EmployeeModel model)
        {
            var employee = new Employee();

            if (model.Id != 0)
            {
                employee = await _unitOfWork.EmployeeRepository.Get(model.Id);
            }

            _objectMapper.Map(model, employee);

            try
            {
                await _unitOfWork.BeginTransaction();

                if (employee.Id == 0)
                {
                    await _unitOfWork.EmployeeRepository.Insert(employee);
                }
                else
                {
                    _unitOfWork.EmployeeRepository.Update(employee);
                }
                await _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();

                throw;
            }
        }
    }
}
