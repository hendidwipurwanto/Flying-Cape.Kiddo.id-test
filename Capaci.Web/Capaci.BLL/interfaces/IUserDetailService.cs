using Capaci.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.BLL.interfaces
{
    public interface IUserDetailService
    {
        Task<IEnumerable<UserDetailViewModel>> GetAll();
        Task<UserDetailViewModel> GetById(string Id);
        Task<bool> Create(UserDetailViewModel viewModel);
        Task<bool> Update(UserDetailViewModel viewModel);
        Task<bool> Delete(string Id);
    }
}
