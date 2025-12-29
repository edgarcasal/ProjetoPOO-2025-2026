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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
#pragma warning disable SYSLIB0011

namespace Data.Repository;

/// <summary>
/// Purpose: The Data Access Layer for Products.
/// Created by: Edgar Casal
/// Created on: 26-12-2025 14:31:13
/// </summary>
public class ProductRepository:IProductRepository
{
    
    private const string FILE_PATH = "products.bin";
    
    #region Methods

    /// <summary>
    /// Adds a new product to the data dictionary.
    /// </summary>
    /// <param name="product">The product object to add</param>
    /// <returns>Returns true if successfully added</returns>
    public bool AddProduct(Product product)
    {
        // Checks if the dictionary already contains the product
        if (Store.Products.ContainsKey(product.ProductId))
        {
            return false;
        }
        
        // Adds the product to the dictionary
        Store.Products.Add(product.ProductId, product);
        return true;
    }

    /// <summary>
    /// Removes a product from the data dictionary.
    /// </summary>
    /// <param name="product">The product object to be removed</param>
    /// <returns>Returns true if successfully removed</returns>
    public bool RemoveProduct(Product product)
    {
        // Checks if the product exists in the dictionary and if so, removes it
        if (Store.Products.ContainsKey(product.ProductId))
        {
            Store.Products.Remove(product.ProductId);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Gets the product by the given ID
    /// </summary>
    /// <param name="id">The ID to look for a product</param>
    /// <returns>Returns the product if found, else returns null</returns>
    public Product GetProductById(int id)
    {
        // Checks if the dictionary has the id
        if (Store.Products.ContainsKey(id))
        {
            return Store.Products[id];
        }

        return null;
    }

    /// <summary>
    /// Lists all products available
    /// </summary>
    /// <returns>Returns a list of all products available</returns>
    public List<Product> GetAllProducts()
    {
        return Store.Products.Values.ToList();
    }

    /// <summary>
    /// Searches a product by its name.
    /// </summary>
    /// <param name="pname">The product's name to search for</param>
    /// <returns>Returns a list of all results found with the given name.</returns>
    public List<Product> SearchProductName(string pname)
    {
        // Creates a new list of products, intended to be returned with all the results
        List<Product> results = new List<Product>();

        // Checks if there are no results found
        if (string.IsNullOrEmpty(pname))
        {
            return results;
        }
        
        // Adds every product found to the list of products
        foreach (Product p in Store.Products.Values)
        {
            if (p.ProductName.ToLower().Contains(pname.ToLower()))
            {
                results.Add(p);
            }
        }

        // Returns the list.
        return results;
    }
    
    /// <summary>
    /// Saves the current dictionary of products to a binary file
    /// If the file already exists it is deleted and recreated.
    /// </summary>
    public void SaveProducts()
    {
        FileStream fs = null;

        try
        {
            //If exists, deletes it first to start over
            if (File.Exists(FILE_PATH))
            {
                File.Delete(FILE_PATH);
            }

            //Creates the file
            fs = File.Create(FILE_PATH);

            //Serialize the dictionary
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, Store.Products);
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Error saving file: " + e.Message);
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
    }
    
    /// <summary>
    /// Loads product data from the binary file
    /// This method clears the existing 'Store.Products' dictionary before to avoid duplicate conflicts.
    /// If the file does not exist, it ensures the Store remains empty but valid.
    /// </summary>
    public void LoadProducts()
    {
        FileStream fs = null;

        try
        {
            //Checks if file exists
            if (File.Exists(FILE_PATH))
            {
                //Opens the file
                fs = File.Open(FILE_PATH, FileMode.Open);

                // Checks if file has data
                if (fs.Length > 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                
                    // Deserialize to a temporary dictionary
                    Dictionary<int, Product> tempProducts = (Dictionary<int, Product>)bf.Deserialize(fs);
               
                    // Clears the existing Store to avoid duplicates
                    Store.Products.Clear();

                    foreach (KeyValuePair<int, Product> entry in tempProducts)
                    {
                        //where entry.Key is the id and entry.value is the product object
                        Store.Products.Add(entry.Key, entry.Value);
                    }

                }

            }
        }
        catch (System.Exception e)
        {
            Console.WriteLine("Error loading file: " + e.Message);
            // File might be corrupted so it starts fresh
            Store.Products.Clear();
        }
        finally
        {
            if (fs != null)
            {
                fs.Close();
            }
        }
    }

    #endregion
}