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

        #region[PageSetting]
        /*--Khởi tạo interface PageSetting--*/
        IGenericRepository<PageSetting> PageSettingRepo { get; }
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

        #region[Contact]
        IGenericRepository<Contact> ContactRepo { get; }
        #endregion

        #region[Promotion]
        IGenericRepository<Promotion> PromotionRepo { get; }
        #endregion

        #region[Advertisement]
        IGenericRepository<Advertisement> AdvertisementRepo { get; }
        #endregion

        /*======Phân quyền=========*/
        #region[UserProfile]
        IGenericRepository<UserProfile> UserProfileRepo { get; }
        #endregion

        #region[SysUserInGroup]
        IGenericRepository<SysUserInGroup> SysUserInGroupRepo { get; }
        #endregion

        #region[SysFunctionInGroup]
        IGenericRepository<SysFunctionInGroup> SysFunctionInGroupRepo { get; }
        #endregion

        #region[SysGroupRole]
        IGenericRepository<SysGroupRole> SysGroupRoleRepo { get; }
        #endregion

        #region[SysFunctionGroup]
        IGenericRepository<SysFunctionGroup> SysFunctionGroupRepo { get; }
        #endregion

        #region[SysFunction]
        IGenericRepository<SysFunction> SysFunctionRepo { get; }
        #endregion

        /*============*/
        /*--Khởi tạo phương thức--*/
        void Save();
        void ExcQuery(string sql, params object[] parameters);
    }
}