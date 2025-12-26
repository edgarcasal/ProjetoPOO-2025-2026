/*
 *	<copyright file="IUserRepository.cs"
 *	Copyright (c) 2025 All Rights Reserved
 *	</copyright>
 * 	<author>Edgar Casal</author>
 *   <date>26-12-2025 14:27:20</date>
 *	<description></description>
 **/

using System;
using BO;

namespace Data.Repository.Interface;

public interface IProductRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    bool AddProduct(Product product);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    bool RemoveProduct(Product product);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Product GetProductById(int id);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    List<Product> GetAllProducts();
}