using HWK4.Models;

namespace HWK4.Interfaces
{
    public interface IStoreitemRepository
    {
        ICollection<Storeitems> GetStoreitems();
        Storeitems GetStoreitem(int Id);
        bool StoreitemExists(int Id);
        bool CreateStoreitem(Storeitems Storeitem);
        bool UpdateStoreitem(Storeitems Storeitem);
        bool Save();
        bool DeleteStoreitem(int id);
    }
}


