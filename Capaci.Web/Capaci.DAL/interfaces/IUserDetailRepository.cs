using Capaci.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.DAL.interfaces
{
    public interface IUserDetailRepository
    { 
        Task<IEnumerable<UserDetail>> GetAll();
        Task<UserDetail> GetById(Guid Id);

        Task<bool> Create(UserDetail model);
        Task<bool> Update(UserDetail model);
        Task<bool> Delete(Guid Id);
    }
}
