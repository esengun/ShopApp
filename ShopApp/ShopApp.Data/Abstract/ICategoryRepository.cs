using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
	public interface ICategoryRepository
	{
		Category GetById(int id);
		List<Category> GetAll();
		void Create(Category entity);
		void Update(Category entity);
		void Delete(int id);
	}
}
