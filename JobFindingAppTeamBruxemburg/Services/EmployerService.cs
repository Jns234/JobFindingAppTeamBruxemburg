using AutoMapper;
using JobFindingAppTeamBruxemburg.Data;
using JobFindingAppTeamBruxemburg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobFindingAppTeamBruxemburg.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _objectMapper;

        public EmployerService(IUnitOfWork unitOfWork, IMapper objectMapper)
        {
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public async Task UpdateAndSave(Employer employer)
        {
            _unitOfWork.EmployerRepository.Update(employer);
            await _unitOfWork.Save();
        }

        public async Task RemoveAndSave(int id)
        {
            var employer = await _unitOfWork.TagRepository.Get(id);
            _unitOfWork.TagRepository.Delete(employer);

        }
        public async Task DeleteEmployer(int id)
        {
            var employer = await _unitOfWork.EmployerRepository.Get(id);
            if (employer == null)
            {
                return;
            }

            try
            {
                await _unitOfWork.BeginTransaction();
                _unitOfWork.EmployerRepository.Delete(employer);
                await _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();

                throw;
            }
        }

        public async Task<EmployerModel> GetEmployerDetails(int id)
        {
            var employer = await _unitOfWork.EmployerRepository.Get(id);
            var model = _objectMapper.Map<EmployerModel>(employer);

            return model;
        }

        public async Task<EmployerModel> GetEmployerForEdit(int id)
        {
            var employer = await _unitOfWork.EmployerRepository.Get(id);
            var model = _objectMapper.Map<EmployerModel>(employer);

            return model;
        }

        public async Task<PagedResult<EmployerModel>> List(int page, int pageSize)
        {
            var employer = await _unitOfWork.EmployerRepository.List(page, pageSize);
            var models = _objectMapper.Map<PagedResult<EmployerModel>>(employer);

            return models;
        }

        public async Task SaveEmployer(EmployerModel model)
        {
            var employer = new Employer();

            if (model.Id != 0)
            {
                employer = await _unitOfWork.EmployerRepository.Get(model.Id);
            }

            _objectMapper.Map(model, employer);

            try
            {
                await _unitOfWork.BeginTransaction();

                if (employer.Id == 0)
                {
                    await _unitOfWork.EmployerRepository.Insert(employer);
                }
                else
                {
                    _unitOfWork.EmployerRepository.Update(employer);
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
