using Kingfisher.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.BLL.Repository.Entity
{
    public class OrderRepository : Base.BaseRepository<Order>
    {
        public override int Insert(Order entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = false;
                entity.InsertDate = DateTime.Now;
                entity.DeletedDate = null;
                entity.Updatedate = null;
                datas.Add(entity);
                return Save();
            }
            return 0;
        }
    }
}
