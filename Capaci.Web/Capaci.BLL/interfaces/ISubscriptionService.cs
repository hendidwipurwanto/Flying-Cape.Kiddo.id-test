using Capaci.DTO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.BLL.interfaces
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionViewModel>> GetAll();
        Task<SubscriptionViewModel> GetById(string Id);
        Task<IEnumerable<ProductViewModel>> GetByUserId(Guid UserId);

        Task<bool> Create(SubscriptionViewModel viewmodel);
    }
}
