﻿using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
	public interface IProductRepository : IRepository<Product>
	{
		Product GetProductDetails(int id);
		List<Product> GetPopularProducts();
		List<Product> Gettop5Products();


	}
}
