using Entity;
using Entity.EntityModel;
using LibRepository;
using System;

namespace UnitOfWork
{
    //step 4
    public class UnitOfWork : IUnitOfWork
    {
        #region[System-Context]
        /*--Khởi tạo Context--*/
        private EShopDbContext _context;
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
        

        #region[System-UnitOfWork]
        /*--Khởi tạo UnitOfWork--*/

        public UnitOfWork()
        {
            _context = new EShopDbContext();
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