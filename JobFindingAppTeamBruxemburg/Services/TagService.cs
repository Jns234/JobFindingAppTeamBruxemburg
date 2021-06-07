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
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _objectMapper;

        public TagService(IUnitOfWork unitOfWork, IMapper objectMapper)
        {
            _unitOfWork = unitOfWork;
            _objectMapper = objectMapper;
        }

        public async Task UpdateAndSave(Tag tag)
        {
            _unitOfWork.TagRepository.Update(tag);
            await _unitOfWork.Save();
        }

        public async Task RemoveAndSave(int id)
        {
            var tag = await _unitOfWork.TagRepository.Get(id);
            _unitOfWork.TagRepository.Delete(tag);

        }
        public async Task DeleteTag(int id)
        {
            var tag = await _unitOfWork.TagRepository.Get(id);
            if (tag == null)
            {
                return;
            }

            try
            {
                await _unitOfWork.BeginTransaction();
                _unitOfWork.TagRepository.Delete(tag);
                await _unitOfWork.Save();
                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();

                throw;
            }
        }

        public async Task<TagModel> GetTagDetails(int id)
        {
            var tag = await _unitOfWork.TagRepository.Get(id);
            var model = _objectMapper.Map<TagModel>(tag);

            return model;
        }

        public async Task<TagModel> GetTagForEdit(int id)
        {
            var tag = await _unitOfWork.TagRepository.Get(id);
            var model = _objectMapper.Map<TagModel>(tag);

            return model;
        }

        public async Task<PagedResult<TagModel>> List(int page, int pageSize)
        {
            var projects = await _unitOfWork.TagRepository.List(page, pageSize);
            var models = _objectMapper.Map<PagedResult<TagModel>>(projects);

            return models;
        }

        public async Task SaveTag(TagModel model)
        {
            var tag = new Tag();

            if (model.Id != 0)
            {
                tag = await _unitOfWork.TagRepository.Get(model.Id);
            }

            _objectMapper.Map(model, tag);

            try
            {
                await _unitOfWork.BeginTransaction();

                if (tag.Id == 0)
                {
                    await _unitOfWork.TagRepository.Insert(tag);
                }
                else
                {
                    _unitOfWork.TagRepository.Update(tag);
                }
                _unitOfWork.Save();
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
