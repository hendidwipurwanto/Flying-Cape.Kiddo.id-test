using Capaci.DAL.interfaces;
using Capaci.DTO.Context;
using Capaci.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.DAL
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserDetailRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(UserDetail model)
        {
            try
            {
               await _dbContext.UserDetail.AddAsync(model);
               await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;

                throw ex;
            }
        }

        public Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDetail> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserDetail model)
        {
            throw new NotImplementedException();
        }
    }
}
