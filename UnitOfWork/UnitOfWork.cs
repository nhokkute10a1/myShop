using DbContextPOCO.Entity;
using LibRepository;
using System;

namespace UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region[System-Context]
        /*--Khởi tạo Context--*/
        private EShopEntities _context;
        #endregion
        /*============*/

        #region[Category]
        /*--Khởi tạo Repository Category--*/
        private IGenericRepository<Category> _categoryRepo;
        public IGenericRepository<Category> CategoryRepo
        {
            get
            {

                if (_categoryRepo == null)
                    _categoryRepo = new GenericRepository<Category>(_context);

                return _categoryRepo;
            }
        }
        #endregion

        #region[PageSetting]
        /*--Khởi tạo respository PageSetting--*/
        private IGenericRepository<PageSetting> _pageSettingRepo;
        public IGenericRepository<PageSetting> PageSettingRepo
        {
            get
            {
                if (_pageSettingRepo == null)
                    _pageSettingRepo = new GenericRepository<PageSetting>(_context);
                return _pageSettingRepo;
            }
        }
        #endregion

        #region[Menu]
        /*--Khởi tạo Repository SysAutoId--*/
        private IGenericRepository<Menu> _menuRepo;
        public IGenericRepository<Menu> MenuRepo
        {
            get
            {

                if (_menuRepo == null)
                    _menuRepo = new GenericRepository<Menu>(_context);

                return _menuRepo;
            }
        }
        #endregion

        #region[Product]
        private IGenericRepository<Product> _productRepo;
        public IGenericRepository<Product> ProductRepo
        {
            get
            {
                if (_productRepo == null)
                    _productRepo = new GenericRepository<Product>(_context);
                return _productRepo;

            }
        }
        #endregion

        #region[OrderMaster]
        private IGenericRepository<OrderMaster> _orderMasterRepo;
        public IGenericRepository<OrderMaster> OrderMasterRepo
        {
            get
            {
                if (_orderMasterRepo == null)
                    _orderMasterRepo = new GenericRepository<OrderMaster>(_context);
                return _orderMasterRepo;
            }
        }

        #endregion

        #region[Contact]
        private IGenericRepository<Contact> _contactRepo;
        public IGenericRepository<Contact> ContactRepo
        {
            get
            {
                if (_contactRepo == null)
                    _contactRepo = new GenericRepository<Contact>(_context);
                return _contactRepo;
            }
        }
        #endregion

        #region[Promotion]
        private IGenericRepository<Promotion> _promotionRepo;
        public IGenericRepository<Promotion> PromotionRepo
        {
            get
            {
                if (_promotionRepo == null)
                    _promotionRepo = new GenericRepository<Promotion>(_context);
                return _promotionRepo;
            }
        }
        #endregion

        #region[Advertisement]
        private IGenericRepository<Advertisement> _advertisementRepo;
        public IGenericRepository<Advertisement> AdvertisementRepo
        {
            get
            {
                if (_advertisementRepo == null)
                    _advertisementRepo = new GenericRepository<Advertisement>(_context);
                return _advertisementRepo;
            }
        }
        #endregion

        #region[OrderDetail]
        private IGenericRepository<OrderDetail> _orderDetailRepo;
        public IGenericRepository<OrderDetail> OrderDetailRepo
        {
            get
            {
                if (_orderDetailRepo == null)
                    _orderDetailRepo = new GenericRepository<OrderDetail>(_context);
                return _orderDetailRepo;
            }
        }
        #endregion

        /*===Phân quyền====*/
        #region[Phân quyền]

        /*===Phân quyền====*/
        #region[UserProfile]
        private IGenericRepository<UserProfile> _userProfileRepo;
        public IGenericRepository<UserProfile> UserProfileRepo
        {
            get
            {
                if (_userProfileRepo == null)
                    _userProfileRepo = new GenericRepository<UserProfile>(_context);
                return _userProfileRepo;
            }
        }
        #endregion

        #region[SysUserInGroup]
        private IGenericRepository<SysUserInGroup> _sysUserInGroupRepo;
        public IGenericRepository<SysUserInGroup> SysUserInGroupRepo
        {
            get
            {
                if (_sysUserInGroupRepo == null)
                    _sysUserInGroupRepo = new GenericRepository<SysUserInGroup>(_context);
                return _sysUserInGroupRepo;
            }
        }
        #endregion

        #region[SysFunctionInGroup]
        private IGenericRepository<SysFunctionInGroup> _sysFunctionInGroupRepo;
        public IGenericRepository<SysFunctionInGroup> SysFunctionInGroupRepo
        {
            get
            {
                if (_sysFunctionInGroupRepo == null)
                    _sysFunctionInGroupRepo = new GenericRepository<SysFunctionInGroup>(_context);
                return _sysFunctionInGroupRepo;
            }
        }
        #endregion

        #region[SysGroupRole]
        private IGenericRepository<SysGroupRole> _sysGroupRoleRepo;
        public IGenericRepository<SysGroupRole> SysGroupRoleRepo
        {
            get
            {
                if (_sysGroupRoleRepo == null)
                    _sysGroupRoleRepo = new GenericRepository<SysGroupRole>(_context);
                return _sysGroupRoleRepo;
            }
        }
        #endregion

        #region[SysFunctionGroup]
        private IGenericRepository<SysFunctionGroup> _sysFunctionGroupRepo;
        public IGenericRepository<SysFunctionGroup> SysFunctionGroupRepo
        {
            get
            {
                if (_sysFunctionGroupRepo == null)
                    _sysFunctionGroupRepo = new GenericRepository<SysFunctionGroup>(_context);
                return _sysFunctionGroupRepo;
            }
        }
        #endregion

        #region[SysFunction]
        private IGenericRepository<SysFunction> _sysFunctionRepo;
        public IGenericRepository<SysFunction> SysFunctionRepo
        {
            get
            {
                if (_sysFunctionRepo == null)
                    _sysFunctionRepo = new GenericRepository<SysFunction>(_context);
                return _sysFunctionRepo;
            }
        }
        #endregion

        #endregion

        /*============*/
        #region[System-UnitOfWork]
        /*--Khởi tạo UnitOfWork--*/
        public UnitOfWork()
        {
            _context = new EShopEntities();
        }
        public void Save()
        {
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }

        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void ExcQuery(string sql, params object[] parameters)
        {
            _context.Database.ExecuteSqlCommand(sql, parameters);
        }
        #endregion
    }
}
