using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyAppCore.MyAppCoreComponents.Interfaces
{
    public interface ICrudBusiness<Tobj> where Tobj : class
    {
        Tobj Get(int id);
        Task<Tobj> GetAsync(int id);
        IQueryable<Tobj> GetAll();
        Task<ICollection<Tobj>> GetAllAsync();
        Tobj Find(Expression<Func<Tobj, bool>> match);
        Task<Tobj> FindAsync(Expression<Func<Tobj, bool>> match);
        ICollection<Tobj> FindAll(Expression<Func<Tobj, bool>> match);
        Task<ICollection<Tobj>> FindAllAsync(Expression<Func<Tobj, bool>> match);
        int Add(Tobj entity);
        Task<int> AddAsync(Tobj entity);
        int AddAll(IEnumerable<Tobj> entityList);
        Task<int> AddAllAsync(IEnumerable<Tobj> entityList);
        int Update(Tobj entity);
        Task<int> UpdateAsync(Tobj entity);
        int Delete(Tobj entity);
        Task<int> DeleteAsync(Tobj entity);
        int Count();
        Task<int> CountAsync();
        DbContext getDbContext();


    }
}
