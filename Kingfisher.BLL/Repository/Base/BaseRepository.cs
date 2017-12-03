using Kingfisher.DAL.ORM.Context;
using Kingfisher.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.BLL.Repository.Base
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private ProjectContext db;
        protected DbSet<T> datas;
        public BaseRepository()
        {
            db = new ProjectContext();
            datas = db.Set<T>();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public virtual int Insert(T entity)
        {
            if (entity != null)
            {
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.InsertDate = DateTime.Now;
                entity.DeletedDate = null;
                entity.Updatedate = null;
                datas.Add(entity);
                return Save();
            }
            return 0;
        }

        public void Update(T newEntity)
        {
            if (newEntity != null)
            {
                T oldEntity = datas.Find(newEntity.Id);
                if (oldEntity == null) return;
                newEntity.IsActive = oldEntity.IsActive;
                newEntity.IsDeleted = oldEntity.IsDeleted;
                newEntity.InsertDate = oldEntity.InsertDate;
                newEntity.Updatedate = DateTime.Now;
                newEntity.DeletedDate = oldEntity.DeletedDate;

                db.Entry(oldEntity).CurrentValues.SetValues(newEntity);
                Save();
            }
        }

        public int Delete(int? id)
        {
            if (id != null)
            {
                T entity = datas.Find(id);
                if (entity == null) return 0;
                entity.IsActive = false;
                entity.IsDeleted = true;
                entity.DeletedDate = DateTime.Now;
                return Save();
            }
            return 0;
        }

        public virtual int FullDelete(int? id)
        {
            if (id != null)
            {
                T entity = datas.Find(id);
                if (entity == null) return 0;
                datas.Remove(entity);
                return Save();
            }
            return 0;
        }

        public List<T> SelectAll()
        {
            return datas.Where(x => x.IsActive == true).ToList();
        }
        public List<T> SelectByCondition(Expression<Func<T, bool>> predicate)
        {
            return datas
                .Where(x => x.IsActive == true && x.IsDeleted == false)
                .Where(predicate).ToList();
        }
        public List<T> SelectByCondition(Expression<Func<T, bool>> predicate, bool? activeState = true, bool? deleteState = false)
        {
            if (activeState == true && deleteState == false)
                return SelectByCondition(predicate);

            return datas
                .Where(x => x.IsActive == activeState && x.IsDeleted == deleteState)
                .Where(predicate).ToList();
        }

        public List<T> SelectByState(bool? isActive = true, bool? isDeleted = false)
        {
            if (isActive == null && isDeleted == null) return datas.ToList();

            return datas
                   .Where(x => x.IsActive == isActive && x.IsDeleted == isDeleted)
                   .ToList();
        }

        public T SelectFirst(Expression<Func<T ,bool>> predicate)
        {
            return datas.FirstOrDefault(predicate);
        }

        public T SelectByOne(int? id)
        {
            if(id != null)
            {
                T obj = datas.Find(id);
                if (obj != null) return obj;
            }
            return null;
        }
        public List<T> SelectByOneList(int? id)
        {
            if(id != null)
            {
                return datas.Where(x => x.Id == id).ToList();
            }
            return null;
        }
    }
}