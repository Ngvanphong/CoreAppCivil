﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeduCoreApp.Data.Entities;
using TeduCoreApp.Data.ViewModels.Product;
using TeduCoreApp.Data.ViewModels.Tag;

namespace TeduCoreApp.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        Task<ProductViewModel> AddAsync(ProductViewModel product);

        void Update(ProductViewModel product);

        void UpdateDb(Product productDb);

        void Delete(int id);

        List<string> GetProductName(string productName);

        List<ProductViewModel> GetAll();

        List<ProductViewModel> GetNewProduct(int number);

        List<ProductViewModel> GetAll(int? categoryId, string keyword, int page, int pageSize, out int totalRow);

        List<ProductViewModel> GetAllPaging(int page, int pageSize, out int totalRow);

        ProductViewModel GetById(int id);

        Product GetProductDbById(int id);

   

        List<ProductViewModel> GetAllByCategoryPaging(int categoryId, int page, int pageSize, out int totalRow);

        List<ProductViewModel> GetAllByNamePaging(string Name, int page, int pageSize, out int totalRow);

        List<ProductViewModel> GetProductRelate(int categoryId, int number);

       

        List<TagViewModel> GetAllTag(int number);

        List<TagViewModel> GetTagByProductId(int productId);

        TagViewModel GetTagById(string id);

        void SaveChanges();

        List<ProductViewModel> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
    }
}