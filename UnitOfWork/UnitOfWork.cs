using DbContextPOCO.Entity;
using LibRepository;
using System;

namespace UnitOfWork
{
    public class UnitOfWork
    {
        #region[System-Context]
        /*--Khởi tạo Context--*/
        private EShopEntities _context;
        #endregion

        #region[Category]
        /*--Khởi tạo Repository SysAutoId--*/
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
        #endregion
    }
}
