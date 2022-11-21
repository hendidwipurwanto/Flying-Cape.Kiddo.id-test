using AutoMapper;
using Capaci.DAL.interfaces;
using Capaci.DTO.Context;
using Capaci.DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.DAL
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public SubscriptionRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
         }

        public async Task<bool> Create(Subscription model)
        {
            try
            {
                await _dbContext.Subscription.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;

                throw;
            }
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            return await _dbContext.Subscription.ToListAsync();
        }

        public async Task<Subscription> GetById(Guid Id)
        {
            var entity = await _dbContext.Subscription.FindAsync(Id);
            return entity;
        }

        public async Task<IEnumerable<Subscription>> GetByUserId(Guid UserId)
        {
            var list = await _dbContext.Subscription.ToListAsync();
            var result = list.Where(w => w.UserId == UserId);

            return result;
        }
    }




}
