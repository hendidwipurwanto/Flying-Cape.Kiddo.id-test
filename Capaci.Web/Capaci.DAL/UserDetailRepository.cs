using AutoMapper;
using Capaci.DAL.interfaces;
using Capaci.DTO.Context;
using Capaci.DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.DAL
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public UserDetailRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Create(UserDetail model)
        {
            try
            {
                await _dbContext.UserDetail.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            try
            {
                var entity = await _dbContext.UserDetail.FindAsync(Id);
                _dbContext.UserDetail.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public async Task<IEnumerable<UserDetail>> GetAll()
        {
            return await _dbContext.UserDetail.ToListAsync();
        }

        public async Task<UserDetail> GetById(Guid Id)
        {
            var entity = await _dbContext.UserDetail.FindAsync(Id);
            return entity;
        }

        public async Task<bool> Update(UserDetail model)
        {
            try
            {
                var oldEntity = await _dbContext.UserDetail.FindAsync(model.Id);

                _mapper.Map(model, oldEntity);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
            }
            return true;
        }
    }
 }

