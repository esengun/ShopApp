﻿using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Abstract
{
	public interface IProductRepository
	{
		Product GetById(int id);
		List<Product> GetAll();
		void Create(Product entity);
		void Update(Product entity);
		void Delete(int id);
	}
}
