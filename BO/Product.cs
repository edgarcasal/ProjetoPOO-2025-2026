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
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return ProductId.GetHashCode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"[{ProductId}] {ProductName} - {BrandName} | {Price}€ | {StockQuantity}";
    }
    #endregion
    
    #endregion
}