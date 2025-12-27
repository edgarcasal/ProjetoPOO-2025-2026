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


/// <summary>
/// Purpose: Defines the contract for accessing Product data.
/// Any class that implements this interface must provide code for these methods.
/// Created by: Edgar Casal
/// Created on: 26-12-2025 14:27:20
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Saves a new Product to the data Store.
    /// </summary>
    /// <param name="product">The product to save</param>
    /// <returns>True if successful, False if the product ID already exists.</returns>
    bool AddProduct(Product product);
    
    /// <summary>
    /// Removes a product from the data Store.
    /// </summary>
    /// <param name="product">The product to remove</param>
    /// <returns>True if successful, False if the product ID does not exist.</returns>
    bool RemoveProduct(Product product);

    /// <summary>
    /// Gets a single product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to get</param>
    /// <returns>Returns the product if found, returns null if not found.</returns>
    Product GetProductById(int id);

    /// <summary>
    /// Gets a list of all products in the system.
    /// </summary>
    /// <returns>Returns a list of product objects.</returns>
    List<Product> GetAllProducts();

    /// <summary>
    /// Gets a list of products that contain the string given.
    /// </summary>
    /// <param name="pname">The name to search for</param>
    /// <returns>Returns a list of products related to the given name.</returns>
    List<Product> SearchProductName(string pname);
}