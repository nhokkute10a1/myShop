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

        #region[OrderMaster]
        /*--Khởi tạo interface-OrderMasterRepo--*/
        IGenericRepository<OrderMaster> OrderMasterRepo { get; }

        #endregion

        #region[OrderDetail]
        /*--Khởi tạo interface-OrderMasterRepo--*/
        IGenericRepository<OrderDetail> OrderDetailRepo { get; }

        #endregion

        #region[UserProfile]
        IGenericRepository<UserProfile> UserProfileRepo { get; }
        #endregion

        #region[UserRole]
        IGenericRepository<UserRole> UserRolesRepo { get; }
        #endregion

        #region[Role]
        IGenericRepository<Role> RolesRepo { get; }
        #endregion


        /*============*/
        /*--Khởi tạo phương thức--*/
        void Save();
        void ExcQuery(string sql, params object[] parameters);
    }
}