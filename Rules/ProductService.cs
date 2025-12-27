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
/// Purpose: Responsible for all business rules related to the Products.
/// Register new products, updates stock, product searching.
/// Created by: Edgar Casal
/// Created on: 26-12-2025 14:45:50
/// </summary>
public class ProductService
{
    #region Attributes

    private IProductRepository repository;

    #endregion

    #region Methods
    /// <summary>
    /// This method registers a new product.
    /// It's meant to be used by the Admin.
    /// </summary>
    /// <param name="pname">Product's name</param>
    /// <param name="brand">Brand of the product</param>
    /// <param name="price">Product's price</param>
    /// <param name="stock">Quantity in stock</param>
    /// <returns>Returns true if the new product was successfully created and added to the repository.</returns>
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

    /// <summary>
    /// This method updates the stock of a given product.
    /// It's meant to be used only by Admin users.
    /// </summary>
    /// <param name="productId">The ID of the product needed to update stock</param>
    /// <param name="newStock">The quantity to be added</param>
    /// <returns>Returns true if successfully updated, else returns false</returns>
    public bool UpdateStock(int productId, int newStock)
    {
        // Validates if the new quantity to add is 0.
        if (newStock <= 0)
        {
            return false;
        }

        // Gets the product by the id given
        Product aux = repository.GetProductById(productId);

        // Validates if the product exists or not
        if (aux == null)
        {
            return false;
        }
        
        // Uses the method restock to update the stock
        aux.Restock(newStock);
        return true;

    }

    /// <summary>
    /// This method searches for a specific product and gets a list of products that contain that specific name.
    /// </summary>
    /// <param name="pname">Product's name to search for</param>
    /// <returns>Returns the list of products that contain the specific name</returns>
    public List<Product> SearchProduct(string pname)
    {
        return repository.SearchProductName(pname);
    }

    #endregion
}