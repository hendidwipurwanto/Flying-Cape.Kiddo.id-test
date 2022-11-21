using Capaci.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capaci.DAL.interfaces
{
    public  interface IAdminProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid Id);

        Task<bool> Create(Product model);
        Task<bool> Update(Product model);
        Task<bool> Delete(Guid Id);
    }
}
