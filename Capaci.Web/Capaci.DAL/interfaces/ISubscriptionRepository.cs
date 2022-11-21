using Capaci.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.DAL.interfaces
{
    public  interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAll();
        Task<Subscription> GetById(Guid Id);
        Task<IEnumerable<Subscription>> GetByUserId(Guid UserId);
        Task<bool> Create(Subscription model);
    }
}
