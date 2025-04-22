using Microsoft.EntityFrameworkCore;
 
using BlogSitesi.DAL.Entities.Common;
using BlogSitesi.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MVCBlogSitesiProjesi.Data;

namespace BlogSitesi.DAL.Repositories.Concrete
{
    public class Repository<T>(MVCBlogSitesiPLContext BlogSitesiDbContext) : IRepository<T> where T : BaseEntity
    {
        private readonly MVCBlogSitesiPLContext _BlogSitesiDbContext = BlogSitesiDbContext;

        public DbSet<T> Table => _BlogSitesiDbContext.Set<T>();

        public int Add(T entity)
        {
            Table.Add(entity);
            _BlogSitesiDbContext.SaveChanges();
            return entity.Id;
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsNoTracking().Where(x => x.SilindiMi == false);
        }

        public T GetById(int id)
        {
            return Table.AsNoTracking().FirstOrDefault(x => x.Id == id && x.SilindiMi == false);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            T result;

            result = Table.AsNoTracking().Where(predicate).FirstOrDefault();
            return result != null && result.SilindiMi == false ? result : null;

        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            var result = Table.AsNoTracking().Where(x => x.SilindiMi == false);
            return result.Where(predicate);
        }

        public void Remove(int id)
        {
            T entity = Table.AsNoTracking().FirstOrDefault(x => x.Id == id && x.SilindiMi == false);
            if (entity == null)
            {
                return;
            }
            TemizleTracking(entity);
            Table.Remove(entity);
            _BlogSitesiDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            var kayit = GetById(entity.Id);
            entity.KayitTarihi = kayit.KayitTarihi;
            entity.GuncellemeTarihi = kayit.GuncellemeTarihi;
            TemizleTracking(entity);
            Table.Remove(entity);
            _BlogSitesiDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.KayitTarihi = GetById(entity.Id).KayitTarihi;


            TemizleTracking(entity);
            Table.Update(entity);
            _BlogSitesiDbContext.SaveChanges();
        }

        void TemizleTracking(T entity)
        { 
            foreach (var item in _BlogSitesiDbContext.ChangeTracker.Entries())
            {
                if (item.Entity.GetType().Name == entity.GetType().Name &&
                    ((T)(item.Entity)).Id == entity.Id)
                {
                    (item).State = EntityState.Detached;
                    break;
                }

            } 
        }
    }
}
