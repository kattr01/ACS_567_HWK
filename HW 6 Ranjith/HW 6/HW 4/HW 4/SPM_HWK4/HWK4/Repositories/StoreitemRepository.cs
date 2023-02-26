using System;
using HWK4.Data;
using HWK4.Interfaces;
using HWK4.Models;

namespace HWK4.Repositories
{
	public class StoreitemRepository : IStoreitemRepository
	{
		private DataContext _context;

		public StoreitemRepository(DataContext context)
		{
			_context = context;
		}
		//Displays all the items
        public ICollection<Storeitems> GetStoreitems()
		{
			return _context.Storeitems.ToList();
		}
		//get individual items
        public Storeitems GetStoreitem(int id)
		{
            return _context.Storeitems.Where(todo => todo.Id == id).FirstOrDefault();
		}

		public bool StoreitemExists(int id)
		{
			return _context.Storeitems.Any(todo => todo.Id == id);
		}
		//create new items
		public bool CreateStoreitem(Storeitems todo)
		{
            //if(StoreitemExists(todo.Id))
            //{
            //    return false;
            //}
			_context.Add(todo);
			return Save();
		}
		//update the existing items
		public bool UpdateStoreitem(Storeitems Storeitem)
		{
			_context.Update(Storeitem);
			return Save();
		}
		//Delete the items
		public bool DeleteStoreitem(int id)
		{
            Storeitems exp = GetStoreitem(id);
            if (exp == null || !StoreitemExists(exp.Id))
            {
                return false;
            }
            _context.Remove(exp);
			return Save();
		}

		public bool Save()
		{
			int saved = _context.SaveChanges();
			return saved == 1;
		} 
    }
}

