﻿using ShopApp.Data.Abstract;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data.Concrete.MSSQL
{
	public class SQLProductRepository : IProductRepository
	{
		public void Create(Product entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Product> GetAll()
		{
			throw new NotImplementedException();
		}

		public Product GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Product entity)
		{
			throw new NotImplementedException();
		}
	}
}
