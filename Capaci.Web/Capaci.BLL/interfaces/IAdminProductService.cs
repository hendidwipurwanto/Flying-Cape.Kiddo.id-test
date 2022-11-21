using Capaci.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.BLL.interfaces
{
    public interface IAdminProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();
        Task<ProductViewModel> GetById(string Id);
        Task<bool> Create(ProductViewModel viewModel);
        Task<bool> Update(ProductViewModel viewModel);
        Task<bool> Delete(string Id);
    }
}
