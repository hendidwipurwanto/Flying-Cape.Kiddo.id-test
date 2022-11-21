using AutoMapper;
using Capaci.BLL.interfaces;
using Capaci.DAL.interfaces;
using Capaci.DTO.Models;
using Capaci.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.BLL
{
    public class AdminProductService : IAdminProductService
    {
        private readonly IMapper _mapper;
        private readonly IAdminProductRepository _repository;

        public AdminProductService(IAdminProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Create(ProductViewModel viewModel)
        {
            try
            {
                var model = new Product();
                _mapper.Map(viewModel, model);

                return await _repository.Create(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(string Id)
        {
            try
            {
                return await _repository.Delete(Guid.Parse(Id));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var listView = new List<ProductViewModel>();
            var listModel = await _repository.GetAll();

            foreach (var item in listModel)
            {
                var viewModel = new ProductViewModel();
                _mapper.Map(item, viewModel);
                listView.Add(viewModel);
            }

            return listView;
        }

        public async Task<ProductViewModel> GetById(string Id)
        {
            try
            {
                var model = await _repository.GetById(Guid.Parse(Id));
                var viewModel = new ProductViewModel();
                _mapper.Map(model, viewModel);

                return viewModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public async Task<bool> Update(ProductViewModel viewModel)
        {
            var model = new Product();
            _mapper.Map(viewModel, model);

            return await _repository.Update(model);
        }
    }
}
