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
        Task<IEnumerable<UserDetailViewModel>> GetBeritaWithPaging(int page);
        Task<UserDetailViewModel> GetById(string Id);
        Task<bool> Create(RegisterViewModel viewModel);
        Task<bool> Update(RegisterViewModel viewModel);
        Task<bool> Delete(string Id);
    }
}
