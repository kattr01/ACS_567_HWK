using System;
using HWK4.Data;
using HWK4.Models;

namespace HWK4
{
	public class Seed
	{
		private readonly DataContext dataContext;
		public Seed(DataContext dataContext) 
		{
			this.dataContext = dataContext;
		}

		public void SeedDataContext()
		{
			if(!dataContext.Storeitems.Any())
			{
				List<Storeitems> todos = new()
				{
                 new Storeitems {Id = 1, Name = "Grape", Description = "vegetables",Category="Red Tangy",Amount=20 },
                };
				dataContext.Storeitems.AddRange(todos);
				dataContext.SaveChanges();
			}
		}
	}
}

