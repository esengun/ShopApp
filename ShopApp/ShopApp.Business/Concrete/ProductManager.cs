﻿using ShopApp.Business.Abstract;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concrete.EFCore;
using ShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
	public class ProductManager : IProductService
	{
		private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
			_productRepository = productRepository;
        }

        public void Create(Product entity)
		{
			// Apply business rules
			_productRepository.Create(entity);
		}

		public void Delete(Product entity)
		{
			// Apply business rules
			_productRepository.Delete(entity);
		}

		public List<Product> GetAll()
		{
			return _productRepository.GetAll();
		}

		public Product GetById(int id)
		{
			return _productRepository.GetById(id);
		}

		public Product GetProductDetails(int id)
		{
			return _productRepository.GetProductDetails(id);
		}

		public List<Product> GetProductsByCategory(string category)
		{
			return _productRepository.GetProductsByCategory(category);
		}

		public void Update(Product entity)
		{
			_productRepository.Update(entity);
		}
	}
}
