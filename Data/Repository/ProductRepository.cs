/*
*   <copyright file="ProductRepository.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>26-12-2025 14:31:13</date>
*   <description></description>
**/

using System;
using BO;
using Data.Repository.Interface;

namespace Data.Repository;

/// <summary>
/// Purpose:
/// Created by: Edgar Casal
/// Created on: 26-12-2025 14:31:13
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class ProductRepository:IProductRepository
{
    #region Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public bool AddProduct(Product product)
    {
        if (Store.Products.ContainsKey(product.ProductId))
        {
            return false;
        }
        
        Store.Products.Add(product.ProductId, product);
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public bool RemoveProduct(Product product)
    {
        if (Store.Products.ContainsKey(product.ProductId))
        {
            Store.Products.Remove(product.ProductId);
            return true;
        }

        return false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Product GetProductById(int id)
    {
        if (Store.Products.ContainsKey(id))
        {
            return Store.Products[id];
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Product> GetAllProducts()
    {
        return Store.Products.Values.ToList();
    }

    #endregion
}