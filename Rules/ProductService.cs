/*
*   <copyright file="ProductService.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>26-12-2025 14:45:50</date>
*   <description></description>
**/

using System;
using Data.Repository.Interface;
using BO;

namespace Rules;

/// <summary>
/// Purpose:
/// Created by: Edgar Casal
/// Created on: 26-12-2025 14:45:50
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class ProductService
{
    #region Attributes

    private IProductRepository repository;

    #endregion

    #region Methods
    /// <summary>
    /// Used by the admins
    /// </summary>
    /// <param name="pname"></param>
    /// <param name="brand"></param>
    /// <param name="price"></param>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool RegisterProduct(string pname, string brand, double price, int stock)
    {
        //To avoid negative prices
        if (price <= 0)
        {
            return false;
        }

        //Creates the id for the new product by adding to the count of all current existing products
        int productId = repository.GetAllProducts().Count + 1;
        
        //creates the new product
        Product product = new Product(productId, pname, price, brand, stock);

        //Adds the product
        repository.AddProduct(product);
        return true;
    }

    public bool updateStock(int productId, int newStock)
    {
        if (newStock <= 0)
        {
            return false;
        }

        Product aux = repository.GetProductById(productId);

        if (aux == null)
        {
            return false;
        }
        
        aux.Restock(newStock);
        return true;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pname"></param>
    /// <returns></returns>
    public List<Product> SearchProduct(string pname)
    {
        return repository.SearchProductName(pname);
    }

    #endregion
}