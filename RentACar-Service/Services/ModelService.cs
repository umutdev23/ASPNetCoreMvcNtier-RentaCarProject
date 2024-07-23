using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentACar.DataAccess.Contexts;
using RentACar_Entity.Entities;
using RentACar_Entity.Services;
using RentACar_Entity.UnitOfWorks;
using RentACar_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar_Service.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ModelService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Task AddAsync(ModelViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ModelViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ModelViewModel>> GetAllAsync()
        {
            var list = await _uow.GetRepository<Model>().GetAllAsync();
            return _mapper.Map<List<ModelViewModel>>(list);
        }

        public async Task<ModelViewModel> GetByIdAsync(int id)
        {
            var model = await _uow.GetRepository<Model>().GetByIdAsync(id);
            return _mapper.Map<ModelViewModel>(model);
        }

        public Task UpdateAsync(ModelViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
