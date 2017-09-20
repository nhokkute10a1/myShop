using Entity.EntityModel;
using LibRepository;
using System;

namespace UnitOfWork
{
    //step 3
    public interface IUnitOfWork : IDisposable
    {
        #region[Category]
        /*--Khởi tạo interface-Category--*/
        IGenericRepository<Category> CategoryRepo { get; }
        #endregion
        /*--Khởi tạo phương thức--*/
        void Save();
    }
}