using DbContextPOCO.Entity;
using LibRepository;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        #region[Category]
        /*--Khởi tạo interface-CategoryRepo--*/
        IGenericRepository<Category> CategoryRepo { get; }
        #endregion

        #region[Menu]
        /*--Khởi tạo interface-MenuRepo--*/
        IGenericRepository<Menu> MenuRepo { get; }
        #endregion

        #region[Product]
        /*--Khởi tạo interface-ProductRepo--*/
        IGenericRepository<Product> ProductRepo { get; }
        #endregion



        /*============*/
        /*--Khởi tạo phương thức--*/
        void Save();
        void ExcQuery(string sql, params object[] parameters);
    }
}