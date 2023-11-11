﻿using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void DeleteProductFromCategory(int productId, int categoryId);
		Category GetByIdWithProducts(int categoryId);
		List<Product> GetPopularCategories();
	}
}
