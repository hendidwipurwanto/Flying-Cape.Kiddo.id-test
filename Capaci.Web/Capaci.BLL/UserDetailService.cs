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
        private readonly IUserDetailRepository _userDetailRepository;

        public UserDetailService(IUserDetailRepository userDetailRepository, IMapper mapper)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(RegisterViewModel viewModel)
        {
            try
            {
                var model = new UserDetail();
                _mapper.Map(viewModel, model);
                model.Id = viewModel.Id;
                return await _userDetailRepository.Create(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }

        public Task<bool> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDetailViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDetailViewModel>> GetBeritaWithPaging(int page)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailViewModel> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(RegisterViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
