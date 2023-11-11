﻿using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
	public interface IProductService
	{
		Product GetById(int id);
		List<Product> GetAll();
		void Create(Product entity);
		void Update(Product entity);
		void Delete(Product entity);
		Product GetProductDetails(string url);
		List<Product> GetProductsByCategory(string category, int page, int pageSize);
		int GetCountByCategory(string category);
		List<Product> GetHomeProducts();
		List<Product> GetSearchResult(string searchString);
		Product GetByIdWithCategories(int productId);
	}
}
