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
    public class UserDetailService : IUserDetailService
    {
        private readonly IMapper _mapper;
        private readonly IUserDetailRepository _repository;

        public UserDetailService(IUserDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Create(UserDetailViewModel viewModel)
        {
            try
            {
                var model = new UserDetail();
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

        public async Task<IEnumerable<UserDetailViewModel>> GetAll()
        {
            var listView = new List<UserDetailViewModel>();
            var listModel = await _repository.GetAll();

            foreach (var item in listModel)
            {
                var viewModel = new UserDetailViewModel();
                _mapper.Map(item, viewModel);
                listView.Add(viewModel);
            }

            return listView;
        }

        public async Task<UserDetailViewModel> GetById(string Id)
        {
            try
            {
                var model = await _repository.GetById(Guid.Parse(Id));
                var viewModel = new UserDetailViewModel();
                _mapper.Map(model, viewModel);

                return viewModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        public async Task<bool> Update(UserDetailViewModel viewModel)
        {
            var model = new UserDetail();
            _mapper.Map(viewModel, model);

            return await _repository.Update(model);
        }
    
    }
}
