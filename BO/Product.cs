/*
*   <copyright file="Product.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>03-11-2025 13:10:30</date>
*   <description></description>
**/

using System;
using Exception;


namespace BO;

/// <summary>
/// Purpose: The purpose of this class is to hold all the details about the item that can be sold.
/// It contains details like its name, price and stock.
/// Created by: Edgar Casal
/// Created on: 03-11-2025 13:10:30
/// </summary>
[Serializable]
public class Product : IComparable
{
    #region Attributes
    
    private int productId;
    private string productName;
    private double price;
    private int stockQuantity;
    private string brandName;

    #endregion

    #region Methods

    #region Constructors

    /// <summary>
    /// Default constructor for Product
    /// </summary>
    public Product()
    {
        productId = -1;
        productName = "";
        price = -1;
        brandName = "";
        stockQuantity = -1;
    }
    
    /// <summary>
    /// Constructor for Product with parameters
    /// </summary>
    /// <param name="id">id of the product</param>
    /// <param name="pname">Name of the product</param>
    /// <param name="price">Price of the product</param>
    /// <param name="bname">Brand name of the product</param>
    /// <param name="stock">Quantity of stock for the product</param>
    public Product(int id, string pname, double price, string bname, int stock)
    {
        if (string.IsNullOrEmpty(pname))
        {
            throw new InvalidProductException("A product must have a name.");
        }

        if (price < 0)
        {
            throw new InvalidProductException("Price cannot be negative.");
        }
        
        productId = id;
        productName = pname;
        this.price = price;
        brandName = bname;
        stockQuantity = stock;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the ID of the product.
    /// </summary>
    public int ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    /// <summary>
    /// Gets or Sets the name of the Product.
    /// </summary>
    public string ProductName
    {
        get { return productName; }
        set { productName = value; }
    }

    /// <summary>
    /// Gets or Sets the price of the Product.
    /// </summary>
    public double Price
    {
        get { return price; }
        set { if (value > 0) price = value; }
    }

    /// <summary>
    /// Gets or sets the brand name of the Product.
    /// </summary>
    public string BrandName
    {
        get { return brandName; }
        set { brandName = value; }
    }
    #endregion

    /// <summary>
    /// Gets the stock quantity of the Product.
    /// </summary>
    public int StockQuantity
    {
        get { return stockQuantity; }
    }

    #region OtherMethods

    /// <summary>
    /// A method that removes stock when a purchase is made.
    /// </summary>
    /// <param name="quantity">Quantity to be removed</param>
    /// <returns>Returns true if it removes successfully</returns>
    public bool RemoveStock(int quantity)
    {
        if (quantity <= 0 || stockQuantity <= 0)
        {
            return false;
        }

        stockQuantity -= quantity;
        return true;
    }

    /// <summary>
    /// A method that restocks a product's stock. It adds stock according to the quantity given.
    /// </summary>
    /// <param name="quantity">The quantity of stock to be added to the product</param>
    /// <returns>Returns true if restocked succesfully</returns>
    public bool Restock(int quantity)
    {
        if (quantity <= 0)
        {
            return false;
        }

        stockQuantity += quantity;
        return true;
    }
    
    /// <summary>
    /// Compares this Product with another object to determine their sort order.
    /// Products are compared based on their unique Product ID.
    /// </summary>
    /// <param name="obj">The object to compare with this Product.</param>
    /// <returns>A value less than 0 if this Product precedes the other; 
    /// 0 if they are in the same position; 
    /// greater than 0 if this Product follows the other.</returns>
    public int CompareTo(object obj)
    {
        Product aux = obj as Product;
        
        if (aux == null)
        {
            return 1;
        }
        return this.ProductId.CompareTo(aux.ProductId);
    }
    
    #endregion


    #region Overrides

    /// <summary>
    /// Determines whether the specified object is equal to the current Product.
    /// Equality is defined by matching Product IDs.
    /// </summary>
    /// <param name="obj">The object to compare with the current Product.</param>
    /// <returns>True if the specified object is a Product with the same ID, otherwise false.</returns>
    public override bool Equals(object obj)
    {
        Product aux;
        if (obj is Product)
        {
            aux = (Product)obj;
            return aux.productId == this.productId;
        }

        return false;
    }

    /// <summary>
    /// Returns a hash code for this Product.
    /// This code is generated using the unique Product ID.
    /// </summary>
    /// <returns>A hash code integer.</returns>
    public override int GetHashCode()
    {
        return ProductId.GetHashCode();
    }

    /// <summary>
    /// Returns a string representing the Product's details.
    /// Format: [ID] Name - Brand | Price€ | Stock
    /// </summary>
    /// <returns>A formatted string containing ID, name, brand, price, and stock quantity.</returns>
    public override string ToString()
    {
        return $"[{ProductId}] {ProductName} - {BrandName} | {Price}€ | {StockQuantity}";
    }
    #endregion
    
    #endregion
}