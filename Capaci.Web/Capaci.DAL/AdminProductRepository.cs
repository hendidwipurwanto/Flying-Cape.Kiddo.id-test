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
    public class AdminProductRepository : IAdminProductRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        public AdminProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Create(Product model)
        {
            try
            {
                await _dbContext.Product.AddAsync(model);
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
                var entity = await _dbContext.Product.FindAsync(Id);
                _dbContext.Product.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Product.ToListAsync();
        }

        public async Task<Product> GetById(Guid Id)
        {
            var entity = await _dbContext.Product.FindAsync(Id);
            return entity;
        }

        public async Task<bool> Update(Product model)
        {
            try
            {
                var oldEntity = await _dbContext.Product.FindAsync(model.Id);

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
