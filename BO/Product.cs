/*
*   <copyright file="Product.cs"
*      Copyright (c) 2025 All Rights Reserved
*   </copyright>
*   <author>Edgar Casal</author>
*   <date>03-11-2025 13:10:30</date>
*   <description></description>
**/

using System;

namespace BO;

/// <summary>
/// Purpose: The purpose of this class is to hold all the details about the item that can be sold.
/// It contains details like its name, price and stock.
/// Created by: Edgar Casal
/// Created on: 03-11-2025 13:10:30
/// </summary>
/// <remarks></remarks>
/// <example></example>
public class Product
{
    #region Attributes
    
    private int productId;
    private string productName;
    private decimal price;
    private int stockQuantity;
    private string brandName;
    private int warranty;              //Warranty in months

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
        warranty = 36;
    }
    
    /// <summary>
    /// Constructor for Product with parameters
    /// </summary>
    /// <param name="id">id of the product</param>
    /// <param name="pname">Name of the product</param>
    /// <param name="price">Price of the product</param>
    /// <param name="bname">Brand name of the product</param>
    /// <param name="stock">Quantity of stock for the product</param>
    public Product(int id, string pname, decimal price, string bname, int stock)
    {
        productId = id;
        productName = pname;
        this.price = price;
        brandName = bname;
        warranty = 36;
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
    public decimal Price
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
    /// A method that checks if a product has stock available. 
    /// </summary>
    /// <returns>Returns true if stock exists else returns false</returns>
    public bool IsInStock()
    {
        if (stockQuantity > 0) return true;
        
        return false;
    }
    
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    #region Overrides

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

    #endregion

    #region Operators

    #endregion

    #endregion
}