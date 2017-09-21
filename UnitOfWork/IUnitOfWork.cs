using DbContextPOCO.Entity;
using LibRepository;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        #region[Category]
        /*--Khởi tạo interface-SysAutoId--*/
        IGenericRepository<Category> CategoryRepo { get; }
        #endregion

        #region[Menu]
        /*--Khởi tạo interface-SysAutoId--*/
        IGenericRepository<Menu> MenuRepo { get; }
        #endregion


        /*--Khởi tạo phương thức--*/
        void Save();
    }
}