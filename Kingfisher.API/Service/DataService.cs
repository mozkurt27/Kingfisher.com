using Kingfisher.BLL.Service;

namespace Kingfisher.API.Service
{
    public sealed class DataService
    {
        private static readonly EntityService service = new EntityService();

        public static EntityService Service
        {
            get
            {
                return service;
            }
        }

    }
}