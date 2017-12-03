using Kingfisher.BLL.Repository.Entity;

namespace Kingfisher.BLL.Service
{
    public class EntityService
    {
        public EntityService()
        {
            _bookService = new BookRepository();
            _categoryService = new CategoryRepository();
            _orderDetailService = new OrderDetailRepository();
            _orderService = new OrderRepository();
            _publisherService = new PublisherRepository();
            _roleService = new RoleRepository();
            _webUserservice = new WebUserRepository();
        }

        private BookRepository _bookService;

        public BookRepository BookService
        {
            get { return _bookService; }
            set { _bookService = value; }
        }


        private CategoryRepository _categoryService;

        public CategoryRepository CategoryService
        {
            get { return _categoryService; }
            set { _categoryService = value; }
        }


        private OrderRepository _orderService;

        public OrderRepository OrderService
        {
            get { return _orderService; }
            set { _orderService = value; }
        }


        private OrderDetailRepository _orderDetailService;

        public OrderDetailRepository OrderDetailService
        {
            get { return _orderDetailService; }
            set { _orderDetailService = value; }
        }


        private PublisherRepository _publisherService;

        public PublisherRepository PublisherService
        {
            get { return _publisherService; }
            set { _publisherService = value; }
        }


        private RoleRepository _roleService;

        public RoleRepository RoleService
        {
            get { return _roleService; }
            set { _roleService = value; }
        }


        private WebUserRepository _webUserservice;

        public WebUserRepository WebUserService
        {
            get { return _webUserservice; }
            set { _webUserservice = value; }
        }
    }
}
