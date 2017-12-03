using Kingfisher.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingfisher.BLL.Repository.Entity
{
    public class WebUserRepository : Base.BaseRepository<WebUser>
    {
        public bool CheckByCredentials(string username , string password)
        {
            if(username != null && password != null)
            {
                return datas.Any(x => x.Username == username && x.Password == password);
            }
            return false;
        }
        public WebUser FindByUser(string username)
        {
            if(username != null)
            return datas.First(x => x.Username == username);

            return null;
        }
    }
}
